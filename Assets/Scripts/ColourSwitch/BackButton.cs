using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    //[HideInInspector]
    public bool pause = false;
    public GameObject pausePanel, gameOverPanel;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Escape))
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if(sceneName == "Colour Switch Menu")
            {
                Application.Quit();
            }

            else if(sceneName == "Colour Switch Flappy" || sceneName == "Colour Switch" || sceneName == "Colour Switch Snake" || sceneName == "Colour Switch Bounce")
            {
                if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
                {
                    pausePanel.SetActive(true);
                    pause = !pause;
                    Time.timeScale = 0;
                }
            }
        }

        else if(pause && GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
        }
	}

    public void Back()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Colour Switch Flappy" || sceneName == "Colour Switch" || sceneName == "Colour Switch Snake" || sceneName == "Colour Switch Bounce")
        {
            if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
            {
                pausePanel.SetActive(true);
                pause = !pause;
                Time.timeScale = 0;
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game Select", LoadSceneMode.Single);
    }

    public void Classic()
    {
        SceneManager.LoadScene("Colour Switch", LoadSceneMode.Single);
    }

    public void Flappy()
    {
        SceneManager.LoadScene("Colour Switch Flappy", LoadSceneMode.Single);
    }

    public void Snake()
    {
        SceneManager.LoadScene("Colour Switch Snake", LoadSceneMode.Single);
    }

    public void Bounce()
    {
        SceneManager.LoadScene("Colour Switch Bounce", LoadSceneMode.Single);
    }

    public void PingPong()
    {
        SceneManager.LoadScene("Colour Switch PingPong", LoadSceneMode.Single);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pause = !pause;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        if (SceneManager.GetActiveScene().name == "Colour Switch Bounce")
            Time.timeScale = 1;
    }

    public void Quit()
    {
        if (SceneManager.GetActiveScene().name == "Colour Switch Menu")
            Application.Quit();

        else
            SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
    }
}
