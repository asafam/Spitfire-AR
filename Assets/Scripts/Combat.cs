using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Health)), RequireComponent(typeof(Power))]
public class Combat : MonoBehaviour
{
    public event Action<GameObject> OnAttack = delegate { }; // callback delegate to notify on attack - can be used , for example, to setup animation
    public float attackSpeed = 1f;
    public float attackDelay = 0.6f;
    public AudioSource shootingAudio;
    private float attackCooldown = 0f; // time in seconds in which the enxt attack will take place
    private Transform target;
    private Health myHealth;
    private Power myPower;
    private bool isEnemy;
    private bool isPlayer;
    private ARSessionOrigin aRSessionOrigin;
    private LineRenderer gunfireLine;


    private void Start()
    {
        myHealth = GetComponent<Health>();
        myPower = GetComponent<Power>();
        isEnemy = GetComponent<Enemy>() != null;
        isPlayer = GetComponent<Player>() != null;
        gunfireLine = GetComponent<LineRenderer>();
        aRSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        gunfireLine.SetPosition(0, transform.position);
    }
    public void Attack()
    {
        Debug.DrawLine(transform.position, transform.forward * 4, Color.yellow);
        if (attackCooldown <= 0)
        {
            GameObject opponent = OpponentInRange();

            if (opponent != null && IsFoe(opponent))
            {
                if (isPlayer)
                {
                    Debug.Log("Shooting to kill!");
                }
                Debug.DrawLine(transform.position, transform.forward * 4, Color.red);
                Health opponentHealth = opponent.GetComponent<Health>();
                StartCoroutine(DoDamage(opponentHealth, attackDelay));

                if (OnAttack != null)
                {
                    OnAttack(opponent);
                }
            }

            attackCooldown = 1f / attackSpeed;
        }
    }

    public bool IsFoe(GameObject opponent)
    {
        bool isOpponentEnemy = opponent.GetComponent<Enemy>() != null;
        bool isOpponentPlayer = opponent.GetComponent<Player>() != null;
        // Debug.Log("I'm " + (isPlayer ? "Player" : "Enemy"));
        // Debug.Log("He's " + (isOpponentPlayer ? "Player" : "Enemy"));
        return (isEnemy && isOpponentPlayer) || (isPlayer && isOpponentEnemy);
    }

    private GameObject OpponentInRange()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 1, transform.TransformDirection(Vector3.forward), out hit, myPower.maxDistance))
        {
            if (isPlayer)
            {
                Debug.Log("Enemy in range!!! Shoot!");
            }
            
            gunfireLine.SetPosition(1, hit.point);

            return hit.collider.gameObject;
        }
        return null;
    }

    private IEnumerator DoDamage(Health opponentHealth, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (shootingAudio != null)
        {
            shootingAudio.Play();
        }

        gunfireLine.enabled = true;
        yield return 1;
        gunfireLine.enabled = false;

        if (shootingAudio != null)
        {
            shootingAudio.Stop();
        }

        if (opponentHealth != null)
        {
            opponentHealth.ModifyHealth(-1 * myPower.damage);
        }
    }
}
