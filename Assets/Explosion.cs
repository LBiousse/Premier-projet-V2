using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int count = 16;
    public GameObject shard;

    public void Explode() {

        if (shard == null) {
            Debug.LogWarning("Ne peut pas exploser : \"shard\" est null !!!");
            return;
        }

        for (int i = 0; i < count; i += 1) {
            GameObject clone = Instantiate(shard, transform.position, Quaternion.identity);
            Rigidbody body = clone.GetComponent<Rigidbody>();

            // définir la vitesse du "shard"
            float velocityBoost = Random.Range(1f, 2f);
            body.velocity = Random.onUnitSphere * 10f * velocityBoost;

            // détruire le "shard" au bout d'un certain temps (entre 1 et 2 secondes) 
            float duration = Random.Range(1f, 2f);
            Destroy(clone, duration);
        }
    }

    public bool trigger = false;
    void Update() {
        if (trigger == true) {
            trigger = false;
            Explode();
        }
    }

    void OnDestroy() {
        // pas d'explosion si l'application est sur le point de fermer.
        if (Application.isPlaying == false) {
            return;
        }

        Explode();
    }
}