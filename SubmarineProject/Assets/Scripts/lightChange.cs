using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChange : MonoBehaviour
{
    public Light[] shipLights;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            changeLights();
        }
    }
    void changeLights() 
    {
        for (int i = 0; i < shipLights.Length; i++)
        {
            shipLights[i].color = Color.red;
        }
    }
}
