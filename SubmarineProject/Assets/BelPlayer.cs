using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelPlayer : MonoBehaviour
{
	public Camera camera;
	private Rigidbody rb;
	private float moveX;
	private float moveY;
	private Vector2 move;
	private float cameraX;
	private float cameraY;
	private Vector2 cam;
	private float speed = 10.0f;
	private float camSpeed = 50.0f;
	private float speedMult = 1.0f;
	public int playerNum;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		moveX = Input.GetAxis("MoveX_P" + playerNum) * speed;
		moveY = Input.GetAxis("MoveY_P" + playerNum) * speed;
		cameraX = Input.GetAxis("CameraX_P" + playerNum) * camSpeed;
		cameraY = Input.GetAxis("CameraY_P" + playerNum) * camSpeed;
        //CAMERA CONTROL
		cam = new Vector2(cameraX*Time.deltaTime,cameraY*Time.deltaTime);
		move = new Vector2(moveX*Time.deltaTime,moveY*Time.deltaTime);
		transform.Rotate(0,(cameraX*Time.deltaTime),0);//Rotate player around right stick X
		camera.transform.Rotate((cameraY*Time.deltaTime),0,0);//Rotate camera around right stick Y
		transform.Translate((moveX*Time.deltaTime),0,(moveY*Time.deltaTime));
		//MOVEMENT
    }
}
