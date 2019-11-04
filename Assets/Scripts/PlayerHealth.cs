using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void Die()
    {
        base.Die();
        
        AudioSource sound = gameObject.GetComponentInChildren<AudioSource>();
        // sound.enabled = false;

        PlayerManager.instance.KillPlayer();
    }
}
