using UnityEngine;

public class player : MonoBehaviour
{
    public string name;
    public fighterState fighterStateNow;
    public fightStyle fightStyleNow;

    public GameObject playerPanel;
    public GameObject fightStatsGO;

    public bool Opponent; //Om det �r en motst�ndare eller egna spelaren

    //StartV�rden
    public int expPointsStart; //Antal po�ng att dela ut vid start
    public int playerLvl;
    public int playerLvlHealthHead;
    public int playerLvlHealthBody;
    public int playerLvlHealthStamina;
    public int playerLvlHealthStaminaRecovery;

    //HEALTH
    public int bodyHealthStart;
    public int bodyHealthStatAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int headHealthStart;
    public int headHealthAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int staminaHealthStart;
    public int staminaHealthAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int staminaRecoveryBetweenRounds;
    public int staminaRecoveryBetweenRoundsAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.

    //DEFENCE
    public int guardHead;
    public int guardHeadStatAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int guardBody;
    public int guardBodyStatAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.

    //ATTACK
    public int accuracy; //Chans att tr�ffa
    public int accuracyStatAfterLastFight; //Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int strength; //Skada
    public int strengthStatAfterLastFight; //Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int endurance; //Stamina use

    //SPECIAL STATS
    public int knockdownChance; //H�gre v�rde = st�rre chans att knocka motst�ndaren
    public int knockdownChanceStatAfterLastFight; //H�gre v�rde = st�rre chans att knocka motst�ndaren
    public int reduceOpponentStaminaRecoveryChance; //H�gre v�rde = st�rre chans att lyckas
    public int reduceOpponentStaminaRecoveryChanceStatAfterLastFight; //H�gre v�rde = st�rre chans att lyckas

    //Diff mellan Jab och Cross
    public int jabLowerStaminaUse; //L�gre stamina use j�mf�rt med Cross
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

    //V�rdering som �ndras
    public int bodyHealthNow;
    public int headHealthNow;
    public int staminaHealthNow;

    public int knockdownCounter;
    public int damageTakenDuringRound;

    public int expPointsNow;

    //Statistik under match
    public int actionsPerformed;
    public int actionsSucceded;
    public int actionsFailed;


    public void Awake()
    {
        jabLowerStaminaUse = playerPanel.GetComponent<attributeLevelManager>().jabLowerStaminaUse;
        jabCrossDiffDamage = playerPanel.GetComponent<attributeLevelManager>().jabCrossDiffDamage;

        if (Opponent == true)
        {
            bodyHealthStart = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
            headHealthStart = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
            staminaHealthStart = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];
            startFight();
        }

        bodyHealthNow = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvl];
     
        headHealthNow = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvl];

        staminaHealthNow = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvl];
        staminaRecoveryBetweenRounds = playerPanel.GetComponent<attributeLevelManager>().staminaHealthRecoveryByLvl[playerLvlHealthStaminaRecovery];

        //Exp Points
        expPointsNow = expPointsStart;

    }

    public void startFight()
    {
        bodyHealthStart = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
        headHealthStart = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
        staminaHealthStart = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];

        crossDamageHead = strength;
        crossDamageBody = strength;

        crossKnockDownHead = knockdownChance;
        crossStaminaRecoveryDamageBody = reduceOpponentStaminaRecoveryChance;
        crossStaminaDamageBody = strength;
        jabStaminaDamageBody = Mathf.RoundToInt(strength / 2);

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
            GetComponent<fightStatsKnockdownCause>().lowBodyHealth();
        }
    }

    public void updateStamina(int staminaChange)
    {
      staminaHealthNow = staminaUpdate.updateStamina(staminaHealthNow, staminaChange);

        if (staminaHealthNow <= 0)
        {
            fighterStateUpdate(true); //Spelaren blir knockad
            staminaHealthNow = staminaHealthStart/2;
            GetComponent<fightStatsKnockdownCause>().lowStamina();
        }

    }

    public void updateHeadHealth(int healthComsumed)
    {
       headHealthNow = headHealthUpdate.updateHeadHealth(headHealthNow, healthComsumed);
       damageTakenDuringRound += healthComsumed;

        if (headHealthNow <= 0)
        {
            //Debug.Log("updateHeadHealth Zero");
            //Debug.Log("headHealthStart " + headHealthStart);
            fighterStateUpdate(true);
            headHealthNow = headHealthStart/2;
            GetComponent<fightStatsKnockdownCause>().lowHeadHealth();

            /*if (Opponent == true)
            fightStatsGO.GetComponent<fightStatsKnockdownCause>().lowHeadHealth(false);
            else
            {
                fightStatsGO.GetComponent<fightStatsKnockdownCause>().lowHeadHealth(true);
            }
            */
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
        knockdownCounter = 0;
        actionsPerformed = 0;

        //Statistik
        actionsPerformed = 0;
        actionsSucceded = 0;
        actionsFailed = 0;
    }

    public void fightStatisticsNumberOfActions()
    {
        actionsPerformed++;

    }

    public void fightStatisticsNumberOfSuccededActions()
    {
        actionsSucceded++;
    }

    public void fightStatisticsNumberOfFailedActions()
    {
        actionsFailed++;
    }
}
