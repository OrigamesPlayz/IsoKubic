using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public CubeController cCon;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WinBlock") && cCon.isMoving == false)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
