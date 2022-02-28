using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyHealthUpdate : MonoBehaviour
{
    public void updateBodyHealth(player Player, int healthComsumed)
    {
        Player.bodyHealthNow -= healthComsumed;
    }
}
