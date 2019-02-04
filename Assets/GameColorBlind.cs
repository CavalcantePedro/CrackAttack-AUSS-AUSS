using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameColorBlind : MonoBehaviour
{

    [SerializeField] private GameObject[] robots;

    [SerializeField] private Text pinkTxt;
    [SerializeField] private Text greenTxt;
    [SerializeField] private Text blueTxt;

    [SerializeField] private Color[] originalColor;
    [SerializeField] private Color[] dic;
    [SerializeField] private Color[] mon;
    [SerializeField] private Color[] tri;

    void Start()
    {
        for (int i = 0; i < robots.Length; i++)
        {
            if(i != PlayerPrefs.GetInt("ColorBlind")){
                robots[i].SetActive(false);
            }   
        }

        ChangeColor();
    }

    void ChangeColor(){


        PlayerPrefs.SetInt("ColorBlind", 3);
        switch(PlayerPrefs.GetInt("ColorBlind")){
            case 0:
                pinkTxt.color = originalColor[0];
                blueTxt.color = originalColor[1];
                greenTxt.color = originalColor[2];
            break;

            case 1:
                pinkTxt.color = dic[0];
                blueTxt.color = dic[1];
                greenTxt.color = dic[2];
            break;

            case 2:
                pinkTxt.color = mon[0];
                blueTxt.color = mon[1];
                greenTxt.color = mon[2];
            break;

            case 3:
                pinkTxt.color = tri[0];
                greenTxt.color = tri[1];
                blueTxt.color = tri[2];
            break;
        }
    }
}
