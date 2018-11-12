using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    void Start()
    {
       // pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                Pause();
            }
            if (pausePanel.activeInHierarchy)
            {
                Continue();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    public void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //Enable the scripts again
    }
}