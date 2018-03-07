using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    [HideInInspector]
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

            else if(sceneName == "Colour Switch Flappy" || sceneName == "Colour Switch")
            {
                if (!pause && GameObject.Find("Player") != null)
                {
                    pausePanel.SetActive(true);
                    pause = !pause;
                    Time.timeScale = 0;
                }
            }
        }

        else if(pause && GameObject.Find("Player") == null)
        {
            gameOverPanel.SetActive(true);
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

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pause = !pause;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
    }
}
