using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseScreen;

    void Start()
    {
        DontDestroyOnLoad(this);  
    }

    public void PauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void UnpauseGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public bool IsGamePaused()
    {
        return !(Time.timeScale > 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MoveToMainMenu()
    {

    }

    public void MoveToGame()
    {

    }

    private void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(IsGamePaused())
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
