using UnityEngine;

public class player : MonoBehaviour
{
    public string name;
    public fighterState fighterStateNow;
    public fightStyle fightStyleNow;

    public GameObject playerPanel;

    public bool Opponent; //Om det är en motståndare eller egna spelaren

    //StartVärden
    public int expPointsStart; //Antal poäng att dela ut vid start
    public int playerLvl;
    public int playerLvlHealthHead;
    public int playerLvlHealthBody;
    public int playerLvlHealthStamina;
    public int playerLvlHealthStaminaRecovery;

    //HEALTH
    public int bodyHealthStart;
    public int headHealthStart;
    public int staminaHealthStart;
    public int staminaRecoveryBetweenRounds;

    //DEFENCE
    public int guardHead;
    public int guardBody;

    //ATTACK
    public int accuracy; //Chans att träffa
    public int strength; //Skada
    public int endurance; //Stamina use

    //SPECIAL STATS
    public int knockdownChance; //Högre värde = större chans att knocka motståndaren
    public int reduceOpponentStaminaRecoveryChance; //Högre värde = större chans att lyckas

    //Diff mellan Jab och Cross
    public int jabLowerStaminaUse; //Lägre stamina use jämfört med Cross
    public int jabCrossDiffDamage; //Skillnad mellan damage mellan Cross och Jab

    //ATTACK HEAD
    public int jabAccuracyHead;
    public int jabStaminaUseHead;
    public int jabDamageHead;

    public int crossAccuracyHead;
    public int crossStaminaUseHead;
    public int crossDamageHead;
    public int crossKnockDownHead;

    //ATTACK BODY
    public int jabAccuracyBody;
    public int jabStaminaUseBody;
    public int jabDamageBody;
    public int jabStaminaDamageBody;

    public int crossAccuracyBody;
    public int crossStaminaUseBody;
    public int crossDamageBody;
    public int crossStaminaDamageBody;
    public int crossStaminaRecoveryDamageBody;

    //Värdering som ändras
    public int bodyHealthNow;
    public int headHealthNow;
    public int staminaHealthNow;

    public int knockdownCounter;
    public int damageTakenDuringRound;

    public int expPointsNow;

