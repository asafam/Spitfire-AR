using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health)), RequireComponent(typeof(Combat))]
public class Enemy : Interactable
{
    private Health myHealth;

    private void Start() {
        myHealth = GetComponent<Health>();
    }

    public override void Interact()
    {
        base.Interact();

        Attack();
    }

    public override Transform GetPlayer()
    {
        return PlayerManager.instance.player.transform;
    }

    private void Attack()
    {
        Combat combat = GetComponent<Combat>();
        if (combat != null)
        {
            combat.Attack();
        }
    }

    private void HandleAttack(GameObject opponent)
    {
        // Add visual effects for attack
        // Play sounds
    }
}
