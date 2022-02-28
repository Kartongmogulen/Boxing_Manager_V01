using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jabFight : MonoBehaviour
{

    int randomPlayerOne;
    int randomPlayerTwo;
    bool jabHitOrNot;

    public bool jab(player attacker, player defender, bool head)
    {
        //Will the jab hit
        if (head == true)
        {
            randomPlayerOne = Random.Range(0, attacker.jabAccuracyHead);
            randomPlayerTwo = Random.Range(0, defender.guardHead);
        }

        else
        {
            randomPlayerOne = Random.Range(0, attacker.jabAccuracyBody);
            randomPlayerTwo = Random.Range(0, defender.guardBody);
        }
       //Debug.Log("Player One Random: " + randomPlayerOne);
        //Debug.Log("Player Two Random: " + randomPlayerTwo);

        if (randomPlayerOne > randomPlayerTwo)
        {
            jabHitOrNot = true;
        }
        else
            jabHitOrNot = false;

        return jabHitOrNot;
    }

}
