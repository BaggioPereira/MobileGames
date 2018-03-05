using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

    Vector2 direction = Vector2.right;
    List<Transform> tail = new List<Transform>();
    bool ate = false;

    public GameSelection gameSel;
    public GameObject gameover;

    public GameObject tailPrefab;
    private Vector2 touchOrigin = -Vector2.one;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
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
                    if (gameSel.pause == false)
                    {
                        SwipeDirection(touchOrigin, myTouch.position);
                    }
                    break;

                case TouchPhase.Ended:
                    break;
            }
            
        }

        // Move in a new Direction?
        if (gameSel.pause == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
                direction = Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow))
                direction = Vector2.down;    // '-up' means 'down'
            else if (Input.GetKey(KeyCode.LeftArrow))
                direction = Vector2.left; // '-right' means 'left'
            else if (Input.GetKey(KeyCode.UpArrow))
                direction = Vector2.up;
        }
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
            ate = true;
            Destroy(collision.gameObject);
        }

        else if(collision.name.Contains("Border"))
        {
            Time.timeScale = 0;
            gameover.SetActive(true);
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
}