    public void Awake()
    {
        if (Opponent == true)
        {
            bodyHealthStart = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvl];
            headHealthStart = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvl];
            staminaHealthStart = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvl];
            startFight();
        }
        jabLowerStaminaUse = playerPanel.GetComponent<attributeLevelManager>().jabLowerStaminaUse;
        jabCrossDiffDamage = playerPanel.GetComponent<attributeLevelManager>().jabCrossDiffDamage;

        
        //bodyHealthNow = bodyHealthStart;
        bodyHealthNow = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvl];
        
        //headHealthNow = headHealthStart;
        headHealthNow = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvl];

        staminaHealthNow = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvl];
        staminaRecoveryBetweenRounds = playerPanel.GetComponent<attributeLevelManager>().staminaHealthRecoveryByLvl[playerLvlHealthStaminaRecovery];

        /*
        crossDamageHead = strength;
        crossDamageBody = strength;

        crossKnockDownHead = knockdownChance;
        crossStaminaRecoveryDamageBody = reduceOpponentStaminaRecoveryChance;
        //Accuracy
        jabAccuracyHead = accuracy;
        crossAccuracyHead = accuracy;
        jabAccuracyBody = accuracy;
        crossAccuracyBody = accuracy;

        //Strength
        if (strength - jabCrossDiffDamage <= 0)
        {
            jabDamageHead = 1;
        }
        else
        jabDamageHead = strength - jabCrossDiffDamage;

        if (strength - jabCrossDiffDamage <= 0)
        {
            jabDamageBody = 1;
        }
        else
        jabDamageBody = strength - jabCrossDiffDamage;

        //crossDamageHead = strength;
        //crossDamageBody = strength;

        //Endurance
        if (endurance - jabLowerStaminaUse <= 0)
            jabStaminaUseHead = 1;
        else
           jabStaminaUseHead = endurance - jabLowerStaminaUse;

        if (endurance - jabLowerStaminaUse <= 0)
            jabStaminaUseBody = 1;
        else
            jabStaminaUseBody = endurance - jabLowerStaminaUse;

        crossStaminaUseHead = endurance;
        crossStaminaUseBody = endurance;
        */

        //Exp Points
        expPointsNow = expPointsStart;

        //healthPanelTextUpdate.updateOpponentText();
    }

    public void startFight()
    {

        crossDamageHead = strength;
        crossDamageBody = strength;

        crossKnockDownHead = knockdownChance;
        crossStaminaRecoveryDamageBody = reduceOpponentStaminaRecoveryChance;
        //Accuracy
        jabAccuracyHead = accuracy;
        crossAccuracyHead = accuracy;
        jabAccuracyBody = accuracy;
        crossAccuracyBody = accuracy;

        //Strength
        if (strength - jabCrossDiffDamage <= 0)
        {
            jabDamageHead = 1;
        }
        else
            jabDamageHead = strength - jabCrossDiffDamage;

        if (strength - jabCrossDiffDamage <= 0)
        {
            jabDamageBody = 1;
        }
        else
            jabDamageBody = strength - jabCrossDiffDamage;

        //crossDamageHead = strength;
        //crossDamageBody = strength;

        //Endurance
        if (endurance - jabLowerStaminaUse <= 0)
            jabStaminaUseHead = 1;
        else
            jabStaminaUseHead = endurance - jabLowerStaminaUse;

        if (endurance - jabLowerStaminaUse <= 0)
            jabStaminaUseBody = 1;
        else
            jabStaminaUseBody = endurance - jabLowerStaminaUse;

        crossStaminaUseHead = endurance;
        crossStaminaUseBody = endurance;
    }

    public void fighterStateUpdate(bool knockdown)
    {
        if (knockdown == true){
            fighterStateNow = fighterState.Knockdown;
        }
    }

    public void staminaRecoveryMinValue()
    {
        if (staminaRecoveryBetweenRounds < 0)
        {
            staminaRecoveryBetweenRounds = 0;
        }
    }

    public void updateBodyHealth(int healthComsumed)
    {
        bodyHealthNow = bodyHealthUpdate.updateBodyHealth(bodyHealthNow, healthComsumed);
        damageTakenDuringRound += healthComsumed;

        if (bodyHealthNow <= 0)
        {
            fighterStateUpdate(true);
            bodyHealthNow = bodyHealthStart / 2;
        }
    }

    public void updateStamina(int staminaChange)
    {
      staminaHealthNow = staminaUpdate.updateStamina(staminaHealthNow, staminaChange);

        if (staminaHealthNow <= 0)
        {
            fighterStateUpdate(true); //Spelaren blir knockad
            staminaHealthNow = staminaHealthStart/2;
        }

    }

    public void updateHeadHealth(int healthComsumed)
    {
       headHealthNow = headHealthUpdate.updateHeadHealth(headHealthNow, healthComsumed);
       damageTakenDuringRound += healthComsumed;

        if (headHealthNow <= 0)
        {
            fighterStateUpdate(true);
            headHealthNow = headHealthStart/2;
        }
    }

    public void upgradePlayer()
    {
        bodyHealthNow = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
        headHealthNow = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
        staminaHealthNow = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];
        staminaRecoveryBetweenRounds = playerPanel.GetComponent<attributeLevelManager>().staminaHealthRecoveryByLvl[playerLvlHealthStaminaRecovery];

        //crossDamageHead = strength;
        //crossDamageBody = strength;
    }

    public void resetAfterFight()
    {
        //Debug.Log("Stamina Recovery: " + staminaRecoveryBetweenRounds);
        headHealthNow = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
        bodyHealthNow = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
        staminaHealthNow = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];
        staminaRecoveryBetweenRounds = playerPanel.GetComponent<attributeLevelManager>().staminaHealthRecoveryByLvl[playerLvlHealthStaminaRecovery];
    }
}
