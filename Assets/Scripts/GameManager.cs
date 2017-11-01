using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject pongBallPrefab;
    public Text playerOneUI;
    public Text playerTwoUI;
    public Text startText;
    public Image gameOverPanel;
    public int winningScore = 10;
    [HideInInspector]
    public int lastPlayerWhoScored; // Used to determine which side the ball should go to

    int playerOneScore = 0;
    int playerTwoScore = 0;
    bool gameOver = true;

    // Use this for initialization
    void Start () {
        playerOneUI.text = playerOneScore.ToString();
        playerTwoUI.text = playerTwoScore.ToString();

        // Random player for starting side
        lastPlayerWhoScored = Random.Range(1, 3);
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown("space"))
            {
                // Could be better implemented
                startText.enabled = false;

                RestartGame();
            }
        }
    }

    void GameOverCheck()
    {
        if (playerOneScore == winningScore || playerTwoScore == winningScore)
        {
            GameOver();
        }
        else
        {
            Invoke("AddNewBall", 2f);
        }
    }

    void RestartGame()
    {
        Debug.Log("Restarting game.");
        gameOver = false;
        gameOverPanel.gameObject.SetActive(false);
        playerOneScore = playerTwoScore = 0;
        playerOneUI.text = playerTwoUI.text = "0";
        AddNewBall();
    }

    void GameOver()
    {
        Debug.Log("Game over");
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);
    }

    // This is called by the Goal script by the Goal_Left/Right game objects
    public void AddPoint(int playerID)
    {
        lastPlayerWhoScored = playerID;

        if (playerID == 1)
        {
            playerOneScore++;
            playerOneUI.text = playerOneScore.ToString();
        }
        else if (playerID == 2)
        {
            playerTwoScore++;
            playerTwoUI.text = playerTwoScore.ToString();
        }
        else
        {
            Debug.LogWarning("AddPoint called with an invalid playerID: " + playerID.ToString());
        }

        GameOverCheck();
    }

    void AddNewBall()
    {
        Instantiate(pongBallPrefab as GameObject);
    }
}
