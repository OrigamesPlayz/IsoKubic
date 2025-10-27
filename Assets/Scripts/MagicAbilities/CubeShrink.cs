using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShrink : MonoBehaviour
{
    public GameObject player;
    public CubeShrinkG cubeShrinkG;
    public Animator playerAnim;
    public CubeController cCon;
    public CubeEnlarge cubeEnlarge;
    public bool isReady = true;
    public bool isShrunken = false;
    public float timeShrunk = 2;
    public float cooldown = 5;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isReady && cubeShrinkG.powerCollected && !cCon.isMoving && !cubeEnlarge.isEnlarged)
        {
            isReady = false;
            cCon.enabled = false;
            isShrunken = true;
            StartCoroutine(ShrinkNReturn());
        }
    }

    IEnumerator ShrinkNReturn()
    {
        playerAnim.SetTrigger("Shrink");
        yield return new WaitForSeconds(1);
        cCon.rollSpeed = cCon.rollSpeed * 2;
        cCon.checkDistance = cCon.checkDistance / 2;
        cCon.enabled = true;
        cCon.pVal = cCon.pNormal / 2;
        cCon.nVal = cCon.nNormal / 2;
        yield return new WaitForSeconds(timeShrunk);
        if (!cCon.isMoving)
        {
            playerAnim.SetTrigger("Unshrunken");
            yield return new WaitForSeconds(1);
            isShrunken = false;
            cCon.rollSpeed = cCon.rollSpeed / 2;
            cCon.checkDistance = cCon.checkDistance * 2;
            cCon.enabled = false;
            cCon.pVal = cCon.pNormal;
            cCon.nVal = cCon.nNormal;
            yield return new WaitForSeconds(cooldown);
            isReady = true;
        }
    }
}
