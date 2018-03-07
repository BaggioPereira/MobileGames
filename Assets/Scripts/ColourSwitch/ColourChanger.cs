using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour {

    int colourIndex = 0;
    
    SpriteRenderer sr;

    public Color colourCyan;
    public Color colourMagenta;
    public Color colourYellow;
    public Color colourPink;
    public bool cyan, magenta, yellow, pink;

    // Use this for initialization
    void Start ()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetRandomColour(Collider2D collider)
    {
        
        int index = Random.Range(0, 4);
        sr = collider.gameObject.GetComponent<SpriteRenderer>();
        if (colourIndex != index)
        {
            switch (index)
            {
                case 0:
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Magenta";
                    sr.color = colourMagenta;
                    break;

                case 1:
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Cyan";
                    sr.color = colourCyan;
                    break;

                case 2:
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Yellow";
                    sr.color = colourYellow;
                    break;

                case 3:
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Pink";
                    sr.color = colourPink;
                    break;
            }
            colourIndex = index;
        }

        else
        {
            SetRandomColour(collider);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            sr = collider.gameObject.GetComponent<SpriteRenderer>();
            if (cyan || magenta || yellow || pink)
            {

                if (cyan)
                {
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Cyan";
                    sr.color = colourCyan;
                }
                else if (magenta)
                {
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Magenta";
                    sr.color = colourMagenta;
                }
                else if (yellow)
                {
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Yellow";
                    sr.color = colourYellow;
                }
                else if (cyan)
                {
                    collider.GetComponent<ColourSwitchBall>().currentColour = "Pink";
                    sr.color = colourPink;
                }
            }
            else
            {
                SetRandomColour(collider);
            }
            Destroy(gameObject);
        }
    }
}
