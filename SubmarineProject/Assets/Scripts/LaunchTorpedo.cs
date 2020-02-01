using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTorpedo : MonoBehaviour
{
    public GameObject torpedo;
    private bool isLoaded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Launch()
    {
        if (isLoaded == true)
        {
            Instantiate(torpedo, transform.position, transform.rotation);
            isLoaded = false;
        }
    }
}
