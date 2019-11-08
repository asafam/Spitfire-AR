using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject winhUI;
    public GameObject deathUI;

    public GameObject scoreGameObject;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable() 
    {
        
    }

    private void Start() {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        PlayerManager.instance.ResetPlayer();

        scoreGameObject.SetActive(true);
        scoreGameObject.GetComponent<Score>().ResetTimer();

        Register();
    }

    private void WonGame()
    {
        Debug.Log("EndGame: " + deathUI.ToString());
        Time.timeScale = 0f;

        deathUI.SetActive(true);
        scoreGameObject.SetActive(false);

        Deregister();
    }

    private void LostGame()
    {
        Debug.Log("EndGame: " + deathUI.ToString());
        Time.timeScale = 0f;

        deathUI.SetActive(true);
        scoreGameObject.SetActive(false);

        Deregister();
    }

    private void Register()
    {
        PlayerManager.instance.OnPlayerWon += WonGame;
        PlayerManager.instance.OnPlayerKilled += LostGame;
    }

    private void Deregister()
    {
        PlayerManager.instance.OnPlayerWon -= WonGame;
        PlayerManager.instance.OnPlayerKilled -= LostGame;
    }
}
