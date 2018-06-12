using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    private Vector2 currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        currentVelocity = rb.velocity;

        //Temp input command
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Paddle bounce
        if (collision.CompareTag("Paddle"))
        {
            Debug.Log("Paddle coll");
            GameObject paddle = GameObject.Find("Paddle");

            Vector2 paddlePosition = paddle.transform.position;
            Vector2 ballPosition = transform.position;

            Vector2 delta = ballPosition - paddlePosition;
            Vector2 direction = delta.normalized;

            rb.velocity = direction * speed;
            rb.velocity *= -1;
        }

        if (collision.CompareTag("Wall") || collision.CompareTag("Block"))
        {
            Vector2 direction = transform.position - collision.gameObject.transform.position;
            Debug.Log(direction);

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                currentVelocity.y *= -1;
            }
            else
            {
                currentVelocity.x *= -1;
            }

        }
    }
}
