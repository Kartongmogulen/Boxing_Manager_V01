using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startNextFight : MonoBehaviour
{
    /// <summary>
    /// Hanterar att starta n�sta Fight
    /// </summary>

    public GameObject fightScriptGO;
    public GameObject FightUiGO;
    public player playerOne;

    public healthPanelTextUpdate HealthPanelTextUpdate;

    public GameObject playerPanelGO;
    public GameObject playerPanelScriptsGO;
    public GameObject fightPanelGO;
    public GameObject victoryPanelGO;

    private void Start()
    {
        HealthPanelTextUpdate = FightUiGO.GetComponent<healthPanelTextUpdate>();
    }

    public void playerPanelToFight()
    {
        playerPanelGO.SetActive(false);
        fightPanelGO.SetActive(true);

        fightScriptGO.GetComponent<fightManager>().setUpFight();
        HealthPanelTextUpdate.updatePlayerOneText();
        playerOne.startFight();
        saveStatsForPlayer();
    }

    //Sparar stats f�r spelaren s� det ej g�r att f� l�gre vid n�sta match �n dessa po�ng.
    //Ska inte g� att g� ner i lvl.
    public void saveStatsForPlayer()
    {
        playerOne.accuracyStatAfterLastFight = playerOne.accuracy;
        playerOne.strengthStatAfterLastFight = playerOne.strength;
        playerOne.knockdownChanceStatAfterLastFight = playerOne.knockdownChance;
        playerOne.reduceOpponentStaminaRecoveryChanceStatAfterLastFight = playerOne.reduceOpponentStaminaRecoveryChance;
        playerOne.guardHeadStatAfterLastFight = playerOne.guardHead;
        playerOne.guardBodyStatAfterLastFight = playerOne.guardBody;
        playerOne.headHealthAfterLastFight = playerOne.headHealthStart;
        playerOne.bodyHealthStatAfterLastFight = playerOne.bodyHealthStart;
        playerOne.staminaHealthAfterLastFight = playerOne.playerLvlHealthStamina;
        playerOne.staminaRecoveryBetweenRoundsAfterLastFight = playerOne.staminaRecoveryBetweenRounds;
    }
    public void victoryPanelToPlayerPanel()
    {
        victoryPanelGO.SetActive(false);
        playerPanelGO.SetActive(true);
        playerPanelScriptsGO.GetComponent<playerStatsUIController>().updateText();
    }


}
