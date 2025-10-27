using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnlarge : MonoBehaviour
{
    public GameObject player;
    public CubeEnlargeG cubeEnlargeG;
    public Animator playerAnim;
    public CubeController cCon;
    public CubeShrink cubeShrink;
    public bool isReady = true;
    public bool isEnlarged = false;
    public float timeShrunk = 2;
    public float cooldown = 5;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && isReady && cubeEnlargeG.powerCollected && !cCon.isMoving && !cubeShrink.isShrunken)
        {
            isReady = false;
            cCon.enabled = false;
            isEnlarged = true;
            StartCoroutine(EnlargeNReturn());
        }
    }

    IEnumerator EnlargeNReturn()
    {
        playerAnim.SetTrigger("Enlarge");
        yield return new WaitForSeconds(1);
        cCon.checkDistance = cCon.checkDistance * 2;
        cCon.enabled = true;
        cCon.pVal = cCon.pNormal * 2;
        cCon.nVal = cCon.nNormal * 2;
        yield return new WaitForSeconds(timeShrunk);
        if (!cCon.isMoving)
        {
            playerAnim.SetTrigger("Unlarged");
            yield return new WaitForSeconds(1);
            isEnlarged = false;
            cCon.checkDistance = cCon.checkDistance / 2;
            cCon.enabled = false;
            cCon.pVal = cCon.pNormal;
            cCon.nVal = cCon.nNormal;
            yield return new WaitForSeconds(cooldown);
            isReady = true;
        }
    }
}