using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

    public float speed = 300;

    Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();

        rb2D.velocity = Vector2.right * speed * Time.deltaTime;
	}

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Racket")
        {
            float yFactor = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            float xFactor = 1;
            if (col.gameObject.name == "Racket_Right")
            {
                xFactor = -1;
            }
            else if (col.gameObject.name == "Racket_Left") {
                xFactor = 1;
            }

            Vector2 dir = new Vector2(xFactor, yFactor).normalized;

            rb2D.velocity = dir * speed * Time.deltaTime;
        } 
	}
}
