using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Die()
    {
        base.Die();

        // Add death animation


        // if (opponentHealth.currentHealth < 5) {
        //     gameObject.GetComponent<Rigidbody>().useGravity = true;
        // }
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
