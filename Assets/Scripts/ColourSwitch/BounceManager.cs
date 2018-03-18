using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceManager : MonoBehaviour {

    public GameObject Cube;
    public GameObject InitalChanger;
    private Vector2 touchOrigin = -Vector2.one;
    BackButton back;
    public float score = 0;

    public Text text;

    float width;
    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
        back = FindObjectOfType<BackButton>();
        if (InitalChanger != null)
            Time.timeScale = 0;
        width = Screen.width;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            if (!back.pause)
                if (Time.timeScale < 1)
                    Time.timeScale = 1;
            if (!back.pause)
            {
                if (Input.mousePosition.x > width / 2)
                    Cube.transform.Rotate(new Vector3(0, 0, 1), 90);
                else
                    Cube.transform.Rotate(new Vector3(0, 0, 1), -90);
            }
        }

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            switch (myTouch.phase)
            {
                case TouchPhase.Began:
                    touchOrigin = myTouch.position;
                    if (!back.pause)
                        if (Time.timeScale < 1)
                            Time.timeScale = 1;
                    break;

                case TouchPhase.Ended:
                    if (!back.pause)
                    {
                        if (touchOrigin.x > width / 2)
                            Cube.transform.Rotate(new Vector3(0, 0, 1), 90);
                        else
                            Cube.transform.Rotate(new Vector3(0, 0, 1), -90);
                    }
                    break;
            }

        }
    }

    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.tag == "Base" || collider.tag == "ColourChanger")
    //    {
    //        return;
    //    }

    //    if (collider.gameObject.tag != currentColour)
    //    {
    //        Time.timeScale = 0;
    //        back.pause = true;
    //        Destroy(gameObject);
    //    }

    //    if (collider.gameObject.tag == currentColour)
    //    {
    //        ColourChanger changer = FindObjectOfType<ColourChanger>();
    //        changer.SetRandomColour(gameObject.GetComponent<Collider2D>());
    //        score++;
    //        text.text = "Score : " + score;
    //    }
    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Bounce")
    //    {
    //        return;
    //    }
    //}
}
