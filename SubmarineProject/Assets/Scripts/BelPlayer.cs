using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelPlayer : MonoBehaviour
{
	public Camera camera;
	private CharacterController cc;
	//joystick axis values
	private float moveX = 0f;
	private float moveY = 0f;
	private float cameraX = 0f;
	private float cameraY = 0f;
	//game-side movement values
	private float speed = 6.0f;
	private float camSpeed = 120.0f;
	private float speedMult = 1.0f;
	public int playerNum;
    // Start is called before the first frame update
    void Start()
    {
		cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		moveX = (Input.GetAxis("MoveX_P" + playerNum) * speed) * Time.deltaTime;
		moveY = (Input.GetAxis("MoveY_P" + playerNum) * speed) * Time.deltaTime;
		cameraX = (Input.GetAxis("CameraX_P" + playerNum) * camSpeed) * Time.deltaTime;
		cameraY += (Input.GetAxis("CameraY_P" + playerNum) * camSpeed) * Time.deltaTime;
		cameraY = Mathf.Clamp(cameraY, -45, 45);
        //CAMERA CONTROL
		transform.Rotate(0,cameraX,0);//Rotate player around right stick X
		camera.transform.localEulerAngles = new Vector3(cameraY,0,0);
		//MOVEMENT
		Vector3 movin = new Vector3((moveX)*speedMult,0,(moveY)*speedMult);
		movin = this.transform.TransformDirection(movin);
		cc.Move(movin);
    }
}
