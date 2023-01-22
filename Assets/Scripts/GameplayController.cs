using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public enum Choices
{
    None,
    Rock,
    Paper,
    Scissor
    
}

public class GameplayController : MonoBehaviour
{
    public RectTransform AIHolder, playerHolder, bottomButtons;
    
    public Sprite rockSprite, paperSprite, scissorSprite, lizardSprite, spockSprite;

    public Image playerChoiceImage, AIChoiceImage;

    public TMP_Text winOrLoseText;

    private Choices playerChoices = Choices.None, opponentChoices = Choices.None;

    void Start()
    {
        winOrLoseText.gameObject.SetActive(false);
        AIHolder.DOAnchorPos(new Vector2(-800, -500), 1f);
        playerHolder.DOAnchorPos(new Vector2(800, 500), 1f);
    }
    public void SetChoices(Choices gameChoices)
    {
        switch (gameChoices)
        {
            case Choices.Rock:
                playerChoiceImage.sprite = rockSprite;

                playerChoices = Choices.Rock;

                break;
            case Choices.Paper:
                playerChoiceImage.sprite = paperSprite;

                playerChoices = Choices.Paper;

                break;
            case Choices.Scissor:
                playerChoiceImage.sprite = scissorSprite;

                playerChoices = Choices.Scissor;
                break;
            

        }

        SetAIChoices();

        CheckWinner();
    }
    void SetAIChoices()
    {
        int AIChoice = Random.Range(0, 3);

        switch (AIChoice)
        {
            case 0:
                opponentChoices = Choices.Rock;

                AIChoiceImage.sprite = rockSprite;

                break;
            case 1:
                opponentChoices = Choices.Paper;

                AIChoiceImage.sprite = paperSprite;
                break;
            case 2:
                opponentChoices = Choices.Scissor;

                AIChoiceImage.sprite = scissorSprite;
                break;
            
        }
    }
    void CheckWinner()
    {
        if(playerChoices == opponentChoices)
        {
            winOrLoseText.text = "Tie";
            StartCoroutine(DisplayWinnerAndRestart());
        }
        if(playerChoices == Choices.Rock && (opponentChoices == Choices.Scissor))
        {
            //player won

            winOrLoseText.text = "Win";
            GameManager.Instance.PlayerScoreIncrease(1);
            StartCoroutine(DisplayWinnerAndRestart());
        }
        
        if(playerChoices == Choices.Paper && (opponentChoices == Choices.Rock))
        {
            //player won

            winOrLoseText.text = "Win";
            GameManager.Instance.PlayerScoreIncrease(1);
            StartCoroutine(DisplayWinnerAndRestart());
        }

        if(playerChoices == Choices.Scissor && (opponentChoices == Choices.Paper))
        {
            //player won

            winOrLoseText.text = "Win";
            GameManager.Instance.PlayerScoreIncrease(1);
            StartCoroutine(DisplayWinnerAndRestart());
        }
        
        if (opponentChoices == Choices.Rock && (playerChoices == Choices.Scissor))
        {
            //AI won

            winOrLoseText.text = "Lose";
            GameManager.Instance.AIScoreIncrease(1);
            StartCoroutine(DisplayWinnerAndRestart());
        }
        if (opponentChoices == Choices.Paper && (playerChoices == Choices.Rock))
        {
            //AI won

            winOrLoseText.text = "Lose";
            GameManager.Instance.AIScoreIncrease(1);
            StartCoroutine(DisplayWinnerAndRestart());
        }
        if (opponentChoices == Choices.Scissor && (playerChoices == Choices.Paper))
        {
            //AI won

            winOrLoseText.text = "Lose";
            GameManager.Instance.AIScoreIncrease(1);
            StartCoroutine(DisplayWinnerAndRestart());
        }
        
    }
    IEnumerator DisplayWinnerAndRestart()
    {
        yield return new WaitForSeconds(0.5f);
        winOrLoseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        winOrLoseText.gameObject.SetActive(false);

        AIHolder.DOAnchorPos(new Vector2(-800, -500), 0.25f);
        playerHolder.DOAnchorPos(new Vector2(800, 500), 0.25f);
        bottomButtons.DOAnchorPos(new Vector2(0, 0), 0.25f);
        if(GameManager.Instance.score == 10)
        {
            OnGameOver("YOU WIN");
        }
        if(GameManager.Instance.AIScore == 10)
        {
            OnGameOver("YOU LOSE");
        }
    }
    private void OnGameOver(string winOrLoseText)
    {
        GameManager.Instance.isGameOver = true;
        GameManager.Instance.winOrLoseText.text = winOrLoseText;
        GameManager.Instance.gamePanel.SetActive(false);
        GameManager.Instance.gameOverPanel.SetActive(true);

    }
}
