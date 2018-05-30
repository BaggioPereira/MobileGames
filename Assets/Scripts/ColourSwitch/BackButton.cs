using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    [HideInInspector]
    public bool pause = false;
    public GameObject pausePanel, gameOverPanel, shopPanel;

    //[HideInInspector]
    public GameObject[] playerIconsButton;
    public bool[] playerIcons;

    float timeScaleSetting;

    // Use this for initialization
    void Start ()
    {
		DontDestroyOnLoad(this.gameObject);
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

            else if(sceneName == "Game Select")
            {
                SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
            }

            //Enable pause menu in these scenes
            else if(sceneName == "Colour Switch Flappy" || sceneName == "Colour Switch" || sceneName == "Colour Switch Snake" || sceneName == "Colour Switch Bounce" || sceneName == "Colour Switch PingPong")
            {
                if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
                {
                    pausePanel.SetActive(true);
                    pause = !pause;
                    timeScaleSetting = Time.timeScale;
                    Time.timeScale = 0;
                }
            }
        }

        else if(pause && GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
        }
	}


    //Back button commands
    public void Back()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Colour Switch Flappy" || sceneName == "Colour Switch" || sceneName == "Colour Switch Snake" || sceneName == "Colour Switch Bounce" || sceneName == "Colour Switch PingPong")
        {
            if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
            {
                pausePanel.SetActive(true);
                pause = !pause;
                timeScaleSetting = Time.timeScale;
                Time.timeScale = 0;
            }
        }

        else if(sceneName == "Game Select")
        {
            SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
        }

        else if (shopPanel)
        {
            if (shopPanel.activeSelf == true)
            {
                shopPanel.SetActive(false);
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

    public void Shop()
    {
        shopPanel.SetActive(true);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = timeScaleSetting;
        Debug.Log(Time.timeScale);
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

    public void Standard()
    {
        for(int i = 0; i < playerIcons.Length; i++)
        {
            playerIcons[i] = false;
        }
        playerIcons[0] = true;
    }

    public void Square()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            playerIcons[i] = false;
        }
        playerIcons[1] = true;
    }

    public void Skull()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            playerIcons[i] = false;
        }
        playerIcons[2] = true;
    }

    public void Shield()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            playerIcons[i] = false;
        }
        playerIcons[3] = true;
    }

    public void Flame()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            playerIcons[i] = false;
        }
        playerIcons[4] = true;
    }
}
