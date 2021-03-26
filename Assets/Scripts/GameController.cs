using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int playerScore;
    private CapsuleCollider2D addScoreTrigger;
    private CapsuleCollider2D resetScoreTrigger;
    private BallController ballController;

    [SerializeField]
    private Text scoreCard;
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private Transform SpawnPosition;
    [SerializeField]
    private Button lobbyButton;
    [SerializeField]
    private GameObject scoreObject;
    private ScoreBoardEntryData entryData;
    private ScoreController scoreController;


    void Start()
    {
        ballController = SpawnBall();
        var colliders = gameObject.GetComponents<CapsuleCollider2D>();
        addScoreTrigger = colliders[0];
        resetScoreTrigger = colliders[1];
        scoreController = scoreObject.GetComponent<ScoreController>();
        lobbyButton.onClick.AddListener(OnClick);
    }

    private BallController SpawnBall()
    {
        GameObject Ball = Instantiate(ballPrefab, SpawnPosition.position, Quaternion.identity);
        BallController ballController = Ball.GetComponent<BallController>();
        return ballController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BallController>() != null && collision.IsTouching(addScoreTrigger))
        {
            if (ballController.isBallThrown)
            {
                playerScore += 1;
                UpdateScore();
                entryData.entryScore = playerScore;
                scoreController.AddEntry(entryData);
            }
        }
        if (collision.gameObject.GetComponent<BallController>() != null && collision.IsTouching(resetScoreTrigger))
        {
            if (ballController.isBallThrown)
            {
                playerScore = 0;
                UpdateScore();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BallController>() != null && ballController.isBallThrown)
        {
            ballController.isBallThrown = false;
            Coroutine coroutiune =  StartCoroutine(ResetBall(collision));
          
        }
    }

    private IEnumerator ResetBall(Collider2D collision)
    {
        yield return new WaitForSeconds(1f);
        Destroy(collision.gameObject);
        ballController = SpawnBall();
    }

    private void UpdateScore()
    {
        scoreCard.text = playerScore.ToString();
    }

    private void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
