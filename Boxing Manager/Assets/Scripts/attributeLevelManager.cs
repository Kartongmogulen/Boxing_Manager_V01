using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attributeLevelManager : MonoBehaviour
{ 
    //Lvl zero values
    public List<int> bodyHealthByLvl;
    public List<int> headHealthByLvl;
    public List<int> staminaHealthByLvl;
    public List<int> staminaHealthRecoveryByLvl;
    //public int staminaHealthLvlZero;
    public int staminaRecoveryBetweenRoundsLvlZero;

    //Values that cant be changed

    //Diff mellan Jab och Cross
    public int jabLowerStaminaUse; //Lägre stamina use jämfört med Cross
    public int jabCrossDiffDamage; //Skillnad mellan damage mellan Cross och Jab

}
