using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fightManager : MonoBehaviour
{
    public int roundFightLength; //Antal ronder i fighten
    public int roundActionsPerRound; //Antal aktioner varje spelare får göra innan ronden är slut

    public player PlayerOne;
    public TextMeshProUGUI HeadHealthTextPlayerOne;
    public TextMeshProUGUI BodyHealthTextPlayerOne;
    public TextMeshProUGUI StaminaHealthTextPlayerOne;
    public bool playerOnesTurn; //Om det är spelarens eller datorns tur

    public player PlayerTwo;
    public GameObject playerTwoFighterPanelGO;
    public TextMeshProUGUI BodyHealthTextPlayerTwo;
    public TextMeshProUGUI HeadHealthTextPlayerTwo;
    public TextMeshProUGUI StaminaHealthTextPlayerTwo;
    public bool knockdownState;

    bool actionCompletedOrNot;
    string head;

    knockdown Knockdown;

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

        Knockdown = GetComponent<knockdown>();
    }

    /// <summary>
    /// Sköter hur matcherna hanteras
    /// 1. Val av aktion (Egen funktion)
    /// 2. Lyckas aktionen (I funktion i val av aktion, refererar till annat script)
    /// 3. Reducera attackerande spelarens stamina (I funktion i val av aktion, refererar till annat script)
    /// 4. Uppdatera attackerande spelarens stats-text (Egen funktion)
    /// 5.1 Om aktionen lyckas: Reducera försvarandes stats (Annat script)
    /// 5.1.1 Uppdatera texten för försvarande spelare (Egen funktion)
    /// 5.1.2 Någon specialeffekt som ska genomföras? (Annat script)
    /// 5.2 Om aktionen misslyckas: Inget sker
    /// 6. Minska attackerande spelarens Action-Points (FightUpdate-funktion)
    /// 7. Uppdatera text för vad som händer i matchen (FightUpdate-funktion -> updateTextHitorNot)
    /// 8. Kontrollera om nästa aktion kan genomföras
    /// 9. Nästa spelarens tur? (FightUpdate-funktion)
    /// 
    /// </summary>

    public void fightUpdate()
    {
        GetComponent<actionsLeftPlayer>().subActionPoints();
        

            //Kontrollera om det är motståndarens tur
            if (playerOnesTurn == false && PlayerTwo.fighterStateNow == fighterState.None)
            {
            
                GetComponent<playerTwoAction>().randomized();
                StartCoroutine(checkIfNextRoundCanStart());
                
            }

        updateTextHitorNot(actionCompletedOrNot);
        GetComponent<roundManager>().afterPlayerAction();

        updatePlayerOne();
        updatePlayerTwo();
    }

    IEnumerator checkIfNextRoundCanStart()
    {
        //updateTextHitorNot(actionCompletedOrNot);
        if (PlayerOne.fighterStateNow == fighterState.None && PlayerTwo.fighterStateNow == fighterState.None)
        {
            enableFighterPanel();
            fightUpdate();
            
        }

        else if (PlayerTwo.fighterStateNow == fighterState.Knockdown)
        {
            disableFighterPanel();
            GetComponent<knockdown>().willPlayerGetUp(PlayerTwo);
            PlayerTwo.knockdownCounter++;
            actionCompletionText.text = PlayerTwo.name + " gets knockdowned!";
            Debug.Log("Vänta sec: " + Knockdown.timePlayerGetsUp);
            yield return new WaitForSeconds(Knockdown.timePlayerGetsUp + 1);
            StartCoroutine(checkIfNextRoundCanStart());
        }

        else if (PlayerOne.fighterStateNow == fighterState.Knockdown)
        {
            disableFighterPanel();
            GetComponent<knockdown>().willPlayerGetUp(PlayerOne);
            PlayerOne.knockdownCounter++;
            actionCompletionText.text = PlayerOne.name + " gets knockdowned!";
            Debug.Log("Vänta sec: " + Knockdown.timePlayerGetsUp);
            yield return new WaitForSeconds(Knockdown.timePlayerGetsUp + 1);
            StartCoroutine(checkIfNextRoundCanStart());
        }

        else
            fightUpdate();
            
            
      }

        public void updatePlayerOne()
    {
        HeadHealthTextPlayerOne.text = "Head: " + PlayerOne.headHealthNow;
        BodyHealthTextPlayerOne.text = "Body: " + PlayerOne.bodyHealthNow;
        StaminaHealthTextPlayerOne.text = "Stamina: " + PlayerOne.staminaHealthNow;
        PlayerOne.staminaRecoveryMinValue();
    }

    public void updatePlayerTwo()
    {
        HeadHealthTextPlayerTwo.text = "Head: " + PlayerTwo.headHealthNow;
        BodyHealthTextPlayerTwo.text = "Body: " + PlayerTwo.bodyHealthNow;
        StaminaHealthTextPlayerTwo.text = "Stamina: " + PlayerTwo.staminaHealthNow;
        PlayerTwo.staminaRecoveryMinValue();

    }

    public void playerOneJabHead()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerOne, PlayerTwo, true);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.jabStaminaUseHead);
        updatePlayerOne();

        if (actionCompletedOrNot == true)
        GetComponent <headHealthUpdate>().updateHeadHealth(PlayerTwo,PlayerOne.jabDamageHead);
        
        updatePlayerTwo();
        StartCoroutine(checkIfNextRoundCanStart());

    }

    public void playerTwoJabHead()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerTwo, PlayerOne, true);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.jabStaminaUseHead);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
        {
            GetComponent<headHealthUpdate>().updateHeadHealth(PlayerOne, PlayerTwo.jabDamageHead);

        }
        updatePlayerOne();
     
    }

    public void playerOneCrossHead()
    {
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerOne, PlayerTwo, true);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.crossStaminaUseHead);
        updatePlayerOne();

        //Träffar slaget
        if (actionCompletedOrNot == true)
        {
            GetComponent<headHealthUpdate>().updateHeadHealth(PlayerTwo, PlayerOne.crossDamageHead);
            knockdownState = Knockdown.willPlayerGetKnockdown(PlayerOne, PlayerTwo, true);

            
            if (knockdownState == true)
            {
                PlayerTwo.fighterStateUpdate(true);
            }
          
            updatePlayerTwo();
            //fightUpdate();
            StartCoroutine(checkIfNextRoundCanStart());

        }

        else
        {
            updatePlayerTwo();
            //fightUpdate();
            StartCoroutine(checkIfNextRoundCanStart());
        }
    }

    public void playerTwoCrossHead()
    {
        actionCompletionText.text = PlayerTwo.name + " throws a cross to the head";
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerTwo, PlayerOne, true);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.crossStaminaUseHead);
        updatePlayerTwo();

        //Träffar slaget
        if (actionCompletedOrNot == true)
        {
            GetComponent<headHealthUpdate>().updateHeadHealth(PlayerOne, PlayerTwo.crossDamageHead);
            knockdownState = Knockdown.willPlayerGetKnockdown(PlayerTwo, PlayerOne, true);

            if (knockdownState == true)
            {
                PlayerOne.fighterStateUpdate(true);
            }

            updatePlayerOne();
            checkIfNextRoundCanStart();
        }
        else
        {
            updatePlayerOne();
            checkIfNextRoundCanStart();
        }
    }

    public void playerOneJabBody()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerOne, PlayerTwo, false);

        //updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.jabStaminaUseBody);
        updatePlayerOne();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerTwo, PlayerOne.jabDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerOne.jabStaminaDamageBody);
        }
        updatePlayerTwo();
        StartCoroutine(checkIfNextRoundCanStart());
    }

    public void playerTwoJabBody()
    {
        actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerTwo, PlayerOne, false);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.jabStaminaUseBody);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerOne, PlayerTwo.jabDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerTwo.jabStaminaDamageBody);
        }
        updatePlayerOne();
 
    }

    public void playerOneCrossBody()
    {
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerOne, PlayerTwo, false);

        //updateTextAction(actionCompletedOrNot);

        GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerOne.crossStaminaUseBody);
        updatePlayerOne();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerTwo, PlayerOne.crossDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerOne.crossStaminaDamageBody);
            PlayerTwo.staminaRecoveryBetweenRounds -= PlayerOne.crossStaminaRecoveryDamageBody;
        }

        updatePlayerTwo();
        StartCoroutine(checkIfNextRoundCanStart());
    }

    public void playerTwoCrossBody()
    {
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerTwo, PlayerOne, false);

        GetComponent<staminaUpdate>().updateStamina(PlayerTwo, PlayerTwo.crossStaminaUseBody);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
        {
            GetComponent<bodyHealthUpdate>().updateBodyHealth(PlayerOne, PlayerTwo.crossDamageBody);
            GetComponent<staminaUpdate>().updateStamina(PlayerOne, PlayerTwo.crossStaminaDamageBody);
            PlayerOne.staminaRecoveryBetweenRounds -= PlayerTwo.crossStaminaRecoveryDamageBody;
        }

        updatePlayerOne();
    }

    public void updateTextHitorNot(bool completion) 
    {
        if (completion == true)
        {
            actionCompletionText.text = "HIT";

            if (PlayerTwo.fighterStateNow == fighterState.Knockdown)
            {
               //actionCompletionText.text = PlayerTwo.name + " gets knockdowned!";
               //GetComponent<knockdown>().willPlayerGetUp(PlayerTwo);
               //PlayerTwo.knockdownCounter++;
            }

            if (PlayerOne.fighterStateNow == fighterState.Knockdown)
            {
                actionCompletionText.text = PlayerOne.name + " gets knockdowned!";
               
            }
        }

        else
            actionCompletionText.text = "MISS";

    }

    void disableFighterPanel()
    {
        playerTwoFighterPanelGO.active = false;
    }

    void enableFighterPanel()
    {
        playerTwoFighterPanelGO.active = true;
    }



}
