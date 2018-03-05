using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public int Lives = 3;
    public int Bricks;
    public float ResetDelay = 1.0f;
    public Text LivesText;
    public Text BricksLeft;
    public GameObject GameOver;
    public GameObject YouWon;
    public GameObject BricksPrefab;
    public GameObject Brick;
    public GameObject Paddle;
    public GameObject DeathParticles;
    public static GM instance = null;
    public TextAsset TextFile;
    //string LevelData;
    string[][] LevelData;

    private GameObject ClonePaddle;

    void ReadFile()
    {
        string text = System.IO.File.ReadAllText("Assets/Resources/Level.txt");
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length;

        string[][] levelBase = new string[rows][];
        for(int i = 0; i < lines.Length; i++)
        {
            string[] stringsofline = Regex.Split(lines[i], " ");
            levelBase[i] = stringsofline;
        }
        LevelData = levelBase;
        BuildLevel();
    }
    //Old ReadFile method to get data from .txt file
    /*void ReadFile()
    {
        LevelData = TextFile.text;
        BuildLevel(LevelData);
    }*/

    //Old level building method
    /*void BuildLevel(/*string LevelString)
    {
        float x = -6.3f;
        float y = 6.95f;
        float XSpace = 3.0f;
        float YSpace = -2.0f;
        
        for( int i = 0; i< LevelString.Length; i++)
        {
            switch(LevelString[i])
            {
                case '-':Instantiate(Brick, new Vector3(x, y, 0), Quaternion.identity);
                    x += XSpace;
                    break;

                case '0':
                    x+=XSpace;
                    break;
                case '\n':
                    y += YSpace;
                    x = -6.3f;
                    break;
            }
        }*/

    void BuildLevel()
    {
        float x = -6.3f;
        float y = 6.95f;
        float XSpace = 3.0f;
        float YSpace = -2.0f;

        //for statement currently creates random levels using
        //random number to pick a line for the brick setup
        for( int i = 0; i < 4; i++)
        {
            int randomnumber = Random.Range(0, 4);
            for (int j = 0; j < LevelData[0].Length; j++)
            {
                switch (LevelData[randomnumber][j])
                {
                    case "-":
                        Instantiate(Brick, new Vector3(x, y, 0), Quaternion.identity);
                        x += XSpace;
                        break;

                    case "0":
                        x += XSpace;
                        break;
                }
            }
            y += YSpace;
            x = -6.3f;
        }

        //Create a level as defined by level.txt
        /*for( int i = 0; i < LevelData.Length; i++)
        {
            for ( int j = 0; j < LevelData[0].Length; j++)
            {
                switch(LevelData[i][j])
                {
                    case "-": Instantiate(Brick, new Vector3(x, y, 0), Quaternion.identity);
                        x += XSpace;
                        break;

                    case "0":
                        x += XSpace;
                        break;
                }
            }
            y += YSpace;
            x = -6.3f;
        }*/
    }

    // Use this for initialization
    void Start ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //Old method call for level building
        //ReadFile(LevelData);
        ReadFile();
        Setup();
        Bricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        BricksLeft.text = "Bricks: " + Bricks;
    }

    public void Setup()
    {
        ClonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
        //Instantiate(BricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if(Bricks < 1)
        {
            YouWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", ResetDelay);
        }

        if(Lives<1)
        {
            GameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", ResetDelay);
        }
    }

    void Reset()
    {
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
            // Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void LoseLife()
    {
        Lives--;
        LivesText.text = "Lives: " + Lives;
        Instantiate(DeathParticles, ClonePaddle.transform.position, Quaternion.identity);
        Destroy(ClonePaddle);
        Invoke("SetupPaddle", ResetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        ClonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        Bricks--;
        BricksLeft.text = "Bricks: " + Bricks;
        CheckGameOver();
    }
}
