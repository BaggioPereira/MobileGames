using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColourSwitchBall : MonoBehaviour {

    public float jumpForce = 10.0f;

    int colourIndex = 0;

    public Rigidbody2D rb;

    public string currentColour;
    
    private Vector2 touchOrigin = -Vector2.one;

    // Use this for initialization
    void Start ()
    {
        
	}

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            switch (myTouch.phase)
            {
                case TouchPhase.Began:
                    touchOrigin = myTouch.position;
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.up * jumpForce;
                    break;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Base")
        {
            return;
        }

        if (collider.tag == "ColourChanger")
        {
            return;
        }


        if (collider.tag != currentColour)
        {
            SceneManager.LoadScene("Color Switch");
        }

    }
}
