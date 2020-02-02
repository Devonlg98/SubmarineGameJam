using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTorpedo : MonoBehaviour
{
    public GameObject torpedo;
    private bool isLoaded = false;

    public void Launch()
    {
        if (isLoaded == true)
        {
            Instantiate(torpedo, transform.position, transform.rotation);
            transform.localEulerAngles += new Vector3(90, 0, 0);
            isLoaded = false;
        }
    }
}
