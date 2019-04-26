using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLevelSelect : MonoBehaviour
{
    
    
    public void GameInit()
	{
		if (PlayerPrefs.GetString("Dificuldade") == "Hard")
		{
            SceneManager.LoadScene(sceneBuildIndex: 2);
          
		}
		else 
		{
             SceneManager.LoadScene(sceneBuildIndex: 6);   
		}

		
	}
}