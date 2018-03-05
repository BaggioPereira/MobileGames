using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float PaddleSpeed = 1.0f;

    private Vector3 PlayerPos = new Vector3(0, -9.5f, 0);

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float XPos = transform.position.x + (Input.GetAxis("Horizontal") * PaddleSpeed);
        PlayerPos = new Vector3(Mathf.Clamp(XPos, -8.0f, 8.0f), -9.5f, 0f);
        transform.position = PlayerPos;
	}
}
