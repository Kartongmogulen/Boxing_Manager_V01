using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseOverButtonInfo : MonoBehaviour
{
    public player PlayerOne;
    public player PlayerTwo;

    public Text buttonJabHeadText;
    public Text buttonJabBodyText;

    public Text buttonCrossHeadText;
    public Text buttonCrossBodyText;

    public Text actionDescritionText;
    public Text damageText;
    public Text staminaDamageText;
    public Text staminaUsePlayerText;
    public Text accuracyStatText;
    public Text guardStatText;


    public void mouseOverJabHead()
    {
        actionDescritionText.text = buttonJabHeadText.text;
        damageText.text = "Damage: " + PlayerOne.jabDamageHead;
        staminaDamageText.text = "Stamina damage: " + 0;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.jabStaminaUseHead;
        accuracyStatText.text = "Accuracy: " + PlayerOne.jabAccuracyHead;
        guardStatText.text = "Guard (def): " + PlayerTwo.guardHead;
    }

    public void mouseOverJabBody()
    {
        actionDescritionText.text = buttonJabBodyText.text;
        damageText.text = "Damage: " + PlayerOne.jabDamageBody;
        staminaDamageText.text = "Stamina damage: " + PlayerOne.jabStaminaDamageBody;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.jabStaminaUseBody;
        accuracyStatText.text = "Accuracy: " + PlayerOne.jabAccuracyBody;
        guardStatText.text = "Guard (def): " + PlayerTwo.guardBody;
    }

    public void mouseOverCrossHead()
    {
        actionDescritionText.text = buttonCrossHeadText.text;
        damageText.text = "Damage: " + PlayerOne.crossDamageHead;
        staminaDamageText.text = "Stamina damage: " + 0;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.crossStaminaUseHead;
        accuracyStatText.text = "Accuracy: " + PlayerOne.crossAccuracyHead;
        guardStatText.text = "Guard (def): " + PlayerTwo.guardHead;
    }

    public void mouseOverCrossBody()
    {
        actionDescritionText.text = buttonCrossBodyText.text;
        damageText.text = "Damage: " + PlayerOne.crossDamageBody;
        staminaDamageText.text = "Stamina damage: " + PlayerOne.crossStaminaDamageBody; 
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.crossStaminaUseBody;
        accuracyStatText.text = "Accuracy: " + PlayerOne.crossAccuracyBody;
        guardStatText.text = "Guard (def): " + PlayerTwo.guardBody;
    }

    public void OnMouseExit()
    {
        actionDescritionText.text = "";
        damageText.text = "Damage: ";
        staminaDamageText.text = "Stamina damage: ";
        staminaUsePlayerText.text = "Stamina use: ";
        accuracyStatText.text = "Accuracy: ";
        guardStatText.text = "Guard (def): ";
    }
}
