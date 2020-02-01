using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
		rep = GetComponent<Repair>();
		cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		//gui.SendMessage("Crosshair");
		//UPDATE CONTROLS
		button = Input.GetButtonDown("Button_P" + playerNum);
		moveX = (Input.GetAxis("MoveX_P" + playerNum) * speed) * Time.deltaTime;
		moveY = (Input.GetAxis("MoveY_P" + playerNum) * speed) * Time.deltaTime;
		cameraX = (Input.GetAxis("CameraX_P" + playerNum) * camSpeed) * Time.deltaTime;
		cameraY += (Input.GetAxis("CameraY_P" + playerNum) * camSpeed) * Time.deltaTime;
		cameraY = Mathf.Clamp(cameraY, -45, 45);
        //ROTATION / CAMERA CONTROL
		transform.Rotate(0,cameraX,0);//Rotate player left and right
		camera.transform.localEulerAngles = new Vector3(cameraY,0,0); //Rotate camera up and down
		//MOVEMENT
		Vector3 movin = new Vector3((moveX)*speedMult,0,(moveY)*speedMult);
		movin = this.transform.TransformDirection(movin); //make sure it points in the rotation direction!
		cc.Move(movin);//the movement itself
		//REPAIR STUFF
		look = new Ray(camera.transform.position,camera.transform.forward);
		if (Physics.Raycast(look, out looking))
		{
			if (looking.collider != null)
			{
				if (button) Debug.Log("ah!");
			}
		}
    }
}
