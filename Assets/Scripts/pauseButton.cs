using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pausePanel;
    public Transform optionsPanel;
    public Transform audioPanel;


    private bool isPaused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            // PauseScreen();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausePanel.gameObject.activeSelf)
            {
                isPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pausePanel.gameObject.SetActive(false);
                optionsPanel.gameObject.SetActive(false);
                audioPanel.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pausePanel.gameObject.SetActive(true);
                optionsPanel.gameObject.SetActive(false);
                audioPanel.gameObject.SetActive(false);
                isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }

    public void TelaDePause() {
    optionsPanel.gameObject.SetActive(true);
    pausePanel.gameObject.SetActive(false);
    }


}
