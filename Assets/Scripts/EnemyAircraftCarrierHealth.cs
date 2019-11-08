using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftCarrierHealth : Health
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
