using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguageMenu : MonoBehaviour
{
    [SerializeField] private Text phases;
    [SerializeField] private Text enter;
   

    void Start()
    {
        LanguageUpdate();
    }

    void LanguageUpdate()
    {
        switch (PlayerPrefs.GetInt("Language"))
        {
            case 0:
                SetEnglish();
                break;

            case 1:
                SetPortuguese();
                break;
        }
    }

    void SetEnglish()
    {
       enter.text = "ENTER";

        phases.text = "PHASES ";

    }

    void SetPortuguese()
    {
        enter.text = "ENTRAR";

        phases.text = "FASES";
    }
}

