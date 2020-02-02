using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    Rigidbody torpedo;

    void Start()
    {
        torpedo = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        torpedo.AddRelativeForce(0, 30, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
