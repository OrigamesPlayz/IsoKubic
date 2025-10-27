using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorNCeilingManager : MonoBehaviour
{
    public GameObject player;
    public GameObject floor;
    public GameObject ceiling;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConstantForce cForce = player.GetComponent<ConstantForce>();

        if (cForce.force == new Vector3(0, -9.81f, 0))
        {
            floor.SetActive(true);
            ceiling.SetActive(false);
        }
        
        if (cForce.force == new Vector3 (0, 9.81f, 0))
        {
            floor.SetActive(false);
            ceiling.SetActive(true);
        }
    }
}
