using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject player;
    public event Action OnPlayerKilled = delegate { };
    public event Action OnPlayerWon = delegate { };

    private void Awake()
    {
        instance = this;
    }

    public void ResetPlayer()
    {
        Debug.Log("ResetPlayer");
        player.GetComponent<PlayerController>().PlaceCharacter();
        player.GetComponent<Health>().ResetHealth();
        
        AudioSource sound = player.GetComponentInChildren<AudioSource>();
        // sound.enabled = true;
    }

    public void KillPlayer()
    {
        if (OnPlayerKilled != null)
        {
            OnPlayerKilled();
        }
    }

    public void Win()
    {
        if (OnPlayerWon != null)
        {
            OnPlayerWon();
        }
    }
}
