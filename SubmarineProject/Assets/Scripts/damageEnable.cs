using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnable : MonoBehaviour
{
    public GameObject[] damages;

    public void enableDamage() 
    {
        while (true) 
        { 
            int enabledElement = Random.Range(0,4);
            if (damages[enabledElement].activeSelf == true) 
            {
                continue;
            }
            damages[enabledElement].SetActive(true);
            break;
        }
    } 
}
