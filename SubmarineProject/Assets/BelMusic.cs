using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelMusic : MonoBehaviour
{
	private BelHealth health;
	private AudioSource mus;
	public AudioClip[] music;
	int other = 10;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<BelHealth>();
		mus = GetComponent<AudioSource>();
		mus.clip = music[0];
		other = health.hp;
    }

    // Update is called once per frame
    void Update()
    {
		if (health.hp != other)
		{
			switch (health.hp)
			{
				case 10:
					SetDaSong(0);
					break;
				case 9:
					SetDaSong(0);
					break;
				case 8:
					SetDaSong(1);
					break;
				case 7:
					SetDaSong(1);
					break;
				case 6:
					SetDaSong(2);
					break;
				case 5:
					SetDaSong(2);
					break;
				case 4:
					SetDaSong(2);
					break;
				case 3:
					SetDaSong(3);
					break;
				default:
					SetDaSong(3);
					break;
			}
			other = health.hp;
		}
		
    }
	void SetDaSong(int which)
	{
		float track = (mus.time / (mus.clip.length));
		if (mus.clip != music[which])
		{
			mus.clip = music[which];
			mus.time = (track * music[which].length);
			mus.Play();
		}
	}
}
