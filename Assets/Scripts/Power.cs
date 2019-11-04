using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int damage = 5; // set with positive value - our combat function will handle reversing the sign for modifying the opponent's health
    public int crashDamage = 20;
    public float maxDistance = 20f;
    
    private int defaultDamage;

    private void Start()
    {
        defaultDamage = damage;
    }

    public void UpdateDamage(int newDamage)
    {
        damage = newDamage;
    }
}
