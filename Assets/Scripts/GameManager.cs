using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject deathUI;

    public GameObject scoreGameObject;

    private void Awake()
    {
        instance = this;
    }

    private void Start() {
        Time.timeScale = 0f;

        PlayerManager.instance.OnPlayerWon += EndGame;
        PlayerManager.instance.OnPlayerKilled += EndGame;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        PlayerManager.instance.ResetPlayer();

        scoreGameObject.SetActive(true);
        scoreGameObject.GetComponent<Score>().ResetTimer();
    }

    private void EndGame()
    {
        Debug.Log("EndGame: " + deathUI.ToString());
        Time.timeScale = 0f;

        deathUI.SetActive(true);
        scoreGameObject.SetActive(false);

        PlayerManager.instance.OnPlayerWon -= EndGame;
        PlayerManager.instance.OnPlayerKilled -= EndGame;
    }
}
