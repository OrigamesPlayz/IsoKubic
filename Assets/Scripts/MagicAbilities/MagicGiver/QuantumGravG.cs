using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumGravG : MonoBehaviour
{
    public GameObject gravEffect;
    public bool powerCollected = false;
    public float timeBeforeDestruction = 0.75f;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GraviPower"))
        {
            powerCollected = true;
            Destroy(other.gameObject);
        }
    }
}
