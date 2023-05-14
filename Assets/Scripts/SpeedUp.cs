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
    }

}
