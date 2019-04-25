using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float shrinkingSpeed;
    [SerializeField] private float expandingDelay;
    [SerializeField] private float growMaxValue;

    [SerializeField] private bool equalGrow;

    private float xGrow;
    private float yGrow;

    private int axisExpandRate;

    private CircleCollider2D myCollider;

    void Start()
    {
        StartCoroutine(ExpandingShield());
        myCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     DeactivatingCollisions();
     ConstantShrinking(); 
    }

    void ConstantShrinking()
    {
        if(transform.localScale.x > 0.5f)
        {
            transform.localScale = new Vector2(transform.localScale.x - shrinkingSpeed, transform.localScale.y);
        }

        if(transform.localScale.y > 0.5f)
        {
            transform.localScale = new Vector2(transform.localScale.x , transform.localScale.y - shrinkingSpeed);
        }
    }

    void DeactivatingCollisions()
    {
        if(transform.localScale.x <= 0.5 && transform.localScale.y <= 0.5)
        {
            myCollider.enabled = false;
        }

        else
        {
            myCollider.enabled = true;
        }

    }

    void GeneratingExpandValues()
    {
        axisExpandRate = Random.Range(0,100);
        xGrow = Random.Range(1f,growMaxValue);
        if(equalGrow)
        {
            yGrow = xGrow;
        }

        else
        {
            yGrow = Random.Range(1f,growMaxValue);
        }
    }
        

    IEnumerator ExpandingShield()
    {
        for(;;)
        {
            GeneratingExpandValues();
            if(axisExpandRate <= 60 || equalGrow)
                {
                     transform.localScale = new Vector2(xGrow,yGrow);   
                }

            else if (axisExpandRate <= 80 && axisExpandRate > 60)
                {
                    transform.localScale = new Vector2(xGrow,transform.localScale.y);
                }

            else if (axisExpandRate <= 100 && axisExpandRate > 80)
                {
                    transform.localScale = new Vector2(transform.localScale.x,yGrow);
                }
    
        yield return new WaitForSeconds(expandingDelay);
        }
    }
}

