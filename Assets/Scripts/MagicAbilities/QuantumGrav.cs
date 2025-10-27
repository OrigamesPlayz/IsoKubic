using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumGrav : MonoBehaviour
{
    public GameObject player;
    public QuantumGravG quantumGravG;
    private ConstantForce cForce;
    public Vector3 forceDir;
    public float cooldown;
    public bool abilityReady;
    public GameObject gravityEffect;

    void Start()
    {
        cForce = player.GetComponent<ConstantForce>();
        forceDir = new Vector3(0, -9.81f, 0);
        cForce.force = forceDir;
        abilityReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        gravityEffect.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.G) && abilityReady == true && quantumGravG.powerCollected)
        {
            StartCoroutine(GravityEffect());
            StartCoroutine(GraviCooldown(cooldown));
            forceDir = forceDir * -1;
            cForce.force = forceDir;
        }

        else if (abilityReady == false)
        {
            return;
        }
    }

    IEnumerator GraviCooldown(float cooldown)
    {
        abilityReady = false;

        yield return new WaitForSeconds(cooldown);

        abilityReady = true;
    }

    IEnumerator GravityEffect()
    {
        gravityEffect.SetActive(true);
        yield return new WaitForSeconds(0.63f);
        gravityEffect.SetActive(false);
    }
}
