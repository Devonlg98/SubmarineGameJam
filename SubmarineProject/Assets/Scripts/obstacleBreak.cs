using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBreak : MonoBehaviour
{
    public float targetTime = 1f;
    public damageManager damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "sub")
        {
            Destroy(gameObject);
            damage.createDamage();
        }
    }
    // Update is called once per frame
    void Update()
    {
       


    }
}
