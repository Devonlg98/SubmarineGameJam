using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovement : MonoBehaviour
{
    private damageManager damageScript;
    private LaunchTorpedo torpedoScript;
    private Rigidbody subBody;
    private float moveSpeed = 30;
    private float moveAcceleration = 0f;
    private float xTurnSpeed = 10f;
    private float zTurnSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        damageScript = FindObjectOfType<damageManager>();
        subBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            torpedoScript.Launch();
        }
        moveAcceleration += Time.deltaTime;
        Mathf.Clamp(moveAcceleration, -30, 50);
        subBody.AddRelativeForce(0, 0, moveSpeed + moveAcceleration, ForceMode.Force);
        float xAxis = transform.localEulerAngles.x;
        if (xAxis > 180)
        {
            xAxis -= 360;
        }
        float zAxis = transform.localEulerAngles.z;
        if (zAxis > 180)
        {
            zAxis -= 360;
        }
        print(zAxis);
        subBody.angularDrag = (Mathf.Abs(xAxis + zAxis) + 0.5f) / 10;
        subBody.AddTorque(transform.TransformDirection(-Input.GetAxis("Vertical") * xTurnSpeed, 0, -zAxis) +
            new Vector3(0, Input.GetAxis("Horizontal") * zTurnSpeed, 0), ForceMode.Force);
        subBody.AddTorque(-xAxis / 3, 0, 0, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint point = collision.GetContact(0);
        subBody.AddExplosionForce(30, point.point, 100, 0, ForceMode.Impulse);
        damageScript.createDamage();
    }
}
