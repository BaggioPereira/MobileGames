using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float BallInitialVelocity = 600.0f;

    private Rigidbody rb;
    private bool BallInPlay;

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Fire1") && BallInPlay == false)
        {
            transform.parent = null;
            BallInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(BallInitialVelocity, BallInitialVelocity, 0.0f));
        }
	}
}
