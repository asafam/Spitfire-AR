using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject deathUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start() {
        Time.timeScale = 1f;

        PlayerManager.instance.OnPlayerWon += EndGame;
        PlayerManager.instance.OnPlayerKilled += EndGame;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        PlayerManager.instance.ResetPlayer();
    }

    private void EndGame()
    {
        Debug.Log("EndGame: " + deathUI.ToString());
        Time.timeScale = 0f;
        deathUI.SetActive(true);
    }
}
