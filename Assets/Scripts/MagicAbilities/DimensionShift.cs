using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionShift : MonoBehaviour
{
    [Header("Materials")]
    public Material matPhase;
    public Material matNormal;

    [Header("Settings")]
    public GameObject player;
    public float timeOfPhasing;
    public float cooldown;

    [Header("State")]
    public bool isPhasing;
    public bool cooldownOver;

    private List<BoxCollider> phColliders = new List<BoxCollider>();

    [Header("Miscellaneous")]
    public DimensionShiftG dimensionShiftG;

    void Start()
    {
        cooldownOver = true;

        // Find all GameObjects with the tag "PhaseableWall"
        GameObject[] phWalls = GameObject.FindGameObjectsWithTag("PhaseableWall");

        // Loop through each wall and store its collider
        foreach (GameObject phWall in phWalls)
        {
            BoxCollider phCol = phWall.GetComponent<BoxCollider>();

            if (phCol != null)
                phColliders.Add(phCol);
        }
    }

    void Update()
    {
        // Press J → Phase mode ON (walls become triggers)
        if (Input.GetKeyDown(KeyCode.J) && !isPhasing && cooldownOver && dimensionShiftG.powerCollected)
        {
            isPhasing = true;

            foreach (BoxCollider phCol in phColliders)
                phCol.isTrigger = true;

            cooldownOver = false;
            StartCoroutine(PhasingTime(timeOfPhasing));

            Debug.Log("Phase mode ON");
        }
        else if (!isPhasing)
        {
            // Disable phase mode (make walls solid again)
            foreach (BoxCollider phCol in phColliders)
                phCol.isTrigger = false;
        }
    }

    IEnumerator PhasingTime(float timeOfPhasing)
{
    GameObject[] phWalls = GameObject.FindGameObjectsWithTag("PhaseableWall");
    isPhasing = true;

    // Set phase material
    foreach (GameObject wall in phWalls)
    {
        MeshRenderer rend = wall.GetComponent<MeshRenderer>();
        if (rend != null)
            rend.material = matPhase;
    }

    yield return new WaitForSeconds(timeOfPhasing);

    // Revert to normal material
    foreach (GameObject wall in phWalls)
    {
        MeshRenderer rend = wall.GetComponent<MeshRenderer>();
        if (rend != null)
            rend.material = matNormal;
    }

    isPhasing = false;
    StartCoroutine(PhasingCooldown(cooldown));
}


    IEnumerator PhasingCooldown(float cooldown)
    {
        cooldownOver = false;
        yield return new WaitForSeconds(cooldown);

        cooldownOver = true;
    }
}
