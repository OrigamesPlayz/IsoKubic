using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFollow : MonoBehaviour
{
    public Transform player;
    public ConstantForce cForce;
    void Update()
    {
        transform.position = player.position;
        transform.localScale = player.localScale / 10;
    }
}
