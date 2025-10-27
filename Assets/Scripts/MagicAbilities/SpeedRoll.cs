using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRoll : MonoBehaviour
{
    public GameObject player;
    public SpeedRollG speedRollG;
    public float cooldown;
    public bool cooldownOver;
    public bool isSpeedRolling;
    public GameObject lightningAura;
    public GameObject lightningAuraStart;
    public GameObject lightningAuraShot;

    void Start()
    {
        cooldownOver = true;
    }
    // Update is called once per frame
    void Update()
    {
        lightningAuraStart.transform.rotation = Quaternion.Euler(0, 0, 0);
        lightningAuraShot.transform.rotation = Quaternion.Euler(0, 0, 0);
        CubeController cCon = player.GetComponent<CubeController>();

        if (Input.GetKeyDown(KeyCode.L) && cooldownOver == true && isSpeedRolling == false && speedRollG.powerCollected)
        {
            StartCoroutine(SpeedRolling());
            RotationReset();
        }
    }

    IEnumerator SpeedRolling()
    {
        CubeController cCon = player.GetComponent<CubeController>();
        isSpeedRolling = true;
        cooldownOver = false;
        cCon.rollSpeed = cCon.rollSpeed + 2;
        lightningAuraStart.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        lightningAuraStart.SetActive(false);
        lightningAura.SetActive(true);
        lightningAuraShot.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        lightningAuraShot.SetActive(false);
        RotationReset();
        yield return new WaitForSeconds(3.85f);
        cCon.rollSpeed = cCon.rollSpeed - 2;
        lightningAura.SetActive(false);
        lightningAuraStart.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lightningAuraStart.SetActive(false);
        RotationReset();
        StartCoroutine(AbilityCooldown());
    }

    IEnumerator AbilityCooldown()
    {
        RotationReset();
        yield return new WaitForSeconds(5);
        cooldownOver = true;
        isSpeedRolling = false;
    }

    private void RotationReset()
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.MoveRotation(Quaternion.Euler(0, 0, 0));
    }
}
