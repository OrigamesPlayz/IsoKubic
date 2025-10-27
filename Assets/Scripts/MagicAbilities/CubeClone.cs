using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClone : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    void Update()
    {
        CameraFollow camPosManager = cam.GetComponent<CameraFollow>();
        if (Input.GetKeyDown(KeyCode.K))
        {
            camPosManager.offsetDown = new Vector3(-3.5f, 5f, -4.5f);
            camPosManager.offsetUp = new Vector3(-3.5f, -5f, -4.5f);
            Vector3 playerPos = player.transform.position;
            playerPos.z = playerPos.z + 1f;
            player.transform.position = playerPos;
        }
    }
}
