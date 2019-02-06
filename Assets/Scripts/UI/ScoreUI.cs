using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
    
    [SerializeField] private Text scoreText;

    private string scoreSt;
    void Start()
    {
        if(PlayerPrefs.HasKey("Score"))
        {
        scoreSt = PlayerPrefs.GetInt("Score").ToString();
        scoreText.text ="Score:" + scoreSt;
        }
        else
        {
            scoreText.text = "Score:0";
        }
    }
}
