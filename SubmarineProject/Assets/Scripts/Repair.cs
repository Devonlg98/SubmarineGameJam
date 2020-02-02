using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public GameObject fireEx;
    public GameObject wrench;
    public GameObject ductTape;
    public GameObject torpedo;



    // Start is called before the first frame update
    void Start()
    {
        wrench.gameObject.SetActive(false);
        fireEx.gameObject.SetActive(false);
        ductTape.gameObject.SetActive(false);
		torpedo.gameObject.SetActive(false);
        //bool boolin = true;
        //switch(boolin)
        //{
        //    case false:
        //        break;

        //}


    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "wrenchPickUp")
        {
            Debug.Log("picked up wrench");
            wrench.gameObject.SetActive(true);
            fireEx.gameObject.SetActive(false);
            ductTape.gameObject.SetActive(false);
            torpedo.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "fireExPickUp")
        {
            Debug.Log("picked up fire Extinguisher");
            fireEx.gameObject.SetActive(true);
            wrench.gameObject.SetActive(false);
            ductTape.gameObject.SetActive(false);
			torpedo.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "ductTapePickUp")
        {
            Debug.Log("picked up ductTape");
            ductTape.gameObject.SetActive(true);
            fireEx.gameObject.SetActive(false);
            wrench.gameObject.SetActive(false);
			torpedo.gameObject.SetActive(false);
        }
    }

    //Update is called once per frame
    void Update()
    {
    }
	public void Use()
	{
		wrench.gameObject.SetActive(false);
        fireEx.gameObject.SetActive(false);
        ductTape.gameObject.SetActive(false);
		torpedo.gameObject.SetActive(false);
	}
	public void Pickup(int which)
	{
		switch (which)
		{
			case 1:
				Debug.Log("picked up fire Extinguisher");
				fireEx.gameObject.SetActive(true);
				wrench.gameObject.SetActive(false);
				ductTape.gameObject.SetActive(false);
				torpedo.gameObject.SetActive(false);
				break;
			case 2:
				Debug.Log("picked up wrench");
				wrench.gameObject.SetActive(true);
				fireEx.gameObject.SetActive(false);
				ductTape.gameObject.SetActive(false);
				torpedo.gameObject.SetActive(false);
				break;
			case 3:
				Debug.Log("picked up ductTape");
				ductTape.gameObject.SetActive(true);
				fireEx.gameObject.SetActive(false);
				wrench.gameObject.SetActive(false);
				torpedo.gameObject.SetActive(false);
				break;
			case 4:
				Debug.Log("picked up torpedo");
				ductTape.gameObject.SetActive(false);
				fireEx.gameObject.SetActive(false);
				wrench.gameObject.SetActive(false);
				torpedo.gameObject.SetActive(true);
				break;
			default:
				Debug.Log("You can't pick that up idiot");
				break;
		}
	}
}


