using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MoveController {

    public bool isClicking { get; private set; }
    [SerializeField] private Animator animLeftArrow, animRightArrow;

     public GameManager gm;

    void Awake() {
        ballShot.isJoystick = false;
    }
    void Start()
    {
        ballShot.isJoystick = false;
        rb = paddle.rb;
        speed = paddle.speed;
    }

    void OnEnable() {
        ballShot.isJoystick = false;
    }

    private void Update()
    {
       
        if (paddle.ballCount > 0 && ballShot.rotZ > 0)
        {
            if (Input.GetMouseButton(0) && !isClicking)
            {
                ballShot.angleArrow.SetActive(true);
                ballShot.changeColor = false;
                if(gm.shotTutorial.activeSelf)
                {
                gm.shotTutorial.SetActive(false);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                ballShot.angleArrow.SetActive(false);
                ballShot.Shot(paddle);
                ballShot.changeColor = true;
            }
        }
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        animRightArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = true;
        Singleton.GetInstance.ballShot.angleArrow.SetActive(false);
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        animLeftArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = true;
        Singleton.GetInstance.ballShot.angleArrow.SetActive(false);
    }

    public void StopMoveRight()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animRightArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = false;
    }

    public void StopMoveLeft()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animLeftArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = false;
    }

}
