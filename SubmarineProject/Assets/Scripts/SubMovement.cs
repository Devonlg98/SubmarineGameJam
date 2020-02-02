using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovement : MonoBehaviour
{
    private damageManager damageScript;
    private LaunchTorpedo torpedoScript;
    private Rigidbody subBody;
    private float moveSpeed = 20;
    private float moveAcceleration = 0f;
    private float xTurnSpeed = 10f;
    private float zTurnSpeed = 5f;
    private float hitTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        damageScript = FindObjectOfType<damageManager>();
        torpedoScript = FindObjectOfType<LaunchTorpedo>();
        subBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Button_P1"))
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
        if (Input.GetAxis("MoveY_P1") == 0 && Input.GetAxis("MoveX_P1") == 0)
        {
            subBody.angularDrag = (Mathf.Abs(xAxis) + 0.5f);
        }
        else
        {
            subBody.angularDrag = (Mathf.Abs(xAxis) + 0.5f) / 10;
        }
        subBody.AddTorque(transform.TransformDirection(-Input.GetAxis("MoveY_P1") * xTurnSpeed, Input.GetAxis("MoveX_P1") * zTurnSpeed, 0), ForceMode.Force);
        subBody.AddRelativeTorque(-xAxis / 3, 0, 0, ForceMode.Force);
        transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hitTimer <= 0)
        {
            ContactPoint point = collision.GetContact(0);
            subBody.AddExplosionForce(30, point.point, 100, 0, ForceMode.Impulse);
            damageScript.createDamage();
            hitTimer = 2f;
        }
    }
}
