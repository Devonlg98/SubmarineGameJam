using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageManager : MonoBehaviour
{
    public damageEnable[] type;

    public void createDamage() 
    {
        int enabledType = Random.Range(0, 2);
        type[enabledType].enableDamage();
    }
}
