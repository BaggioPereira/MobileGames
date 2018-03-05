using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour {
    
    public bool pause = false;
    
    public Object game;

    public void Snake()
    {
        SceneManager.LoadScene("SnakeMenu", LoadSceneMode.Single);
    }

    public void BasketBall()
    {
        SceneManager.LoadScene("BasketBallMenu", LoadSceneMode.Single);
    }

    public void FlappyBird()
    {
        SceneManager.LoadScene("FlappyBirdMenu", LoadSceneMode.Single);
    }

    public void Breakout()
    {
        SceneManager.LoadScene("BreakoutMenu", LoadSceneMode.Single);
    }

    public void Pause()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(game.name, LoadSceneMode.Single);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}