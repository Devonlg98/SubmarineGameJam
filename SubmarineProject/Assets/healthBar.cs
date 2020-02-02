using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public damageManager damageMan;
    public Image currentHealthBar;
    public Text ratioText;

    private float hitpoint = 10;
    private float maxHitPoint = 10;

    void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = hitpoint / maxHitPoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 10).ToString() + '%';

    }

    private void TakeDamage (float damage)
    {
            hitpoint -= damageMan.damages;
            if(hitpoint<0)
            {
                hitpoint = 0;
                Debug.Log("OOF!");
            }
        UpdateHealthBar();
    }
    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if(hitpoint>maxHitPoint)
        {
            hitpoint = maxHitPoint;
        }
        UpdateHealthBar();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
