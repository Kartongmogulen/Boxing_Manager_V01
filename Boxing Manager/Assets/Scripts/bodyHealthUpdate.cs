using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyHealthUpdate : MonoBehaviour
{
    public void updateBodyHealth(player Player, int healthComsumed)
    {
        Player.bodyHealthNow -= healthComsumed;
        Player.damageTakenDuringRound += healthComsumed;

        if (Player.bodyHealthNow <= 0)
        {
            Player.fighterStateUpdate(true);
            Player.bodyHealthNow = Player.bodyHealthStart;
        }
    }
}
