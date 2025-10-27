using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetDown = new Vector3(-3.5f, 5f, -3.5f);
    public Vector3 offsetUp = new Vector3(-3.5f, -4.5f, -3.5f);
    public float smoothSpeed = 5f;
    
    

    void LateUpdate()
    {
        ConstantForce cForce = player.GetComponent<ConstantForce>();
        if (player == null) return;

        if (cForce.force == new Vector3 (0f, -9.81f, 0f))
        {
            Vector3 targetPos = player.transform.position + offsetDown;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
            transform.LookAt(player);
        }

        else if (cForce.force == new Vector3 (0f, 9.81f, 0f))
        {
            Vector3 targetPos = player.transform.position + offsetUp;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
            transform.LookAt(player);
        }
    }
}
