using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BelHealth : MonoBehaviour
{
	public Image healthBar;
	public int hp = 10;
	
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
		hp = Mathf.Clamp(hp,0,10);
		float _hp = (float)hp;
        healthBar.rectTransform.localScale = new Vector3((_hp/10f),1,1);
    }
}
