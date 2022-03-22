using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class actionsLeftPlayer : MonoBehaviour
{
    public int actionPointsStart;
    public int actionPointsNow;

    public bool playerOnesTurn;

    public TextMeshProUGUI playersTurnText;

    public void Start()
    {
        actionPointsNow = actionPointsStart;
       //playerOnesTurn = true;
        playersTurnText.text = "Player One (turns left): " + actionPointsNow;
    }

    public void subActionPoints()
    {
        playerOnesTurn = GetComponent<fightManager>().playerOnesTurn;
 
        actionPointsNow--;
        if (actionPointsNow == 0)
            resetActionPoints();

        updateText();

    }

    public void resetActionPoints()
    {
      
        actionPointsNow = actionPointsStart;

        if (playerOnesTurn == true)
            GetComponent<fightManager>().playerOnesTurn = false;
        else
            GetComponent<fightManager>().playerOnesTurn = true;
    }

    public void updateText()
    {
        playerOnesTurn = GetComponent<fightManager>().playerOnesTurn;
        if (playerOnesTurn == true)
            playersTurnText.text = "Player One (turns left): " + actionPointsNow;
        else
        {
            playersTurnText.text = "Player Two (turns left): " + actionPointsNow;
        }
       
    }
}
