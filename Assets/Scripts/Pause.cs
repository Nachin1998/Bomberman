using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    bool pauseMenuActive;

    private void Start()
    {
        pauseMenuActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuActive)
            {
                pauseMenuActive = false;
            }
            else
            {
                pauseMenuActive = true;
            }
        }

        if (pauseMenuActive)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseMenuActive = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        pauseMenuActive = true;
    }
}
