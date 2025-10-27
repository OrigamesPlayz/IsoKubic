using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAPLEPOWER : MonoBehaviour
{
    public CubeController cCon;
    public GameObject mapleLeaf;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && mapleLeaf != null)
        {
            Destroy(mapleLeaf);
            cCon.rollSpeed = cCon.rollSpeed * 10;
            StartCoroutine(INSANEMAPLEPOWER());
        }
    }

    IEnumerator INSANEMAPLEPOWER()
    {
        yield return new WaitForSeconds(15);
        cCon.rollSpeed = cCon.rollSpeed / 10;
    }
}
