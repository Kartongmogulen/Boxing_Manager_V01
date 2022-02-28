using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public string name;

    //HEALTH
    public int bodyHealthStart;
    public int bodyHealthNow;

    public int headHealthStart;
    public int headHealthNow;

    public int staminaHealthStart;
    public int staminaHealthNow;

    //ATTACK HEAD
    public int jabAccuracyHead;
    public int jabStaminaUseHead;
    public int jabDamageHead;

    public int crossAccuracyHead;
    public int crossStaminaUseHead;
    public int crossDamageHead;

    //ATTACK BODY
    public int jabAccuracyBody;
    public int jabStaminaUseBody;
    public int jabDamageBody;
    public int jabStaminaDamageBody;

    public int crossAccuracyBody;
    public int crossStaminaUseBody;
    public int crossDamageBody;
    public int crossStaminaDamageBody;

    //DEFENCE
    public int guardHead;
    public int guardBody;

    public void Start()
    {
        bodyHealthNow = bodyHealthStart;
        headHealthNow = headHealthStart;
        staminaHealthNow = staminaHealthStart;
        
    }

}
