using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fightManager : MonoBehaviour
{
    public player PlayerOne;
    public TextMeshProUGUI HeadHealthTextPlayerOne;
    public TextMeshProUGUI BodyHealthTextPlayerOne;
    public TextMeshProUGUI StaminaHealthTextPlayerOne;
    public bool playerOnesTurn; //Om det är spelarens eller datorns tur

    public player PlayerTwo;
    public TextMeshProUGUI BodyHealthTextPlayerTwo;
    public TextMeshProUGUI HeadHealthTextPlayerTwo;
    public TextMeshProUGUI StaminaHealthTextPlayerTwo;

    bool actionCompletedOrNot;
    string head;


    public TextMeshProUGUI actionCompletionText;

    public void Start()
    {
        playerOnesTurn = true;

        HeadHealthTextPlayerOne.text = "Head: " + PlayerOne.headHealthStart;
        BodyHealthTextPlayerOne.text = "Body: " + PlayerOne.bodyHealthStart;
        StaminaHealthTextPlayerOne.text = "Stamina: " + PlayerOne.staminaHealthStart;

        BodyHealthTextPlayerTwo.text = "Body: " + PlayerTwo.bodyHealthStart;
        HeadHealthTextPlayerTwo.text = "Head: " + PlayerTwo.headHealthStart;
        StaminaHealthTextPlayerTwo.text = "Stamina: " + PlayerTwo.staminaHealthNow;
    }

    public void fightUpdate()
    {
        GetComponent<actionsLeftPlayer>().subActionPoints();

        if (playerOnesTurn == false)
        {
            GetComponent<playerTwoAction>().randomized();
            //Debug.Log("Player Twos turn");
        }
    }

    public void updatePlayerOne()
    {
        HeadHealthTextPlayerOne.text = "Head: " + PlayerOne.headHealthNow;
        BodyHealthTextPlayerOne.text = "Body: " + PlayerOne.bodyHealthNow;
        StaminaHealthTextPlayerOne.text = "Stamina: " + PlayerOne.staminaHealthNow;
    }

    public void updatePlayerTwo()
    {
        HeadHealthTextPlayerTwo.text = "Head: " + PlayerTwo.headHealthNow;
        BodyHealthTextPlayerTwo.text = "Body: " + PlayerTwo.bodyHealthNow;
        StaminaHealthTextPlayerTwo.text = "Stamina: " + PlayerTwo.staminaHealthNow;
    }

    public void playerOneJabHead()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerOne, PlayerTwo, true);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.jabStaminaUseHead);
        updatePlayerOne();

        if (actionCompletedOrNot == true)
        GetComponent <headHealthUpdate>().updateHeadHealth(PlayerTwo,PlayerOne.jabDamageHead);
        
        updatePlayerTwo();
        fightUpdate();
    }

    public void playerTwoJabHead()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerTwo, PlayerOne, true);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.jabStaminaUseHead);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
            GetComponent<headHealthUpdate>().updateHeadHealth(PlayerOne, PlayerTwo.jabDamageHead);

        updatePlayerOne();
        fightUpdate();
    }

    public void playerOneCrossHead()
    {
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerOne, PlayerTwo, true);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.crossStaminaUseHead);
        updatePlayerOne();

        if (actionCompletedOrNot == true)
            GetComponent<headHealthUpdate>().updateHeadHealth(PlayerTwo, PlayerOne.crossDamageHead);

        updatePlayerTwo();
        fightUpdate();
    }

    public void playerTwoCrossHead()
    {
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerTwo, PlayerOne, true);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.crossStaminaUseHead);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
            GetComponent<headHealthUpdate>().updateHeadHealth(PlayerOne, PlayerTwo.crossDamageHead);

        updatePlayerOne();
        fightUpdate();
    }

    public void playerOneJabBody()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerOne, PlayerTwo, false);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.jabStaminaUseBody);
        updatePlayerOne();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerTwo, PlayerOne.jabDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerOne.jabStaminaDamageBody);
        }
        updatePlayerTwo();
        fightUpdate();
    }

    public void playerTwoJabBody()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerTwo, PlayerOne, false);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.jabStaminaUseBody);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerOne, PlayerTwo.jabDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerTwo.jabStaminaDamageBody);
        }
        updatePlayerOne();
        fightUpdate();
    }

    public void playerOneCrossBody()
    {
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerOne, PlayerTwo, false);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.crossStaminaUseBody);
        updatePlayerOne();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerTwo, PlayerOne.crossDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerOne.crossStaminaDamageBody);
        }

        updatePlayerTwo();
        fightUpdate();
    }

    public void playerTwoCrossBody()
    {
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerTwo, PlayerOne, false);

        updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.crossStaminaUseBody);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerOne, PlayerTwo.crossDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerTwo.crossStaminaDamageBody);
        }

        updatePlayerOne();
        fightUpdate();
    }

    public void updateTextAction(bool completion) 
    {
        if (completion == true)
        {
            actionCompletionText.text = "HIT";
        }

        else
            actionCompletionText.text = "MISS";

    }

    

}
