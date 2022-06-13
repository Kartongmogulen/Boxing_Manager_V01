using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerStatsUIController : MonoBehaviour
{
    public player Player;
    public TextMeshProUGUI expPointsLeftText;
    //ATTACK
    public TextMeshProUGUI AccuracyPointsText;
    public TextMeshProUGUI StrengthPointsText;
    public TextMeshProUGUI knockdownChancePointsText;
    public TextMeshProUGUI bodySnatcherPointsText;
    //DEFEND
    public TextMeshProUGUI guardHeadText;
    public TextMeshProUGUI guardBodyText;
    //HEALTH
    public TextMeshProUGUI healthHeadText;
    public TextMeshProUGUI healthBodyText;
    public TextMeshProUGUI staminaHealthText;
    public TextMeshProUGUI staminaRecoveryHealthText;

    // Start is called before the first frame update
    void Start()
    {
        expPointsLeftText.text = "Exp Points Left: " + Player.expPointsStart;
        AccuracyPointsText.text = "Accuracy: " + Player.accuracy;
        StrengthPointsText.text = "Strength: " + Player.strength;
        knockdownChancePointsText.text = "Knockdown: " + Player.knockdownChance;
        bodySnatcherPointsText.text = "Bodysnatcher: " + Player.reduceOpponentStaminaRecoveryChance;
        guardHeadText.text = "Guard (Head): " + Player.guardHead;
        guardBodyText.text = "Guard (Body): " + Player.guardBody;
        healthHeadText.text = "Head: " + Player.headHealthNow;
        healthBodyText.text = "Body: " + Player.bodyHealthNow;
        staminaHealthText.text = "Stamina, Max: " + Player.staminaHealthNow;
        staminaRecoveryHealthText.text = "Stamina, Rec: " + Player.staminaRecoveryBetweenRounds;
    }

    public void updateText()
    {
        expPointsLeftText.text = "Exp Points Left: " + Player.expPointsNow;
        AccuracyPointsText.text = "Accuracy: " + Player.accuracy;
        StrengthPointsText.text = "Strength: " + Player.strength;
        knockdownChancePointsText.text = "Knockdown: " + Player.knockdownChance;
        bodySnatcherPointsText.text = "Bodysnatcher: " + Player.reduceOpponentStaminaRecoveryChance;
        guardHeadText.text = "Guard (Head): " + Player.guardHead;
        guardBodyText.text = "Guard (Body): " + Player.guardBody;
        healthHeadText.text = "Head: " + Player.headHealthNow;
        healthBodyText.text = "Body: " + Player.bodyHealthNow;
        staminaHealthText.text = "Stamina, Max: " + Player.staminaHealthNow;
        staminaRecoveryHealthText.text = "Stamina, Rec: " + Player.staminaRecoveryBetweenRounds;
    }
}
