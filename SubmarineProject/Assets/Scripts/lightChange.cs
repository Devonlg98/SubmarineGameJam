using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChange : MonoBehaviour
{
    public Light[] shipLights;
    public Color baseColor;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            changeLightsRed();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            changeLightsWhite();
        }
    }
    void changeLightsRed() 
    {
        for (int i = 0; i < shipLights.Length; i++)
        {
            shipLights[i].color = Color.red;
        }
    }

    void changeLightsWhite()
    {
        for (int i = 0; i < shipLights.Length; i++)
        {
            shipLights[i].color = baseColor;
        }
    }
}
