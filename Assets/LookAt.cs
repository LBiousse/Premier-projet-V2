using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LookAt : MonoBehaviour
{
    public bool lookAtCamera = false;
    public Transform target;

    void Update()
    {
        if (target != null) {
            transform.LookAt(target);
        }

        if (lookAtCamera == true) {
            if (Camera.main != null) {
                transform.LookAt(Camera.main.transform);
            }
        }
    }
}