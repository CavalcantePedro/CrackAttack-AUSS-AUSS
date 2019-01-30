using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MoveController {

    public bool isMovingWithSwipe { get; private set; }
    private Collider2D coll;

    public GameManager gm;

    private void Start()
    {
        ballShot.isJoystick = false;
        rb = paddle.rb;
        coll = paddle.coll;
    }

    private void Update()
    {
        if (paddle.ballCount > 0 && ballShot.rotZ > 0 && !isMovingWithSwipe)
        {
            if (Input.GetMouseButton(0))
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

        if (isMovingWithSwipe)
        {
            ballShot.angleArrow.SetActive(false);
            ballShot.changeColor = true;
        }
    }

    void FixedUpdate()
    {
        if (isMovingWithSwipe)
        {
            if(gm.swipeTutorial.activeSelf)
            {
                gm.swipeTutorial.SetActive(false);
            }
            Vector3 realMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(new Vector2(realMousePos.x, rb.position.y));
        }
    }

    public void OnMouseDown()
    {
        Collider2D collOnPoint = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (collOnPoint.Equals(coll))
        {
            isMovingWithSwipe = true;
        }
    }

    void OnMouseUp()
    {
        StartCoroutine(TurnMoveFalse(0.0005f));
    }

    IEnumerator TurnMoveFalse(float time)
    {
        yield return new WaitForSeconds(time);
        isMovingWithSwipe = false;
    }

}
