using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    private Rigidbody2D rb;

    public float speed;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Movement();
	}

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");

        if (h != 0)
        {
            rb.velocity = new Vector2(h * speed, 0);
        }
    }
}
