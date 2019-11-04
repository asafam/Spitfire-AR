using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactionRadius = 2f; // how close the player need to be near the object in order to interact with it

    private bool isInteracting = false;

    public virtual void Interact()
    {
        Transform player = GetPlayer();
    }

    public virtual Transform GetPlayer()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        Transform player = GetPlayer();
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= interactionRadius)
        {
            if (!isInteracting)
            {
                Debug.Log("Start interaction");
            }
            Interact();
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
