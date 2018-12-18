using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public Vector2 playerPos;
    public SwipeController swipe;
    public ArrowsController arrow;
    public JoystickController joystick;
    public GameObject arrowsUI;
    public GameObject shotTutorial;
    public GameObject swipeTutorial;

    //Pixels Related

    //begin
    [HideInInspector]public int totalPixels = 1050;
    [HideInInspector]public int pinkPixels = 500;
    [HideInInspector]public int bluePixels = 382;
    [HideInInspector]public int greenPixels = 168;
    [HideInInspector]public int heartGainPixels;

    //current
    [HideInInspector]public int totalPixelsDestroyed;   
    [HideInInspector]public int pinkPixelsDestroyed;   
    [HideInInspector]public int bluePixelsDestroyed;
    [HideInInspector]public int greenPixelsDestroyed;
    


    
    

    void Start () {

if (PlayerPrefs.GetString("PlayerMovement") == "swipe")
        {
            swipeTutorial.SetActive(true);
            shotTutorial.SetActive(true);
        }

        else if(PlayerPrefs.GetString("PlayerMovement") == "arrows")
        {
            
            shotTutorial.SetActive(true);
        }
         
        totalPixelsDestroyed = 0;
        AudioManager audio = AudioManager.instance;
        if(audio != null){
            audio.StopAll();
            audio.Play("Glitch 3.0");
        }
        player = Singleton.GetInstance.player;
        playerPos = new Vector2(0,-4);

        if (GameObject.FindGameObjectWithTag("Player") == null)
        { 
            Instantiate(player, playerPos, Quaternion.identity);
        }

        InvokeRepeating("UpdateController", 0f, 10f);
    }

	
	void UpdateController () {

        if (PlayerPrefs.GetString("PlayerMovement") == "swipe")
        {
            arrowsUI.SetActive(false);
            arrow.enabled = false;
            joystick.enabled = false;
            swipe.enabled = true;
            
        }
        else if(PlayerPrefs.GetString("PlayerMovement") == "arrows")
        {
            arrowsUI.SetActive(true);
            swipe.enabled = false; 
            joystick.enabled = false;
            arrow.enabled = true;
            
        }
        else
        {
            arrowsUI.SetActive(false);
            arrow.enabled = false;
            swipe.enabled = false; 
            joystick.enabled = true;
        }

    }

}