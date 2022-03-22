using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class knockdownClock : MonoBehaviour
{
    //Hantera när en spelare är knockad och ska ta sig upp
    public int seconds;
    public int timePlayerGetsUp;
    public TextMeshProUGUI actionCompletionText;


    public void startTimer(player knockedDownPlayer)
    {
        seconds = 0;
        StartCoroutine(timer(knockedDownPlayer));
    }

    IEnumerator timer(player knockedDownPlayer)
    {

        if (seconds >= 11)
        {
            yield break;
        }
        yield return new WaitForSeconds(1);
        secondsCounter(knockedDownPlayer);
    }

    public void secondsCounter(player knockedDownPlayer)
    {
        //Debug.Log(seconds);
        seconds++;
        actionCompletionText.text = "" + seconds;
        timePlayerGetsUp = GetComponent<knockdown>().timePlayerGetsUp;

        if (timePlayerGetsUp <= 10)
        {

            if (timePlayerGetsUp == seconds)
            {
                actionCompletionText.text = knockedDownPlayer.name + " gets up!";
                knockedDownPlayer.fighterStateNow = fighterState.None;

                if (knockedDownPlayer.name == "David")//MÅSTE ÄNDRAS TILL NAMN SPELARE ETT OM MAN ÄNDRAR SPELARENS NAMN
                {

                }
                else
                //GetComponent<fightManager>().playerTwosTurnAfterKnockdown();
                
                return;
            }
            else
                StartCoroutine(timer(knockedDownPlayer));
        }
        else
            if (timePlayerGetsUp == seconds)
        {
            actionCompletionText.text = knockedDownPlayer.name + " did not get up!";
            knockedDownPlayer.fighterStateNow = fighterState.None;
            return;
        }
        else
            StartCoroutine(timer(knockedDownPlayer));

    }
   
}


