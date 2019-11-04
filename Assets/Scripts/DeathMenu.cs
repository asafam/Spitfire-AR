using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject MainUI;

    public void StartSinglePlayer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.instance.StartGame();
    }

    public void ExitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
