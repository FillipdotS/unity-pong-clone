using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour {

    public float speed = 1200;
    public string axis = "Vertical";

    Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float verticalInput = Input.GetAxisRaw(axis);
        rb2D.velocity = new Vector2(0, verticalInput) * speed * Time.deltaTime;
	}
}
