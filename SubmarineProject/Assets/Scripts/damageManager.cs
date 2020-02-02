using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageManager : MonoBehaviour
{
    public damageEnable[] type;
    public int damages = 0;
	public float targetTime = 5f;
	public lightChange light;
    private void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0f)
        {
            Debug.Log("please");
            createDamage();
            targetTime = 5f;
        }
		if (damages >= 3)
		{
			light.changeLights();
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
