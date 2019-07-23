using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Awake() 
    {
        if(PlayerPrefs.GetString("Dancing") == "Off"){ 
            
            Singleton.GetInstance.robot.GetComponent<Animator>().enabled = false;
            Singleton.GetInstance.dich.GetComponent<Animator>().enabled = false;
            Singleton.GetInstance.mono.GetComponent<Animator>().enabled = false;
            Singleton.GetInstance.trich.GetComponent<Animator>().enabled = false; 
            Singleton.GetInstance.corazon.GetComponent<Animator>().enabled = false;
        }
        
        if(PlayerPrefs.GetString("Shield") == "Off"){
            Singleton.GetInstance.shield.SetActive(false);
        }

        if(PlayerPrefs.GetString("Dancing") == "On"){

            Singleton.GetInstance.robot.GetComponent<Animator>().enabled = true;
            Singleton.GetInstance.dich.GetComponent<Animator>().enabled = true;
            Singleton.GetInstance.mono.GetComponent<Animator>().enabled = true;
            Singleton.GetInstance.trich.GetComponent<Animator>().enabled = true;
            Singleton.GetInstance.corazon.GetComponent<Animator>().enabled = true;
        }
        if(PlayerPrefs.GetString("Shield") == "On"){
            Singleton.GetInstance.shield.SetActive(true);
        }
    }     
}
