using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        //Debug.Break();
        // Debug.Log(other);        
        Destroy(other.gameObject);
    }
}    