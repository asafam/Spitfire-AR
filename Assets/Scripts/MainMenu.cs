using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    
    void Start()
    {
        
    }
    
    public void StartSinglePlayer() {
        Debug.Log("StartSinglePlayer");
        panel.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void ExitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
