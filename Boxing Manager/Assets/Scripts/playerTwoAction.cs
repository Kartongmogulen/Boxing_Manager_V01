using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoAction : MonoBehaviour
{
    //Avgör vad motståndaren kommer utföra för aktion
    public float randomNumb;
    int i;
    public int numberOfActionsAvailable;//Antal aktioner att välja på
    /// </summary>

    //Slumpar aktion
    public void randomized ()
    {
        randomNumb = Random.Range(0, 100);
        //randomNumb = 99;

        if (randomNumb <= 100 / numberOfActionsAvailable)
        {
            GetComponent<fightManager>().playerTwoCrossBody();
            Debug.Log("Cross Body" + i);
            i++;
        }
        
        if (randomNumb >= (100 / numberOfActionsAvailable) && randomNumb <= (100 / numberOfActionsAvailable)*2)
        {
            GetComponent<fightManager>().playerTwoJabHead();
            Debug.Log("Jab Body" + i);
            i++;
        }

        
        if (randomNumb >= (100 / numberOfActionsAvailable)*2 && randomNumb <= (100 / numberOfActionsAvailable)*3)
        {
            GetComponent<fightManager>().playerTwoJabBody();
            Debug.Log("Jab Body" + i);
            i++;
        }

        
         if (randomNumb >= (100 / numberOfActionsAvailable)*3 && randomNumb <= (100 / numberOfActionsAvailable)*4)
        {
            GetComponent<fightManager>().playerTwoCrossHead();
            Debug.Log("Cross Head" + i);
            i++;
        }
        

    }

    public void crossHead()
    {
        GetComponent<fightManager>().playerTwoCrossHead();
        i++;
    }

    public void jabHead()
    {
        GetComponent<fightManager>().playerTwoJabHead();
        i++;
    }

    public void jabBody()
    {
        GetComponent<fightManager>().playerTwoJabBody();
        i++;
    }

    public void crossBody()
    {
        GetComponent<fightManager>().playerTwoCrossBody();
        i++;
    }

}
