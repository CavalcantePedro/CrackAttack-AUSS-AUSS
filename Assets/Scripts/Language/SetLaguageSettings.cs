using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLaguageSettings : MonoBehaviour
{

    [SerializeField] private Text controls;
    [SerializeField] private Text language;
    [SerializeField] private Text colorBlind;

    void Start() {
        LanguageUpdate();    
    }

    void LanguageUpdate()
    {
        switch(PlayerPrefs.GetInt("Language"))
        {
            case 0:
                SetEnglish();
            break;

            case 1:
                SetPortuguese();
            break;
        }
    }

    void SetEnglish(){
        //Titles;
        controls.text = "Controls";
        language.text = "Language";
        colorBlind.text = "Color Blindness";
    }

    void SetPortuguese(){
        //Titles;
        controls.text = "Controles";
        language.text = "Idioma";
        colorBlind.text = "Daltonismo";
    }

    public void LanguageBtn(int index){
        PlayerPrefs.SetInt("Language", index);
        LanguageUpdate();
        PlayerPrefs.Save();
    }
}
