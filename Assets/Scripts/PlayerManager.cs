using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject player;

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

    public void PlayerKilled()
    {
        GameManager.instance.LostGame();
    }

    public void PlayerLanded()
    {
        GameManager.instance.WonGame();
    }
}
