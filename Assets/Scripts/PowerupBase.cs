using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBase : MonoBehaviour
{
   public virtual void Activate(PlayerMovement player)
    {
        print("Power!");
        Destroy(gameObject);
    }
} // det h�r �r bass koden f�r alla power ups. alla power ups g�r detta.
