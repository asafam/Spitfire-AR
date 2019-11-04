using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;

    private void Attack()
    {
        Combat combat = GetComponent<Combat>();
        if (combat != null)
        {
            combat.Attack();
        }
    }
    
}
