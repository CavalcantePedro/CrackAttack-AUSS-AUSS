using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCode : MonoBehaviour {
 
	[SerializeField] private float ballForce;
	[SerializeField] public Rigidbody2D rb;
	[SerializeField] private CircleCollider2D circleColl;
	[SerializeField] private AudioSource audioSource;

	[SerializeField] private float xRandomForce;
	[SerializeField] private float yRandomForce;

	void OnEnable() {
		Shot();
		Invoke("IgnoreCollision", 0.25f);
	}

    #region PhysicsUpdate
    void OnTriggerEnter2D (Collider2D coll)
	{
		if(coll.gameObject.tag == "ScreenBottom")
		{
			BallHitedBottom();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		audioSource.Play();
		

		switch(coll.gameObject.tag)
		{

			case "Top":
				rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y * -1);
				GenerateForce();
				if(rb.velocity.x > 0)
				{
				rb.AddForce(new Vector2(xRandomForce, yRandomForce));
				}
				else
				{rb.AddForce(new Vector2(-xRandomForce, yRandomForce));

				} 
				break;

			case "Player":

				if(rb.velocity.y < 0)
				{
				rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y * -1);
				}

				else if (rb.velocity.y > 0)
				{
					rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y);
				}

				GenerateForce();
				if(Singleton.GetInstance.playerScript.rb.velocity.x > 0)
				{
					//tem q ir pra direita
					if(xRandomForce < 0)
					{
						xRandomForce = xRandomForce * -1;
					}
				}

				if(Singleton.GetInstance.playerScript.rb.velocity.x < 0)
				{
					//tem q ir pra esquerda
					if(xRandomForce > 0)
					{
						xRandomForce = xRandomForce * -1;
					}
				}
				

				rb.AddForce(new Vector2(xRandomForce, yRandomForce));	
				break;

			case "Left":
				GenerateForce();
				rb.AddForce(new Vector2(-xRandomForce, yRandomForce));
				break;

			case "Right":
				GenerateForce();
				rb.AddForce(new Vector2(xRandomForce, yRandomForce));
				break;
		}
	}

	void BallHitedBottom()
	{
		//Get instance;
			Singleton instance = Singleton.GetInstance;
			AudioManager.instance.Play("MissedBall");
			 if(PlayerPrefs.GetInt("Language") == 1)
			{
				//Se  estiver em portugues
				int randomPlay = Random.Range(1,3);
				switch(randomPlay)
					{
				 		case 1:
					 	AudioManager.instance.Play("BR_MissedBall1");
						break;

						case 2:
					 	AudioManager.instance.Play("BR_MissedBall2");
						break;

						case 3:
					 	AudioManager.instance.Play("BR_MissedBall3");
						break;
					}
			}     
			else
			{
				//Se  estiver em ingls
				int randomPlay = Random.Range(1,3);
				switch(randomPlay)
					{
				 		case 1:
					 	AudioManager.instance.Play("EN_MissedBall1");
						break;

						case 2:
					 	AudioManager.instance.Play("EN_MissedBall2");
						break;

						case 3:
					 	AudioManager.instance.Play("EN_MissedBall3");
						break;
					}

			}
            
			instance.cameraScript.CameraShake();
			instance.playerScript.health -= 1;
			instance.healthUI.LifeCheck(Singleton.GetInstance.playerScript.health);
			instance.playerScript.ballsHitted = 0;
			instance.playerScript.activeBall--;
			gameObject.SetActive(false);
	}

    void FixedUpdate()
    {
		//Clamp velocity;
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

	void GenerateForce()
	{
		if(rb.velocity.y > 0)
		{
			xRandomForce = Random.Range(50,276);
			yRandomForce = ballForce - xRandomForce;
		}

		else if(rb.velocity.y < 0)
		{
			xRandomForce = Random.Range(-275,-51 );
			yRandomForce = (ballForce - xRandomForce) *-1;
		}

	}

	void OnDestroy() {
		
	}

	void IgnoreCollision(){
		//Ignore collision in the shot;
		circleColl.enabled = true;
	}
    #endregion Functions
}