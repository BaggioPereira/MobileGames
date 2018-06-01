using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class BackButton : MonoBehaviour {

    //[HideInInspector]
    public bool pause = false;
    public GameObject overlayPortrait, overlayLandscape, pausePanelPortrait, pausePanelLandscape, gameOverPanelPortrait, gameOverPanelLandscape, shopPanel;

    //[HideInInspector]
    public GameObject[] playerIconsButton;
    public bool[] playerIcons, sceneActive;

    public GameObject[] scenes;

    float timeScaleSetting;

    public TextMeshProUGUI col;

    GameObject GameInstance;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < playerIcons.Length; i++)
            if (i == PlayerPrefs.GetInt("Icon"))
                playerIcons[i] = true;

        col.text = PlayerPrefs.GetInt("Collection").ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		//if(Input.GetKeyUp(KeyCode.Escape))
  //      {
  //          string sceneName = SceneManager.GetActiveScene().name;

  //          if(sceneName == "Colour Switch Menu")
  //          {
  //              Application.Quit();
  //          }

  //          else if(sceneName == "Game Select")
  //          {
  //              SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
  //          }

  //          //Enable pause menu in these scenes
  //          else if(sceneName == "Colour Switch Flappy" || sceneName == "Colour Switch" || sceneName == "Colour Switch Snake" || sceneName == "Colour Switch Bounce" || sceneName == "Colour Switch PingPong")
  //          {
  //              if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
  //              {
  //                  pausePanelPortrait.SetActive(true);
  //                  pause = !pause;
  //                  timeScaleSetting = Time.timeScale;
  //                  Time.timeScale = 0;
  //              }
  //          }
  //      }
        for(int i = 0; i < sceneActive.Length; i++)
        {
            if (i == 3 || i == 6 || i == 7)
            {
                if (pause && GameObject.FindGameObjectWithTag("Player") == null)
                {
                    gameOverPanelPortrait.SetActive(true);
                }
            }
            else if( i == 4 || i == 5)
            {
                if (pause && GameObject.FindGameObjectWithTag("Player") == null)
                {
                    gameOverPanelLandscape.SetActive(true);
                }
            }
        }

        
    }


    //Back button commands
    public void Back()
    {

        for(int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i].name == "GameSelectCanvas")
            {
                if (sceneActive[2] == true)
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
            }
        }

        if (sceneActive[3] == true || sceneActive[6] == true || sceneActive[7] == true)
        {
            if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
            {
                pausePanelPortrait.SetActive(true);
                pause = !pause;
                timeScaleSetting = Time.timeScale;
                Time.timeScale = 0;
            }
        }

        if(sceneActive[4] == true || sceneActive[5] == true)
        {
            if (!pause && GameObject.FindGameObjectWithTag("Player") != null)
            {
                pausePanelLandscape.SetActive(true);
                pause = !pause;
                timeScaleSetting = Time.timeScale;
                Time.timeScale = 0;
            }
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
            sceneActive[i] = false;
            if (scenes[i].name == "GameSelectCanvas")
            {
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }
        }
    }

    public void Classic()
    {
        //SceneManager.LoadScene("Colour Switch", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            sceneActive[i] = false;
            if (scenes[i].name == "ColourSwitchCanvas")
            {
                GameInstance = Instantiate(scenes[i], new Vector3(0, -1.75f, 0), Quaternion.identity);
                GameInstance.SetActive(true);
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }
            
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
            sceneActive[i] = false;
            if (scenes[i].name == "FlappyCanvas")
            {
                GameInstance = Instantiate(scenes[i], Vector3.zero, Quaternion.identity);
                GameInstance.SetActive(true);
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }

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
            sceneActive[i] = false;
            if (scenes[i].name == "SnakeCanvas")
            {
                GameInstance = Instantiate(scenes[i], Vector3.zero, Quaternion.identity);
                GameInstance.SetActive(true);
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }

            overlayPortrait.SetActive(false);
            overlayLandscape.SetActive(true);
            overlayLandscape.transform.localScale = new Vector3(0.047f, 0.047f, 0.047f);
        }
    }

    public void Bounce()
    {
        //SceneManager.LoadScene("Colour Switch Bounce", LoadSceneMode.Single);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            sceneActive[i] = false;
            if (scenes[i].name == "BounceCanvas")
            {
                GameInstance = Instantiate(scenes[i], new Vector3(0, -1.75f, 0), Quaternion.identity);
                GameInstance.SetActive(true);
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }

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
            sceneActive[i] = false;
            if (scenes[i].name == "PingPongCanvas")
            {
                GameInstance = Instantiate(scenes[i], new Vector3(0, -1.75f, 0), Quaternion.identity);
                GameInstance.SetActive(true);
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }

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
        if (overlayPortrait.active == true)
        {
            pausePanelPortrait.SetActive(false);
            Time.timeScale = timeScaleSetting;
            Debug.Log(Time.timeScale);
            pause = !pause;
        }

        else if(overlayLandscape == true)
        {
            pausePanelLandscape.SetActive(false);
            Time.timeScale = timeScaleSetting;
            Debug.Log(Time.timeScale);
            pause = !pause;
        }
    }

    public void Restart()
    {
        Destroy(GameInstance);
        pause = !pause;

        for(int i = 0; i < sceneActive.Length; i++)
        {
            if(sceneActive[i] == true)
            {
                if( i == 3)
                {
                    Classic();
                    gameOverPanelPortrait.SetActive(false);
                }
                else if( i == 4)
                {
                    Flappy();
                    gameOverPanelLandscape.SetActive(false);
                }
                else if (i == 5)
                {
                    Snake();
                    gameOverPanelLandscape.SetActive(false);
                }
                else if (i == 6)
                {
                    Bounce();
                    gameOverPanelPortrait.SetActive(false);
                }
                else if (i == 7)
                {
                    PingPong();
                    gameOverPanelPortrait.SetActive(false);
                }
            }
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        //if (SceneManager.GetActiveScene().name == "Colour Switch Bounce")
        //    Time.timeScale = 1;
    }

    public void Quit()
    {
        pause = !pause;
        pausePanelPortrait.SetActive(false);
        pausePanelLandscape.SetActive(false);
        gameOverPanelPortrait.SetActive(false);
        gameOverPanelLandscape.SetActive(false);
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            sceneActive[i] = false;
            if (scenes[i].name == "MenuCanvas")
            {
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }
            if (scenes[i].name == "GOCanvas")
            {
                scenes[i].SetActive(true);
                sceneActive[i] = true;
            }
        }
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
        Destroy(GameInstance);
        overlayPortrait.transform.parent.position = Vector3.zero;
        overlayLandscape.transform.localScale = new Vector3(0.009130585f, 0.009130585f, 0.009130585f);
        overlayPortrait.SetActive(false);
        overlayLandscape.SetActive(false);
        Time.timeScale = 1;
        //if (SceneManager.GetActiveScene().name == "Colour Switch Menu")
        //    Application.Quit();

        //else
        //    SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
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
            {
                playerIcons[i] = true;
                PlayerPrefs.SetInt("Icon", i);
            }
            else
            {
                playerIconsButton[i].GetComponent<Locked>().isLocked = true;
                playerIconsButton[i].GetComponent<Locked>().Unlock();
                playerIcons[i] = false;
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
                PlayerPrefs.SetInt("Icon", i);
            }
        }

        else if (!playerIconsButton[i].GetComponent<Locked>().isLocked)
        {
            playerIcons[i] = true;
            PlayerPrefs.SetInt("Icon", i);
        }
    }
}
