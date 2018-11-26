using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCode : MonoBehaviour {
 
	[SerializeField] private float ballForce;
	[SerializeField] public Rigidbody2D rb;
	[SerializeField] private CircleCollider2D circleColl;
	[SerializeField] private AudioSource audioSource;

	void OnEnable() {
		Shot();
		Invoke("IgnoreCollision", 0.25f);
	}

    #region PhysicsUpdate
    void OnTriggerEnter2D (Collider2D coll)
	{
		if(coll.gameObject.tag == "ScreenBottom")
		{
			//Get instance;
			Singleton instance = Singleton.GetInstance;
            AudioManager.instance.Play("MissedBall");
			instance.cameraScript.CameraShake();
			instance.playerScript.health -= 1;
			instance.healthUI.LifeCheck(Singleton.GetInstance.playerScript.health);
			instance.playerScript.ballsHitted = 0;
			instance.playerScript.activeBall--;
			gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		audioSource.Play();
		float neg = Random.Range(-ballForce/4, -ballForce/8);
		float pos = Random.Range(0, ballForce);

		switch(coll.gameObject.tag){
			case "Top":
				rb.AddForce(new Vector2(neg, 0));
				break;
			case "ScreenBottom":
				rb.AddForce(new Vector2(pos, 0));
				break;

				case "Player":
				rb.AddForce(new Vector2(pos, 0));	
				break;
			case "Left":
				rb.AddForce(new Vector2(0, pos));
				break;
				case "Right":
				rb.AddForce(new Vector2(0, neg));
			break;
		}
	}


	

    void FixedUpdate()
    {
		//Clamp velocity;
        print(rb.velocity);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -3, 3), Mathf.Clamp(rb.velocity.y, -3, 3));   
    }
    #endregion PhysicsUpdate

    #region Functions
    void Shot(){
		//Shot direction;
		var rotationZ = Singleton.GetInstance.ballShot.rotZ;
		Vector3 dir = Quaternion.AngleAxis(rotationZ, Vector3.forward) * Vector3.right;
  		rb.AddForce(dir * ballForce);
	}

	void IgnoreCollision(){
		//Ignore collision in the shot;
		circleColl.enabled = true;
	}
    #endregion Functions
}