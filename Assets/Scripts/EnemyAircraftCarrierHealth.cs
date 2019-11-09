using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftCarrierHealth : EnemyHealth
{
    public override void Die()
    {
        base.Die();

        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
