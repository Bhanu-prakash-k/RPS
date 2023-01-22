using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject mainMenu;

    public GameObject gamePanel;

    public GameObject gameOverPanel;

    public TMP_Text winOrLoseText;

    public int score;
    public int AIScore;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text AIScoreText;

    [HideInInspector] public bool isGameOver;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePanel.SetActive(false);
        mainMenu.SetActive(true);
        gameOverPanel.SetActive(false);
        isGameOver = false;

        score = 0;
        AIScore = 0;

        AIScoreText.text = "AIScore: " + AIScore.ToString();
        scoreText.text = "Score: " + score.ToString();  
    }

    public void OnRetryButtonClick()
    {
        isGameOver = false;
        score = 0;
        AIScore = 0;
        scoreText.text = "Score: " + score;
        AIScoreText.text = "AIScore: " + AIScore;
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void OnPlayButtonClick()
    {
        mainMenu.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void PlayerScoreIncrease(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
    public void AIScoreIncrease(int amount)
    {
        AIScore += amount;
        AIScoreText.text = "AIScore: " + AIScore.ToString();
    }
}
