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
    [HideInInspector]public int pinkPixels;
    [HideInInspector]public int bluePixels;
    [HideInInspector]public int greenPixels;
    [HideInInspector]public int heartGainPixels;

    //spawning
    [HideInInspector]public int canSpawnPinkPixels;
    [HideInInspector]public int canSpawnBluePixels;
    [HideInInspector]public int canSpawnGreenPixels;

    private int pinkRate;
    private int blueRate;
    private int greenRate;

    //current
    [HideInInspector]public int totalPixelsDestroyed;   
    [HideInInspector]public int pinkPixelsDestroyed;   
    [HideInInspector]public int bluePixelsDestroyed;
    [HideInInspector]public int greenPixelsDestroyed;
    
    void Start () {

        GeneratingColorRate();
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

    void GeneratingColorRate()
    {
        pinkRate = Random.Range(20,46);
        blueRate = Random.Range(20,46);
        greenRate = 100 - pinkRate - blueRate;

        canSpawnPinkPixels  = pinkRate * totalPixels / 100;
        canSpawnBluePixels  = blueRate * totalPixels / 100;
        canSpawnGreenPixels = greenRate * totalPixels/ 100 + 1;

        pinkPixels = canSpawnPinkPixels;
        bluePixels = canSpawnBluePixels;
        greenPixels = canSpawnGreenPixels;

        print("pink " + canSpawnPinkPixels);
         print("blue " + canSpawnBluePixels);
          print("green " + canSpawnGreenPixels);
    }

}