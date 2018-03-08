using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

    Vector2 direction = Vector2.right;
    List<Transform> tail = new List<Transform>();

    [HideInInspector]
    public bool ate = false;

    BackButton back;

    public GameObject tailPrefab;
    private Vector2 touchOrigin = -Vector2.one;
    public string currentColour;

    public Color[] colours;
    public Text text;
    int score = 0;

    // Use this for initialization
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
        Time.timeScale = 1;
        back = FindObjectOfType<BackButton>();
        SnakeColourChange();
        InvokeRepeating("Move", 0.3f, 0.3f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            switch (myTouch.phase)
            {
                case TouchPhase.Began:
                    touchOrigin = myTouch.position;
                    break;

                case TouchPhase.Moved:
                    SwipeDirection(touchOrigin, myTouch.position);
                    break;

                case TouchPhase.Ended:
                    break;
            }
            
        }

        // Move in a new Direction?
        if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = Vector2.down;    // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction = Vector2.left; // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow))
            direction = Vector2.up;
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(direction);
        if(ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            tail.Insert(0, g.transform);
            ate = false;
        }
        else if(tail.Count > 0)
        {
            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.StartsWith("FoodPrefab"))
        {
            if (collision.tag == currentColour)
            {
                ate = true;
                score++;
                text.text = "Score : " + score;
                Destroy(collision.gameObject);
                SnakeColourChange();
            }

            else
            {
                Time.timeScale = 0;
                back.pause = true;
                Destroy(gameObject);
            }
        }

        else if(collision.name.Contains("Border") || collision.name.Contains("Tail"))
        {
            Time.timeScale = 0;
            back.pause = true;
            Destroy(gameObject);
            //SceneManager.LoadScene("Snake");
        }
    }

    void SwipeDirection(Vector2 begin, Vector2 end)
    {

        if(Mathf.Abs(end.x - begin.x) > 100 || Mathf.Abs(end.y - begin.y) > 100)
        {
            if (Mathf.Abs(end.x - begin.x) > Mathf.Abs(end.y - begin.y))
            {
                if (end.x > begin.x)
                {
                    if (direction == Vector2.left)
                    {
                    }
                    else
                    {
                        direction = Vector2.right;
                    }
                }
                else
                {
                    if (direction == Vector2.right)
                    {
                    }
                    else
                    {
                        direction = Vector2.left;
                    }
                }
            }

            else
            {
                if (end.y > begin.y)
                {
                    if (direction == Vector2.down)
                    {
                    }
                    else
                    {
                        direction = Vector2.up;
                    }
                }
                else
                {
                    if (direction == Vector2.right)
                    {
                    }
                    else
                    {
                        direction = Vector2.down;
                    }
                }
            }
        }
    }

    void SnakeColourChange()
    {
        int colour = Random.Range(0, colours.Length);
        gameObject.GetComponent<Renderer>().material.color = colours[colour];
        if (colour == 0)
            currentColour = "Cyan";
        if (colour == 1)
            currentColour = "Yellow";
        if (colour == 2)
            currentColour = "Pink";
        if (colour == 3)
            currentColour = "Magenta";
    }
}
