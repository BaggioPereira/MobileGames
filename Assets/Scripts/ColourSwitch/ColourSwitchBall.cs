using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColourSwitchBall : MonoBehaviour {

    public float jumpForce = 10.0f;

    public Rigidbody2D rb;

    public string currentColour;
    
    private Vector2 touchOrigin = -Vector2.one;

    public float score = 0;

    public Text text;

    public bool flappy;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 0;
	}

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale < 1)
                Time.timeScale = 1;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            switch (myTouch.phase)
            {
                case TouchPhase.Began:
                    touchOrigin = myTouch.position;
                    if(Time.timeScale < 1)
                        Time.timeScale = 1;
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.up * jumpForce;
                    break;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Base" || collider.tag == "ColourChanger")
        {
            return;
        }

        if (collider.tag != currentColour)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        if (collider.tag == currentColour)
        {
            score++;
            text.text = "Score : " + score;
            if (flappy)
            {
                ColourChanger changer = FindObjectOfType<ColourChanger>();
                changer.SetRandomColour(gameObject.GetComponent<Collider2D>());
            }
        }

    }
}
