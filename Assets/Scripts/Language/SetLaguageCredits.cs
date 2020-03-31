using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLaguageCredits : MonoBehaviour
{

    [SerializeField] private Text credits;

    [SerializeField] private Text privacyPolicy;



    void Start()
    {
        LanguageUpdate();        
    }

    void LanguageUpdate()
    {
        switch(PlayerPrefs.GetInt("Language")){
            case 0:
                SetEnglish();    
            break;

            case 1:
                SetPortuguese();
            break;
        }
    }

    void SetEnglish(){
        credits.text = "Crack Attack is a game belonging to the Auss & Auss Transmedia narrative, which was developed by students of Escola Técnica - Cícero Dias, of the Nave Project in Recife, Pernambuco."+

                        "\n\nArt Team:"+

                        "\nAntonio Luan Vasconcelos"+
                        "\nWillian Carlos B. de Oliveira"+
                        "\nMaria Eduarda Alexandre"+
                        "\nDarlane Raquel Do N. Marinho"+
                        "\nJoão Guilherme"+

                        "\n\nSound Design:"+

                        "\nGabriel Marques"+

                        "\n\nProgramming Team:"+

                        "\nPedro Ricardo Cavalcante Silva Filho"+
                        "\nRabih Tabatchnik"+
                        "\nMateus Francisco S. Lima"+

                        "\n\nSpecial Thanks:"+

                        "\nDANIEL DE SANT'ANNA"+
                        "\nErika Pessoa"+
                        "\nAndré Oliveira"+
                        "\nLuiz Eduardo Brayner"+
                        "\n\nYoutuber: Geri";

        privacyPolicy.text = "Privacy Policy:" +
                             "\n\nhttps://cavalcantepedro.github.io/CrackAttack-AUSS-AUSS/";
    }

    void SetPortuguese(){
        credits.text = "Crack Attack é um jogo pertencente à narrativa transmídia da Auss & Auss, que foi desenvolvido por alunos da Escola Técnica Estadual - Cícero Dias, do Projeto Nave em Recife, Pernambuco."+

                        "\n\nEquipe de Arte:"+

                        "\nAntonio Luan Vasconcelos"+
                        "\nWillian Carlos B. de Oliveira"+
                        "\nMaria Eduarda Alexandre"+
                        "\nDarlane Raquel Do N. Marinho"+
                        "\nJoão Guilherme"+

                        "\n\nSound Design:"+

                        "\nGabriel Marques"+

                        "\n\nEquipe de Programação:"+

                        "\nPedro Ricardo Cavalcante Silva Filho"+
                        "\nRabih Tabatchnik"+
                        "\nMateus Francisco S. Lima"+

                        "\n\nAgradecimentos Especiais:"+

                        "\nDANIEL DE SANT'ANNA"+
                        "\nErika Pessoa"+
                        "\nAndré Oliveira"+
                        "\nLuiz Eduardo Brayner"+
                        "\n\nYoutuber : Geri";

        privacyPolicy.text = "Politica de Privacidade:" +
                             "\n\nhttps://cavalcantepedro.github.io/CrackAttack-AUSS-AUSS/";
    }
}
