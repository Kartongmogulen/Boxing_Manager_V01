using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{
    /*Hanterar
    1. Rondnummer
    2. Klocka
    */

    private int roundFightLength; //Antal ronder i fighten
    public int roundNow;
    private int minInRound; //Antal min som g�tt i ronden
    private float secInRound; //Antal sekunder som g�tt i ronden
    private float roundActionsPerPlayer; //Antal aktioner varje spelare f�r g�ra innan ronden �r slut
    public bool playerOneWonOnDecision;

    public GameObject victoryPanelGO;
    public GameObject statisticsGO;

    public TextMeshProUGUI roundClock;
    private void Start()
    {
        roundFightLength = GetComponent<fightManager>().roundFightLength;
        roundActionsPerPlayer = GetComponent<fightManager>().roundActionsPerRound;
        //roundNow = 1;
    }

    public void afterPlayerAction()
    {
        secInRound += 180 / roundActionsPerPlayer / 2;
        
        if (secInRound>=60)
        {
            minInRound++;
            secInRound = secInRound - 60;
        }

        if (minInRound == 3)
        {
            resetRound();
            Debug.Log("Round now: " + roundNow);
        }

        roundClock.text = "Round: " + roundNow + "  Min: " + minInRound +  " Sec: " + secInRound;
       
    }

    //Nollst�ller vid rondens slut
   public void resetRound()
    {
        //Debug.Log("Reset round");
        roundNow++;
        minInRound = 0;

        GetComponent<betweenRounds>().recoverStats(GetComponent<fightManager>().PlayerTwo);
        GetComponent<scorecardManager>().compareKnockdowns();

        //Matchen har g�tt tiden ut
        if (roundNow == roundFightLength)
        {
            //Debug.Log("Matchen har g�tt tiden ut");
            playerOneWonOnDecision = GetComponent<scorecardManager>().scorecardToGetWinner();
            //if (playerOneWonOnDecision == true)
            GetComponent<fightManager>().fightEndedDecision();
            //victoryPanelGO.GetComponent<afterFightUpdate>().decisionUpdate(playerOneWonOnDecision);
        }
    }

    public void resetRoundAfterFight()
    {
        roundNow = 1;
        minInRound = 0;
        secInRound = 0;

        roundClock.text = "Round: " + roundNow + "  Min: " + minInRound + " Sec: " + secInRound;
    }

    public void addStatisticFightEndedRound()
    {
        statisticsGO.GetComponent<fightStatistics>().addRound(roundNow);
    }
}
