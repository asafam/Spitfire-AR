using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
//The interval you want your player to be able to fire.
public float fireRate = 1f;
 
//The actual time the player will be able to fire.
private float nextFire;
private GameObject player;
private float distance;
private float minDist;
private GameObject closestEnemy;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = 0;
        minDist = float.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        // CHANGE THE 1ST PART OF THE IF TO BUTTON PRESS <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {        
            //If the player fired, reset the NextFire time to a new point in the future.
            nextFire = Time.time + fireRate;   

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                distance = Vector3.Distance(player.transform.position, enemy.transform.position);
                if (distance < minDist)
                {
                    minDist = distance;
                    closestEnemy = enemy;
                }
            }
            Destroy(closestEnemy);
        }
    }
}
