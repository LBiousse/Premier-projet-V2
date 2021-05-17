using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    public bool isControlled = false;
    public float speed = 2f;
    public float jumpSpeed = 20f;

    Rigidbody body;

    void UpdateControlChild() {
        transform.Find("Control").gameObject.SetActive(isControlled);
    }

    Vector3 TransformVectorByCameraRotationY(Vector3 vector) {
        // Ouais, ces 3 lignes sont compliquées :
        // Il s'agit d'appliquer la rotation de la camera (sur l'axe Y uniquement)
        // au mouvement que l'on souhaite affecter au "rigid body". Sans cette 
        // opération, le mouvement s'exprime en "absolu" selon le repère "monde". 
        // Grâce au quaternion le mouvement (x, y, z) est exprimé selon le repère 
        // de la caméra : ainsi flèche gauche désigne un mouvement latéral vers la 
        // gauche de la caméra (et non vers la gauche du repère "monde").
        float cameraRotationY = Camera.main.transform.rotation.eulerAngles.y;
        Quaternion cameraQuaternion = Quaternion.Euler(0, cameraRotationY, 0);
        return cameraQuaternion * vector;
    }

    void move() {
        float x = speed * Input.GetAxis("Horizontal");
        float y = body.velocity.y;
        float z = speed * Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) {
            y = jumpSpeed;
        }

        Vector3 velocity = new Vector3(x, y, z);
        body.velocity = TransformVectorByCameraRotationY(velocity);
    }
    void Start() {
        body = GetComponent<Rigidbody>();
        UpdateControlChild();
    }

    void Update() {
        if (isControlled == true) {
            move();
        }
    }

    void OnMouseDown() {
    isControlled = !isControlled;
    UpdateControlChild();
    }
}
