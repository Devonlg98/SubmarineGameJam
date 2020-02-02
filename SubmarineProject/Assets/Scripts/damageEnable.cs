using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnable : MonoBehaviour
{
    public GameObject[] damages;
    public damageManager reset;
	public BelHealth health;
    int activeCount;
	private AudioSource sound;
	void Start()
	{
		sound = GetComponent<AudioSource>();
	}
	void Update()
	{
		if (activeCount >= 2)
		{
			sound.enabled = true;
		}
		else
		{
			sound.enabled = false;
		}
	}
    public void enableDamage() 
    {
        while (true) 
        {
            if (activeCount == 5) 
            {
                reset.createDamage();
                break;
            }

            int enabledElement = Random.Range(0,5);
            if (damages[enabledElement].activeSelf == true) 
            {
                continue;
            }
            damages[enabledElement].SetActive(true);
            reset.damageCount();
            activeCount++;
			health.hp--;
            break;
        }
    }
	public void getRid()
	{
		activeCount--;
		reset.damageRepair();
	}
}
