using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startNextFight : MonoBehaviour
{
    /// <summary>
    /// Hanterar att starta nästa Fight
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
    }

    public void victoryPanelToPlayerPanel()
    {
        victoryPanelGO.SetActive(false);
        playerPanelGO.SetActive(true);
        playerPanelScriptsGO.GetComponent<playerStatsUIController>().updateText();
    }


}
