using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguegeCutscene : MonoBehaviour
{
    [SerializeField] private Text instructions;
    [SerializeField] private Text skip;

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
        instructions.text = "CRACK ATTACK is a new game from AUSS & AUSS." +

       "\n\nPLAYER'S MISSION:" +
         "\nDestroy the colorful pixels from SS Robot until the end of the song." +

        "\n\nHOW TO PLAY:" +
         "Use the bar control arrow and shoot colored balls towards the robot's heart. Each ball has a color and destroys only the pixels of the same color in the robot's heart." +
        "\nMove the bar sideways and prevent the balls from falling or you will lose lives.";

        skip.text = "SKIP ";
    }

    void SetPortuguese()
    {
        instructions.text = "CRACK ATTACK é o novo game da AUSS & AUSS." +

       "\n\nMISSÃO DO JOGADOR:" +
         "\nDestrua o coração de pixels coloridos do Robô SS antes que a música termine." +

        "\n\nCOMO JOGAR:" +
         "Use a seta de controle da barra e dispare bolas coloridas em direção ao coração do robô.Cada bola tem uma cor e destrói apenas os pixels da respectiva cor no coração do robô." +
        "\nMovimente a barra para os lados e evite que as bolas caiam e você perca vidas.";

        skip.text = "PULAR";
    }
}

