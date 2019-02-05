using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
 
    public int health;
    public int ballCount;
    public int ballsHitted;
    public int activeBall;
    public float speed;
    public Rigidbody2D rb;
    public Collider2D coll;
    public BallCount ballCountScript;
    public Animator plusOneBall;

    public Animator plusTwoBall;
    public Animator plusThreeBall;

    public ParticleSystem[] heartGainParticles;
  

	void Start (){
        health = 3;
        activeBall = 0;
        ballCount = 3;
        ballCountScript.UpdateUI(ballCount);
	}

    void Update()
    {      
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.7f ,2.7f) , transform.position.y);
        rb.velocity = new Vector2 (Mathf.Clamp(rb.velocity.x ,-speed * Time.deltaTime, speed * Time.deltaTime) , rb.velocity.y);
    }

    #region PhysicsUpdate
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Green" || coll.gameObject.tag == "Yellow" || coll.gameObject.tag == "Blue" || coll.gameObject.tag == "Pink")
        {
            ballsHitted++;
            AddingBalls();
        }

        if(coll.gameObject.tag == "CollectableHeart")
        {
            
            coll.gameObject.SetActive(false);
            if(health < 3)
            {
                health++;
                AddingHearts();
            }
        }
    }
    #endregion

    #region BallController
    void AddingBalls()
    {

      switch (ballsHitted)
      {
          case 1:
          if (ballCount < 8 && (ballCount + activeBall) < 8)
           {       
               AudioManager.instance.Play("PlusBall");
               plusOneBall.SetTrigger("appear");
               ballCountScript.UpdateUI(ballCount);
               
            }

           break;
     
          case 2:
          if (ballCount < 8 && (ballCount + activeBall) < 8)
            {
                AudioManager.instance.Play("PlusBall");
                plusTwoBall.SetTrigger("appear");
                ballCountScript.UpdateUI(ballCount);
            }
          break;

          case 3:
          ballsHitted = 0;
          if (ballCount < 8 && (ballCount + activeBall) < 8)
           {
               ballCount++;
               AudioManager.instance.Play("PlusBall");
               plusThreeBall.SetTrigger("appear");
                ballCountScript.UpdateUI(ballCount);
           }
          break;
     
      }
      //  if (ballsHitted == 1)
      //  {
            //Add a ball;
       //     ballsHitted = 0;
       //     if (ballCount < 8 && (ballCount + activeBall) < 8)
       //     {
        //        ballCount++;
        //        AudioManager.instance.Play("PlusBall");
         //       plusOneBall.SetTrigger("appear");
         //       ballCountScript.UpdateUI(ballCount);
         //   }
      //  }
    }

    void AddingHearts()
    {
          for(int i=0;i<heartGainParticles.Length;i++)
        {
            heartGainParticles[i].Play();
        }
        Singleton.GetInstance.healthUI.LifeCheck(health);
    }
    
    public void DecreasingBalls()
    {
        activeBall++;
	    ballCount--;
		ballCountScript.UpdateUI(ballCount);
    }
    #endregion BallController
}