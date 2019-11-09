using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public GameObject explosion;
    public AudioSource explosionSound;

    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
    }

    public override void Die()
    {
        base.Die();

        // Death animation
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosionSound.Play(0);
        // yield return new WaitForSeconds(1);
        Destroy(gameObject, 0.5f);

        EnemyManager.instance.EnemyKilled(gameObject);
    }
}
