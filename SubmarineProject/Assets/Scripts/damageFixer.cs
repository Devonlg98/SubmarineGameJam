using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageFixer : MonoBehaviour
{
	private damageEnable en;
    // Start is called before the first frame update
    void Start()
    {
        en = GetComponentInParent<damageEnable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Fix()
	{
		gameObject.SetActive(false);
		en.getRid();
		
	}
}
