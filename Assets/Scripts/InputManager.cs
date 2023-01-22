using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputManager : MonoBehaviour
{
    private GameplayController gameplayController;

    // Start is called before the first frame update
    void Start()
    {
        gameplayController = GetComponent<GameplayController>();    
    }

    
    public void GetChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        //Debug.Log("Print Player selected:" + choiceName);

        Choices selectedChoice = Choices.None;

        switch (choiceName)
        {
            case "Rock":
                selectedChoice = Choices.Rock;
                break;
            case "Paper":
                selectedChoice = Choices.Paper;
                break;
            case "Scissor":
                selectedChoice = Choices.Scissor;
                break;
            
        }
        gameplayController.SetChoices(selectedChoice);
        gameplayController.AIHolder.DOAnchorPos(new Vector2(0, -500), 0.25f);
        gameplayController.playerHolder.DOAnchorPos(new Vector2(0, 500), 0.25f);
        gameplayController.bottomButtons.DOAnchorPos(new Vector2(0, -400), 0.25f);
    }
}
