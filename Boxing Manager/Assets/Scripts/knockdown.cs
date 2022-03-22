using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockdown : MonoBehaviour
{
    //Styr om en spelare hamnar i Knockdown-state

    public int attackerRandomNumb;
    public int defenderRandomNumb;

    bool knockdownOrNot;

    public int timePlayerGetsUp;

    public bool willPlayerGetKnockdown(player attacker, player defender, bool head)
    {
    
        if (head == true)
        {
            attackerRandomNumb = Random.Range(0, attacker.crossKnockDownHead);
            defenderRandomNumb = Random.Range(0, defender.guardHead);

            if (attackerRandomNumb > defenderRandomNumb)
            {
                knockdownOrNot = true;
            }
        }
        //Debug.Log("knockdown state " + knockdownOrNot);
  
        return knockdownOrNot;
    }

    public void willPlayerGetUp(player defender)
    {
        Debug.Log("Will player get up");
        if (defender.knockdownCounter < 2)
        {
            timePlayerGetsUp = Random.Range(3, 5);
            Debug.Log("Time player get up: " + timePlayerGetsUp);
            GetComponent<knockdownClock>().startTimer(defender);
        }

        else
        {
            timePlayerGetsUp = 11;
            GetComponent<knockdownClock>().startTimer(defender);
        }
    }
}
