using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscControl : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject paused1;
    public GameObject paused2;
    public Transform canvas;
    public GameObject player;
    public GameObject mpm;
    // Start is called before the first frame update
    void Start()
    {
        paused1.transform.SetParent(canvas);
        paused1.SetActive(false);
        paused2.transform.SetParent(canvas);
        paused2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        ShowMenu();
    }

    private void Pause()
    {
        CubeController cCon = player.GetComponent<CubeController>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused == true)
            {
                mpm.SetActive(false);
                cCon.enabled = false;
                Time.timeScale = 0;
                paused1.SetActive(true);
                paused2.SetActive(true);
            }
        }

        if (isPaused == false)
        {
            Time.timeScale = 1;
            cCon.enabled = true;
            mpm.SetActive(true);
            paused1.SetActive(false);
            paused2.SetActive(false);
        }
    }

    private void ShowMenu()
    {
        if (isPaused == false)
        {
            paused1.SetActive(false);
            paused2.SetActive(false);
        }
    }
}
