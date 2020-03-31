using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {

    private float delay;
    [SerializeField] private SceneController sc;

    public void ChangeScene(string name){
        SceneManager.LoadScene(name);
    }

    private void Start() {


        /*  if (SceneManager.GetActiveScene().buildIndex == 4)
         {          
             delay = 30f;
             Invoke("CreditsToMenu", delay);
         }*/

        if (SceneManager.GetActiveScene().name == "FirstTimeSettings")
        {
            if (!PlayerPrefs.HasKey("FirstTimeSettings"))
            {
                PlayerPrefs.SetInt("FirstTimeSettings", 1);
            }

            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        else if (SceneManager.GetActiveScene().name == "Cutscene")
        {
            delay = 25f;
            Invoke("Cutscene", delay);
        }
        else if (SceneManager.GetActiveScene().name == "CutsceneProvisoria")
        {
            delay = 10f;
            Invoke("Cutscene", delay);
        }
        else
        {
            delay = 30f;
            Invoke("CreditsToMenu", delay);
        }
    }

    void Cutscene()
    {
        sc.TransitionToGameOne();
    }
            
   void CreditsToMenu(){
        sc.TransitionToMenu();
    }

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

    IEnumerator ChangingTheScene(int index, float delay)
    {
        
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }
   

     IEnumerator ExitingGame()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
