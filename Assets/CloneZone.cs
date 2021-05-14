using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Instantiate(other.gameObject);        
    }
}