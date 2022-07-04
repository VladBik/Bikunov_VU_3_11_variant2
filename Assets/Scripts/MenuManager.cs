using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    public void Play()
    {
        SceneManager.LoadScene(1);
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        AudioListener.pause = false;

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause1()
    {

        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }


}
