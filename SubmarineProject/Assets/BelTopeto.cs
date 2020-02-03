using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelTopeto : MonoBehaviour
{
    public LaunchTorpedo topeto;
    private AudioSource joe;
    public AudioClip dummy;
    // Start is called before the first frame update
    void Start()
    {
        joe = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IGotTaTopeto()
    {
        topeto.isLoaded = true;
        joe.PlayOneShot(dummy);
    }
}
