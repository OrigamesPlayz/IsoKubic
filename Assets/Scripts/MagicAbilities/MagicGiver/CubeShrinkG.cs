using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShrinkG : MonoBehaviour
{
    public bool powerCollected = false;
    public float timeBeforeDestruction = 0.75f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShrinkPower"))
        {
            powerCollected = true;
            Destroy(other.gameObject);
        }
    }
}
