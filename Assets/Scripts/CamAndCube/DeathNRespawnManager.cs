using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathNRespawnManager : MonoBehaviour
{
    public float thresholdUpD;
    public float thresholdDownD;
    public GameObject cam;
    public Rigidbody playerRb;
    public float thresholdUpC;
    public float thresholdDownC;
    public ConstantForce cForce;
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        DeathNRespawn();
        CameraUnfollowNRefollow();
    }

    public void DeathNRespawn()
    {
        if (transform.position.y < thresholdDownD || transform.position.y > thresholdUpD)
        {
            StartCoroutine(KinematicChecker());
            //probs will start a coroutine here to add a transition blackscreen for the respawn KEEP IN MIND FUTURE ME!!!
        }
    }

    IEnumerator KinematicChecker()
    {
        playerRb.isKinematic = true;
        transform.position = new Vector3(4.5f, 1.5f, -5.5f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cForce.force = new Vector3(0f, -9.81f, 0f);
        yield return new WaitForSeconds(0.02f);
        playerRb.isKinematic = false;
    }
    
    public void CameraUnfollowNRefollow()
    {
        CameraFollow camFol = cam.GetComponent<CameraFollow>();

        if (transform.position.y < thresholdDownC || transform.position.y > thresholdUpC)
        {
            camFol.enabled = false;
        }

        else if (transform.position.y > thresholdDownC || transform.position.y < thresholdUpC)
        {
            camFol.enabled = true;
        }
    }
}
