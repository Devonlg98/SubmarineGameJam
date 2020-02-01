using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovement : MonoBehaviour
{
    private Rigidbody subBody;
    private float moveSpeed = 10;
    private float moveAcceleration = 0f;
    private float turnSpeed = 0.25f;
    private float xTurnAcceleration = 0f;
    private float yTurnAcceleration = 0f;
    // Start is called before the first frame update
    void Start()
    {
        subBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveAcceleration += Time.deltaTime;
        Mathf.Clamp(moveAcceleration, -12, 20);
        subBody.velocity = transform.TransformDirection(0, moveSpeed + moveAcceleration, 0);
        if (Input.GetAxis("Vertical") != 0)
        {
            xTurnAcceleration += Input.GetAxis("Vertical") * Time.deltaTime;
            Mathf.Clamp(xTurnAcceleration, -0.1f, 0.1f);
        }
        else
        {
            xTurnAcceleration *= Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            yTurnAcceleration += Input.GetAxis("Horizontal") * Time.deltaTime;
            Mathf.Clamp(yTurnAcceleration, -0.1f, 0.1f);
        }
        else
        {
            yTurnAcceleration *= Time.deltaTime;
        }
        subBody.angularVelocity = transform.TransformDirection((-Input.GetAxis("Vertical") * turnSpeed - xTurnAcceleration) + ((90 - transform.localRotation.eulerAngles.x) * (90 - transform.localRotation.eulerAngles.x) / 1000), 0, 0) +
            new Vector3 (0, Input.GetAxis("Horizontal") * turnSpeed + yTurnAcceleration, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        moveAcceleration = -12;
    }
}
