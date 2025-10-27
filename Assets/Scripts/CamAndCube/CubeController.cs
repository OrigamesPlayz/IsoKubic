using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float rollSpeed = 3f;
    public float checkDistance = 1f; // how far ahead to check for obstacles
    public bool isMoving;
    public Rigidbody rb;
    public ConstantForce cForce;

    [Header("Anchors")]
    public float pNormal = 0.5f;
    public float nNormal = -0.5f;

    public float pVal;
    public float nVal;

    [Header("RoundedPos")]
    public float roundPosX;
    public float roundPosZ;

    void Start()
    {
        pVal = pNormal;
        nVal = nNormal;

        // roundPosX = MathPaskapytty.Round(transform.position.x * 2, MidpointRounding.AwayFromZero) / 2;
        // roundPosZ = MathPaskapytty.Round(transform.position.z * 2, MidpointRounding.AwayFromZero) / 2;
    }
    
    void Update()
    {
        // if (!isMoving)
        // {
        //     transform.position = new Vector3(roundPosX, transform.position.y, roundPosZ);
        // }
        
        if (isMoving) return;

        if (cForce.force == new Vector3(0f, -9.81f, 0f))
        {
            // Movement input
            if (Input.GetKeyDown(KeyCode.W)) TryRoll(Vector3.right);
            else if (Input.GetKeyDown(KeyCode.A)) TryRoll(Vector3.forward);
            else if (Input.GetKeyDown(KeyCode.S)) TryRoll(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.D)) TryRoll(Vector3.back);
        }

        if (cForce.force == new Vector3(0f, 9.81f, 0f))
        {
            // Movement input
            if (Input.GetKeyDown(KeyCode.W)) TryRoll(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.A)) TryRoll(Vector3.back);
            else if (Input.GetKeyDown(KeyCode.S)) TryRoll(Vector3.right);
            else if (Input.GetKeyDown(KeyCode.D)) TryRoll(Vector3.forward);
        }
    }

    void TryRoll(Vector3 dir)
    {
        if (cForce.force == new Vector3(0f, -9.81f, 0f))
        {
            // Draw the ray in Scene view (red line for debugging)
            Debug.DrawRay(transform.position, dir * checkDistance, Color.red, pVal);

            // Cast a ray forward to check for obstacles
            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, checkDistance))
            {
                // If the thing we hit is a solid collider (not a trigger)
                if (!hit.collider.isTrigger)
                {
                    return; // Stop — don’t roll
                }
            }
        }
        if (cForce.force == new Vector3(0f, 9.81f, 0f))
        {
            // Draw the ray in Scene view (red line for debugging)
            Debug.DrawRay(transform.position, -dir * checkDistance, Color.red, pVal);

            // Cast a ray forward to check for obstacles
            if (Physics.Raycast(transform.position, -dir, out RaycastHit hit, checkDistance))
            {
                // If the thing we hit is a solid collider (not a trigger)
                if (!hit.collider.isTrigger)
                {
                    return; // Stop — don’t roll
                }
            }
        }

        if (cForce.force == new Vector3(0f, -9.81f, 0f))
        {
            var anchor = transform.position + (Vector3.down + dir) * pVal;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
        else if (cForce.force == new Vector3(0f, 9.81f, 0f))
        {
            var anchor = transform.position + (Vector3.down + dir) * nVal;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;
        rb.isKinematic = true; // Prevent physics from interfering during roll

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        rb.isKinematic = false; // Re-enable physics after roll
        isMoving = false;
    }
}
