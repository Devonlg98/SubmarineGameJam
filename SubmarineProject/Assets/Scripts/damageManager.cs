using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageManager : MonoBehaviour
{
    public damageEnable[] type;
    public int damages = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            createDamage();
        }
    }

    public void createDamage() 
    {
        if (damages == 15)
        {

        }
        else 
        {
            int enabledType = Random.Range(0, 3);
            type[enabledType].enableDamage();
        }        
    }
    public void damageCount() 
    {
        damages++;
    }
    public void damageRepair()
    {
        damages--;
    }
}
