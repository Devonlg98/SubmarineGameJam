using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * 5;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Torpedo explodes and destroys the any obstacles it hits.
        Destroy(gameObject);
    }
}
