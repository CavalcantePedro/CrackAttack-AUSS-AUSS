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
    }
    #endregion

    #region BallController
    void AddingBalls()
    {
        if (ballsHitted == 3)
        {
            //Add a ball;
            ballsHitted = 0;
            if (ballCount < 8 && (ballCount + activeBall) < 8)
            {
                ballCount++;
                AudioManager.instance.Play("PlusBall");
                plusOneBall.SetTrigger("appear");
                ballCountScript.UpdateUI(ballCount);
                
            }
        }
    }
    
    public void DecreasingBalls()
    {
        activeBall++;
	    ballCount--;
		ballCountScript.UpdateUI(ballCount);
    }
    #endregion BallController
}