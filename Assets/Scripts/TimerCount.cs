using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCount : MonoBehaviour {

    public BallShot ballShot;
    public float velocitySwap;
    public bool runTime;
    float seconds, totalSeconds, variance;
    int minutes;
    int secondsUI;
    [SerializeField] Text timeUI;

    void Start()
    {
        runTime = true;
        minutes = 3;
        seconds = 26f;       
        secondsUI = 0;
        totalSeconds = minutes * 60f + seconds;
        variance = ballShot.Variance();
        StartCoroutine(VelocitySwap());
    }

    void Update()
    {
        if (!runTime) return;

        seconds -= Time.deltaTime;
        if (seconds <= 0)
        {
            if(minutes > 0){
                minutes -= 1;
                seconds = 60f;
            }
            else{
                Singleton.GetInstance.transitionToGameOver.PlayerLosed();
            }
        }

       
        secondsUI = (int) seconds;
        if (seconds >= 10)
        {
            timeUI.text = minutes.ToString() + ":" + secondsUI.ToString();
        }
        else
        {
            timeUI.text = minutes.ToString() + ":0" + secondsUI.ToString();
        }
    }

    private float AllSeconds()
    {
        float final = minutes * 60f;
        final += seconds;
        return final;
    }


    IEnumerator VelocitySwap()
    {
        while(true)
        {
            yield return new WaitForSeconds(velocitySwap);
            ballShot.ColorChangeSpeed(velocitySwap * (variance/totalSeconds));
        }
    }
}

