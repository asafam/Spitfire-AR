using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Combat))]
public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    public float rotationalDamp = 5f;
    public float lookRadius = 10f;
    public float stoppingDistance = 0.002f;

    private Transform target;
    private Combat combat;
    private ARSessionOrigin aRSessionOrigin;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        combat = GetComponent<Combat>();

        aRSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            if (distance > stoppingDistance)
            {
                FaceTarget();
                ChaseTarget();
            }
        }

        Pathfinding();
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction); //new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationalDamp * Time.deltaTime);
    }

    private void ChaseTarget()
    {
        Vector3 newPosition = transform.position + transform.forward * speed * Time.deltaTime;
        // float y = Mathf.Min(Mathf.Max(newPosition.y, transform.position.y), target.position.y + 1); // limit the y 
        // transform.position = new Vector3(newPosition.x, y, newPosition.z);
        transform.position = newPosition;
    }

    private void Pathfinding()
    {
        if (aRSessionOrigin)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            aRSessionOrigin.GetComponent<ARRaycastManager>().Raycast(transform.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.All);

            if (hits.Count > 0)
            {
                Debug.Log("Proximity alert!");
                Vector3 direction = ChooseDirection();
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationalDamp * Time.deltaTime);
            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.2f))
            {
                if (hit.collider.tag == "Player") 
                {
                    return;
                }

                Debug.Log("Proximity alert!");
                Vector3 direction = ChooseDirection();
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    private Vector3 ChooseDirection()
    {
        System.Random rand = new System.Random();
        Vector3[] directions = { transform.forward, -transform.forward, transform.right, -transform.right };
        Vector3 direction = directions[rand.Next(0, directions.Length - 1)];
        return direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Health myHealth = GetComponent<Health>();
        if (myHealth != null)
        {
            myHealth.ModifyHealth(-1 * int.MaxValue);
        }
    }
}
