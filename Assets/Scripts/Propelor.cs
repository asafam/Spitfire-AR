using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propelor : MonoBehaviour
{
    public bool isEnemy = false;
    
    void Update()
    {
        if (isEnemy)
        {
            transform.Rotate(new Vector3(0, 0, 30), Space.Self);
        }
        else
        {
            transform.Rotate(new Vector3(0, 20, 0), Space.Self);
        }
    }
}
