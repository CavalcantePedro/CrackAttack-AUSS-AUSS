using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorBlindSettings : MonoBehaviour
{
    public void SetColorBlind(int colorSet){
        PlayerPrefs.SetInt("ColorBlind", colorSet);
    }
}
