using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class staminaUpdate : MonoBehaviour
{
    public void updateStamina(player Player, int staminaUse)
    {
        Player.staminaHealthNow -= staminaUse;
        
}
}
