using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;

public class ColourSwitchBall : MonoBehaviour {

    #if UNITY_IOS
    private string gameID = "1727075";
    #elif UNITY_ANDROID
    private string gameID = "1727074";
    #endif

    public GameObject Cube;
    public float jumpForce = 10.0f;

    public Rigidbody2D rb;

    public string currentColour;
    public int currentColourInt;
    
    private Vector2 touchOrigin = -Vector2.one;

    public int score = 0;

    public TextMeshProUGUI text;

    public bool flappy;
    public bool pingpong;
    public bool bounce;

    BackButton back;
    public float direction = 0.5f;

    float width;



    // Use this for initialization
    void Start ()
    {
        Advertisement.Initialize(gameID);
        back = FindObjectOfType<BackButton>();
        //Debug.Log("Found");
        score = PlayerPrefs.GetInt("Collection");
        score = 4000;
        text.text = score.ToString();
        width = Screen.width;
        GetPlayerIcon();
        Debug.Log(PlayerPrefs.GetInt("Collection"));
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            if (!back.pause)
                if (Time.timeScale < 1)
                    Time.timeScale = 1;
            if (pingpong)
            {
                rb.velocity = new Vector2(direction, 1) * jumpForce;
            }
            else if (bounce)
            {
                if (Input.mousePosition.x > width / 2)
                    Cube.transform.Rotate(new Vector3(0, 0, 1), 90);
                else
                    Cube.transform.Rotate(new Vector3(0, 0, 1), -90);
            }

            else
            {
                rb.velocity = Vector2.up * jumpForce;
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Base" || collider.tag == "ColourChanger")
        {
            return;
        }

        if (collider.tag == "Point")
        {
            score++;
            text.text = score.ToString();
            Destroy(collider.gameObject);
            return;
        }

        if (collider.tag != currentColour)
        {
            Time.timeScale = 0;
            Advertisement.Show();
            back.pause = true;
            PlayerPrefs.SetInt("Collection", score);
            //Debug.Log("Saved");
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            
        }

        if (collider.tag == currentColour)
        {

            if (flappy || pingpong || bounce)
            {
                ColourChanger changer = FindObjectOfType<ColourChanger>();
                changer.SetRandomColour(gameObject.GetComponent<Collider2D>());
                score++;
                text.text = score.ToString();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Direction")
            if(pingpong)
            {
                direction = -direction;
                //Debug.Log(direction);
                rb.velocity = new Vector2(direction, 1) * jumpForce;
            }
    }

    void GetPlayerIcon()
    {
        int index = 0;
        for(int i = 0; i < back.playerIcons.Length; i++)
        {
            if (back.playerIcons[i] == true)
                index = i;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = back.playerIconsButton[index].transform.GetChild(0).GetComponent<Image>().sprite;
    }
}
