using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCube : MonoBehaviour
{
    public ConstantForce cForce;
    public CubeController cCon;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillCube") && cCon.isMoving == false)
        {
            transform.position = new Vector3(4.5f, 1.5f, -5.5f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            cForce.force = new Vector3(0f, -9.81f, 0f);
        }
    }
}
