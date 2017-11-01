using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour {

    public AudioClip goalSound;
    public int playerWhoScores;

    AudioSource audioSource;
    GameManager gameManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PongBall")
        {
            audioSource.PlayOneShot(goalSound, 1f);
            gameManager.AddPoint(playerWhoScores);
            StartCoroutine(GoalHit(1.5f, col));
        }
    }

    IEnumerator GoalHit(float delayTime, Collider2D col)
    {
        yield return new WaitForSeconds(delayTime);

        Destroy(col.gameObject);
    }
}
