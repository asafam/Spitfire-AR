using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCarrier : MonoBehaviour
{
    public GameObject[] winScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerManager.instance.PlayerLanded();
            Time.timeScale = 0f;
            winScreen = GameObject.FindGameObjectsWithTag("winScreen");

            foreach (GameObject ws in winScreen)
            {
                ws.SetActive(true);
            }
        }
        
    }
    
}
