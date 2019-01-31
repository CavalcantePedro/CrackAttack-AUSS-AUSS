using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{   

    public static int language;
    
    /*
        Language Index:
        0 - English
        1 - Portuguese
     */

    void Awake()
    {
        if(PlayerPrefs.HasKey("Language")){
            PlayerPrefs.SetInt("Language", 0);
        }
    }
}
