using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesCount = 4;
    public event Action OnEnemyKilled = delegate { };

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    public void KillEnemy()
    {
        enemiesCount--;
        enemiesCount = Mathf.Max(0, enemiesCount);
        
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
}
