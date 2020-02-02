using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BelPlayer : MonoBehaviour
{
	public Camera camera;
	private Repair rep;
	private CharacterController cc;
	//joystick values
	private float moveX = 0f;
	private float moveY = 0f;
	private float cameraX = 0f;
	private float cameraY = 0f;
	private bool button = false;
	//game-side movement values
	private float speed = 6.0f;
	private float camSpeed = 120.0f;
	private float speedMult = 1.0f;
	public int playerNum; //sets the controls based on player
	//Related to the repair system
	private int repType = 0;
	private Ray look;//where you're looking
	private RaycastHit looking;//what you're looking at
	public AudioClip[] repSounds;
	private AudioSource repSource;
	//UI
	private Image crosshair;
	public Sprite cross;
	public Sprite cross_;
    // Start is called before the first frame update
    void Start()
    {
		rep = GetComponent<Repair>();
		cc = GetComponent<CharacterController>();
		repSource = GetComponent<AudioSource>();
		crosshair = GameObject.Find("Cross_P" + playerNum).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
		
		//UPDATE CONTROLS
		button = Input.GetButtonDown("Button_P" + playerNum);
		moveX = (Input.GetAxis("MoveX_P" + playerNum) * speed) * Time.deltaTime;
		moveY = (Input.GetAxis("MoveY_P" + playerNum) * speed) * Time.deltaTime;
		cameraX = (Input.GetAxis("CameraX_P" + playerNum) * camSpeed) * Time.deltaTime;
		cameraY += (Input.GetAxis("CameraY_P" + playerNum) * camSpeed) * Time.deltaTime;
		cameraY = Mathf.Clamp(cameraY, -90, 75);
        //ROTATION / CAMERA CONTROL
		transform.Rotate(0,cameraX,0);//Rotate player left and right
		camera.transform.localEulerAngles = new Vector3(cameraY,0,0); //Rotate camera up and down
		//MOVEMENT
		if (repType == 4)
		{
			speedMult = 0.5f;
		}
		else
		{
			speedMult = 1.0f;
		}
		Vector3 movin = new Vector3((moveX)*speedMult,0,(moveY)*speedMult);
		movin = this.transform.TransformDirection(movin); //make sure it points in the rotation direction!
		cc.Move(movin);//the movement itself
		//REPAIR STUFF
		look = new Ray(camera.transform.position,camera.transform.forward);
		//set the bullshit
		if (!rep.fireEx.activeSelf && !rep.wrench.activeSelf && !rep.ductTape.activeSelf && !rep.torpedo.activeSelf)
		{
			repType = 0;
		}
		else
		{
			if (rep.fireEx.activeSelf) { repType = 1; }
			if (rep.wrench.activeSelf) { repType = 2; }
			if (rep.ductTape.activeSelf) { repType = 3; }
			if (rep.torpedo.activeSelf) { repType = 4; }
		}
		//Check for damages
		if (Physics.Raycast(look, out looking, 2.0f))
		{
			if (looking.collider != null)
			{
				if ((button))
				{
					if ((repType > 0) && (looking.collider.tag == "Damage" || looking.collider.tag == "torpedo"))
					{
						rep.Use();
						crosshair.sprite = cross;
						crosshair.color = Color.white;
						if ((repType == 1 && looking.collider.transform.parent.tag == "fireEx") ||
							(repType == 2 && looking.collider.transform.parent.tag == "wrench") ||
							(repType == 3 && looking.collider.transform.parent.tag == "ductTape"))
						{
							repSource.PlayOneShot(repSounds[repType-1]);
							looking.collider.GetComponent<damageFixer>().Fix();
							Debug.Log("all better!");
						}
                        else if (repType == 4 && looking.collider.tag == "torpedo")
                        {
                            Debug.Log("I GOT TA TOPETO!");
                        }
						else
						{
							Debug.Log("uh oh!");
						}
					}
					if ((repType != 4))
					{
						if ((looking.collider.tag == "fireExPickUp"))
						{
							rep.Pickup(1);
						}
						if ((looking.collider.tag == "wrenchPickUp"))
						{
							rep.Pickup(2);
						}
						if ((looking.collider.tag == "ductTapePickUp"))
						{
							rep.Pickup(3);
						}
						if ((looking.collider.tag == "torpedoPickUp"))
						{
							rep.Pickup(4);
						}
					}
				}
				if (looking.collider.tag == "Damage" ||
					looking.collider.tag == "fireExPickUp" ||
					looking.collider.tag == "wrenchPickUp" ||
					looking.collider.tag == "ductTapePickUp" ||
                    looking.collider.tag == "torpedo")
                {
						crosshair.sprite = cross_;
					}
				if (looking.collider.tag != "Damage" &&
					looking.collider.tag != "fireExPickUp" &&
					looking.collider.tag != "wrenchPickUp" &&
					looking.collider.tag != "ductTapePickUp" ||
                    looking.collider.tag == "torpedo") {
						crosshair.sprite = cross;
						crosshair.color = Color.white;
					}
				if (((repType > 0) && (repType < 4) && (looking.collider.tag == "Damage")) || ((repType == 4) && (looking.collider.tag == "torpedo")))
				{
					crosshair.color = Color.cyan;
				}
				else
				{
					crosshair.color = Color.white;
				}
			}
			if (looking.collider == null)
			{
				crosshair.sprite = cross;
				crosshair.color = Color.white;
			}
		}
		else
		{
			crosshair.sprite = cross;
			crosshair.color = Color.white;
		}
    }
}
