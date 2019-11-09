using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCarrier : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        PlayerManager.instance.PlayerLanded();
    }
    
}
