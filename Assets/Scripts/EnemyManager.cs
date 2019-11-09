using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemyPrefab;
    public GameObject enemyMasterPrefab;
    public int enemiesCount = 0;

    private void Awake()
    {
        instance = this;
    }

    public void EnemyKilled(GameObject enemy)
    {
        enemiesCount++;

        if (enemy.GetComponent<EnemyAircraftCarrier>())
        {
            GameManager.instance.WonGame();
        }
    }
}
