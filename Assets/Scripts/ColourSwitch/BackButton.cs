using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class BackButton : MonoBehaviour {

    [HideInInspector]
    public bool pause = false;
    public GameObject overlayPortrait, overlayLandscape, pausePanelPortrait, pausePanelLandscape, gameOverPanelPortrait, gameOverPanelLandscape, shopPanel;

    //[HideInInspector]
    public GameObject[] playerIconsButton;
    public bool[] playerIcons;

    public GameObject[] scenes;

    float timeScaleSetting;

    public TextMeshProUGUI col;

    // Use this for initialization
    void Start()
    {
        if (playerIcons.Length > 1)
            playerIcons[0] = true;

        col.text = PlayerPrefs.GetInt("Collection").ToString();
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
                    pausePanelPortrait.SetActive(true);
                    pause = !pause;
                    timeScaleSetting = Time.timeScale;
                    Time.timeScale = 0;
                }
            }
        }

        else if(pause && GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanelPortrait.SetActive(true);
        }
	}


    //Back button commands
    public void Back()
    {
        //string sceneName = SceneManager.GetActiveScene().name;
        //if (sceneName == "Colour Switch Flappy" || sceneName == "Colour Switch" || sceneName == "Colour Switch Snake" || sceneName == "Colour Switch Bounce" || sceneName == "Colour Switch PingPong")
        //{
        //    if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
        //    {
        //        pausePanel.SetActive(true);
        //        pause = !pause;
        //        timeScaleSetting = Time.timeScale;
        //        Time.timeScale = 0;
        //    }
        //}

        //else if(sceneName == "Game Select")
        //{
        //    SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
        //}

        for(int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i].name == "GameSelectCanvas")
            {
                for (int j = 0; j < scenes.Length; j++)
                {
                    scenes[j].SetActive(false);
                    if (scenes[j].name == "MenuCanvas")
                        scenes[j].SetActive(true);
                    if (scenes[j].name == "GOCanvas")
                        scenes[j].SetActive(true);
                }
            }

            //if(scenes[i].name == "ColourSwitchCanvas" || scenes[i].name == "BounceCanvas" || scenes[i].name == "PingPongCanvas")
            //{
            //    overlayPortrait.SetActive(true);
            //    overlayLandscape.SetActive(false);
            //}

            //else if (scenes[i].name == "SnakeCanvas" || scenes[i].name == "FlappyCanvas")
            //{
            //    overlayPortrait.SetActive(false);
            //    overlayLandscape.SetActive(true);
            //}
        }

        if (shopPanel)
        {
            if (shopPanel.activeSelf == true)
            {
                shopPanel.SetActive(false);
            }
        }
    }

    public void Play()
    {
        //SceneManager.LoadScene("Game Select", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            if (scenes[i].name == "GameSelectCanvas")
                scenes[i].SetActive(true);
        }
    }

    public void Classic()
    {
        //SceneManager.LoadScene("Colour Switch", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            if (scenes[i].name == "ColourSwitchCanvas")
                scenes[i].SetActive(true);

            overlayPortrait.SetActive(true);
            overlayLandscape.SetActive(false);
        }
    }

    public void Flappy()
    {
        //SceneManager.LoadScene("Colour Switch Flappy", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            if (scenes[i].name == "FlappyCanvas")
                scenes[i].SetActive(true);

            overlayPortrait.SetActive(false);
            overlayLandscape.SetActive(true);
        }
    }

    public void Snake()
    {
        //SceneManager.LoadScene("Colour Switch Snake", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            if (scenes[i].name == "SnakeCanvas")
                scenes[i].SetActive(true);

            overlayPortrait.SetActive(false);
            overlayLandscape.SetActive(true);
        }
    }

    public void Bounce()
    {
        //SceneManager.LoadScene("Colour Switch Bounce", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            if (scenes[i].name == "BounceCanvas")
                scenes[i].SetActive(true);

            overlayPortrait.SetActive(true);
            overlayLandscape.SetActive(false);
        }
    }

    public void PingPong()
    {
        //SceneManager.LoadScene("Colour Switch PingPong", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            if (scenes[i].name == "PingPongCanvas")
                scenes[i].SetActive(true);

            overlayPortrait.SetActive(true);
            overlayLandscape.SetActive(false);
        }
    }

    public void Shop()
    {
        shopPanel.SetActive(true);
    }

    public void Resume()
    {
        pausePanelPortrait.SetActive(false);
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
            if (playerIconsButton[i].name == "Standard")
                playerIcons[i] = true;
            else
                playerIcons[i] = false;
        }
    }

    public void Square()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (playerIconsButton[i].name == "SquareLock")
                UnlockIcon(i);
            else
                playerIcons[i] = false;
        }
    }

    public void Skull()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (playerIconsButton[i].name == "SkullLock")
                UnlockIcon(i);
            else
                playerIcons[i] = false;
        }
    }

    public void Shield()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (playerIconsButton[i].name == "ShieldLock")
                UnlockIcon(i);
            else
                playerIcons[i] = false;
        }
    }

    public void Flame()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (playerIconsButton[i].name == "FlameLock")
                UnlockIcon(i);
            else
                playerIcons[i] = false;
        }
    }

    public void DeleteAllSavedData()
    {
        PlayerPrefs.DeleteAll();
        col.text = PlayerPrefs.GetInt("Collection").ToString();
        for(int i = 0; i < playerIconsButton.Length; i++)
        {
            if (playerIconsButton[i].name == "Standard")
                playerIcons[i] = true;
            else
            {
                playerIconsButton[i].GetComponent<Locked>().isLocked = true;
                playerIconsButton[i].GetComponent<Locked>().Unlock();
            }
        }
    }
    
    void UnlockIcon(int i)
    {
        if (playerIconsButton[i].GetComponent<Locked>().isLocked)
        {
            if (PlayerPrefs.GetInt("Collection") >= Convert.ToInt32(playerIconsButton[i].transform.Find("PointsNeeded").GetComponent<TextMeshProUGUI>().text))
            {
                Debug.Log(Convert.ToInt32(playerIconsButton[i].transform.Find("PointsNeeded").GetComponent<TextMeshProUGUI>().text));
                PlayerPrefs.SetInt("Collection", PlayerPrefs.GetInt("Collection") - Convert.ToInt32(playerIconsButton[i].transform.Find("PointsNeeded").GetComponent<TextMeshProUGUI>().text));
                col.text = PlayerPrefs.GetInt("Collection").ToString();
                playerIconsButton[i].GetComponent<Locked>().isLocked = false;
                playerIconsButton[i].GetComponent<Locked>().Unlock();
                playerIcons[i] = true;
            }
        }

        else if (!playerIconsButton[i].GetComponent<Locked>().isLocked)
        {
            playerIcons[i] = true;
        }
    }
}
