using UnityEngine;

public class PongBall : MonoBehaviour {

    // Sounds
    public AudioClip wallBounceSound;

    public float speed = 300;

    GameManager gameManager;
    AudioSource audioSource;
    Rigidbody2D rb2D;

    // The pong ball responds differently depending on which part of the racket it hits,
    // which is why hitFactor is a method

	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        int xVector = gameManager.lastPlayerWhoScored == 1 ? -1 : 1; 
        rb2D.velocity = new Vector2(xVector, Random.Range(-0.7f, 0.7f)) * speed * Time.deltaTime;
	}

    // Calculates the Y part of the Vector2 that will applied upon hitting a racket
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D (Collision2D col) {
        audioSource.PlayOneShot(wallBounceSound, 1f);

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
