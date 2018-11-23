using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {

    private float delay;
    public void SetDelay(float inputDelay)
    {
       delay = inputDelay;
    }

	public void ChangeSceneWithDelay(int index)
    {
       StartCoroutine(ChangingTheScene(index , delay));
	}

    public void ExitGame()
    {
       StartCoroutine(ExitingGame());
	}

	public void StartMenu(){
		
	}

    IEnumerator ChangingTheScene(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }

     IEnumerator ExitingGame()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
