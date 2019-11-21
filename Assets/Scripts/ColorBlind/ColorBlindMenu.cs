using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlindMenu : MonoBehaviour
{

    [SerializeField] private GameObject[] tittle;

    void Awake() {

        if(!PlayerPrefs.HasKey("ColorBlind")){
            PlayerPrefs.SetInt("ColorBlind", 0);
        }    
    }

    void Start()
    {
        for (int i = 0; i < tittle.Length; i++)
        {
            if(i != PlayerPrefs.GetInt("ColorBlind")){
                tittle[i].SetActive(false);
            }   
        }
    }


}
