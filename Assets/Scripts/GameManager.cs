using UnityEngine;
using UnityEngine.UI;
using System;
//using Zenject;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;
    private int computerScore = 0;
    private int scoreToWin = 5;

    [Header("SceneObjectRefs")]
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private ScoringZone playerZone;
    [SerializeField] private ScoringZone computerZone;

    [Header("UIElements")]
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;
    [SerializeField] private GameObject playerWinUI;
    [SerializeField] private GameObject computerWinUI;


    private void Start()
    {
        playerZone.OnBallEntered += ScoringZone_OnBallEntered;
        computerZone.OnBallEntered += ScoringZone_OnBallEntered;
    }

    private void OnDestroy()
    {
        playerZone.OnBallEntered -= ScoringZone_OnBallEntered;
        computerZone.OnBallEntered -= ScoringZone_OnBallEntered;
    }

    private void ScoringZone_OnBallEntered(object sender, ScoringZone.BallEnteredEventArgs e)
    {
        switch(e.zone)
        {
            case ScoringZone.Zones.player :
                ComputerScores();
                break;
            case ScoringZone.Zones.computer :
                PlayerScores();
                break;
            default :
                ResetRound();
                break;
        }
    }


    public void PlayerScores() {
        playerScore++;
        this.playerScoreText.text = playerScore.ToString();
        if (playerScore >= 5)
        {
            this.playerWinUI.SetActive(true);
            Time.timeScale = 0f;
        } else {
            ResetRound();
        }
    }

    public void ComputerScores() {
        computerScore++;
        this.computerScoreText.text = computerScore.ToString();
        if (computerScore >= 5)
        {
            this.computerWinUI.SetActive(true);
            Time.timeScale = 0f;
        } else {
            ResetRound();
        }
    }

    private void ResetRound() {
        this.ball.ResetPosition();
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.AddStartingForce();
    }

    public void ResetGame()
    {
        Time.timeScale = 1.0f;

        playerWinUI.SetActive(false);
        computerWinUI.SetActive(false);

        playerScore = 0;
        computerScore = 0;
        computerScoreText.text = computerScore.ToString();
        playerScoreText.text = playerScore.ToString();

        ResetRound();
    }

    
    
}
