using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MoveController {

	public GameObject joyObject;
	private Transform joyTransform;
	private bool isShooting;

	void Awake() {
		var obj = Instantiate(joyObject, Vector3.zero, Quaternion.identity);
		joyTransform = obj.transform;
	}

	void OnEnable() {
		ballShot.SetJoystick(joyTransform);
	}

	void Start() {
		ballShot.isJoystick = true;
		rb = paddle.rb;
		speed = paddle.speed;
	}
	
	void Update () {

		if(paddle.ballCount > 0 && ballShot.rotZ > 0){
			if(Input.GetButtonDown("Shot")){
				joyTransform.position = Vector3.zero;
				ballShot.angleArrow.SetActive(true);
				isShooting = true;
				ballShot.changeColor = false;
			}
			if(Input.GetButtonUp("Shot")){
				ballShot.angleArrow.SetActive(false);
				ballShot.Shot(paddle);
				isShooting = false;
				ballShot.changeColor = true;
			}
		}

		if(!isShooting)
			Move();
		else
		{
			MoveTarget();
			rb.velocity = Vector2.zero;
		}
	}

	void Move(){
		float x = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(x * (speed * 2) * Time.deltaTime, 0);
	}

	void MoveTarget(){
		float x = Input.GetAxisRaw("Horizontal");
		joyTransform.Translate(x * (speed * 0.001f), 0f, 0f);

		Vector3 position = joyTransform.position;
		position = new Vector3(Mathf.Clamp(position.x, -5f, 5f), 0, 0);
		joyTransform.position = position;
	}
}
