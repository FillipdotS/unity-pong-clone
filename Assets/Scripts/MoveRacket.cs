using UnityEngine;

public class MoveRacket : MonoBehaviour {

    public float speed = 1200;
    public string axis = "Vertical";

    Rigidbody2D rb2D;

	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        float verticalInput = Input.GetAxisRaw(axis);
        rb2D.velocity = new Vector2(0, verticalInput) * speed * Time.deltaTime;
	}
}
