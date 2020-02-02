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
            torpedo = Instantiate(torpedo, transform.position, transform.rotation);
            torpedo.transform.position += transform.TransformDirection(0, -1, 0);
            torpedo.transform.localEulerAngles += new Vector3(90, 0, 0);
            isLoaded = false;
        }
    }
}
