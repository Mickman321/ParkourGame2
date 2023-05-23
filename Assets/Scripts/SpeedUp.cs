using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerupBase
{
    [SerializeField]
    private float SpeedUpTimeCounter;
    private bool isSpeedUp;
    public float SpeedUpTime;

    public override void Activate(PlayerMovement player)
    {
        player.speed *= 2;
        base.Activate(player); 
    } // det h�r �r en speedboost power up den �rver fr�n powerupbase och sen l�gger till unika funktioner till poweruppbase utan att r�ra powerupbase scripten.

}
