using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class succedOrNotAction : MonoBehaviour
{
    int randomAttacker;
    int randomDefender;
    bool succedOrNot;

    public bool action(int attackerStat, int defenderStat, bool head)
    {

        //Debug.Log("Attacker accuracy: " + attackerStat);
        //Debug.Log("Defender Guard: " + defenderStat);
        //Will the action succed?
        if (head == true)
        {
            randomAttacker = Random.Range(0, attackerStat);
            //Debug.Log("Attacker Roll: " + randomAttacker);
            randomDefender = Random.Range(0, defenderStat);
            //Debug.Log("Defender Roll: " + randomDefender);
        }

        else
        {
            //Debug.Log("succedOrNotAction Body");
            randomAttacker = Random.Range(0, attackerStat);
            randomDefender = Random.Range(0, defenderStat);
        }

        if (randomAttacker > randomDefender)
        {
            succedOrNot = true;
        }
        else
            succedOrNot = false;

        //Debug.Log("succedOrNotAction Body:" + succedOrNot);

        return succedOrNot;
    }

}
