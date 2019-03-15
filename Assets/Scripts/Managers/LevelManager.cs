using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private bool dance;
    [SerializeField] private GameObject shield;

    void Awake() {

        if(PlayerPrefs.HasKey("LevelSelect")) PlayerPrefs.SetInt("LevelSelect", 0);

        switch(PlayerPrefs.GetInt("LevelSelect")){
            case 0:
                shield.SetActive(false);
                dance = false;
                break;
            case 1:
                shield.SetActive(true);
                dance = false;
                break;
            case 2:
                shield.SetActive(false);
                dance = true;
                break;
            case 3:
                shield.SetActive(true);
                dance = true;
                break;
        }
    }
    
    void Update()
    {
        
    }
}
