using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headHealthUpdate : MonoBehaviour
{
   public void updateHeadHealth(player Player, int healthComsumed)
    {
        Player.headHealthNow -= healthComsumed;
    }
}
