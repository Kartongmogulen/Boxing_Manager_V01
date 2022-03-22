using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headHealthUpdate : MonoBehaviour
{
   public void updateHeadHealth(player Player, int healthComsumed)
    {
        
        Player.headHealthNow -= healthComsumed;
        Player.damageTakenDuringRound += healthComsumed;

        if (Player.headHealthNow <= 0)
        {
            Player.fighterStateUpdate(true);
            Player.headHealthNow = Player.headHealthStart;
        }
    }
}
