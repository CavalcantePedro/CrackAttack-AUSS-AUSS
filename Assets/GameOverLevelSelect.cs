using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLevelSelect : MonoBehaviour
{
    
    public void GameInit()
	{
		SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
	}
}