using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOperation : MonoBehaviour {
    public Canvas Main;
    public Canvas HighScore;
    public Canvas PlayGame;

    public void Play()
    {
        Main.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(false);
        PlayGame.gameObject.SetActive(true);
    }

    public void High()
    {
        Main.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(true);
        PlayGame.gameObject.SetActive(false);
    }

    public void Back()
    {
        Main.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(false);
        PlayGame.gameObject.SetActive(false);
    }
}
