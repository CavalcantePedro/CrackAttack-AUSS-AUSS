using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator anim;
	public Animator anim2;

    private GameObject activeGlitch;

    void Start()
    {
       CheckGlitchColor();
    }

    public void CheckGlitchColor()
    {
        switch(PlayerPrefs.GetInt("ColorBlind"))
        {
            case 0:
            anim = GameObject.Find("Canvas/Glitch/Original_Color/OriginalGlitchUp").GetComponent<Animator>();
            anim2 = GameObject.Find("Canvas/Glitch/Original_Color/OriginalGlitchDown").GetComponent<Animator>();
            activeGlitch = GameObject.Find("Canvas/Glitch/Original_Color");
            activeGlitch.SetActive(true);
            break;
            
            case 1:
            anim = GameObject.Find("Canvas/Glitch/Monochromatic/MonGlitchUp").GetComponent<Animator>();
            anim2 = GameObject.Find("Canvas/Glitch/Monochromatic/MonGlitchDown").GetComponent<Animator>();
            activeGlitch = GameObject.Find("Canvas/Glitch/Monochromatic");
            activeGlitch.SetActive(true);
            break;
            
            case 2:
            anim = GameObject.Find("Canvas/Glitch/Dichromatic/DicGlitchUp").GetComponent<Animator>();
            anim2 = GameObject.Find("Canvas/Glitch/Dichromatic/DicGlitchDown").GetComponent<Animator>();
            activeGlitch = GameObject.Find("Canvas/Glitch/Dichromatic");
            activeGlitch.SetActive(true);
            break;

            case 3:
            anim = GameObject.Find("Canvas/Glitch/Trichromatic/TricGlitchUp").GetComponent<Animator>();
            anim2 = GameObject.Find("Canvas/Glitch/Trichromatic/TricGlitchDown").GetComponent<Animator>();
            activeGlitch = GameObject.Find("Canvas/Glitch/Trichromatic");
            activeGlitch.SetActive(true);
            break;
        }
    }

    public void ChangeScene(string name){
        SceneManager.LoadScene(name);
    }

    public void TransitionToSettings(){
        StartCoroutine(SettingsScene());
    }

    public void TransitionToMenu(){
        StartCoroutine(MenuScene());
    }

    public void TransitionToCredits(){
        StartCoroutine(CreditsScene());
    }

    public void TransitionToGameOne()
    {
        StartCoroutine(GameOneScene());
    }
    public void TransitionPlayerWon()
    {
        StartCoroutine(PlayerWonTransition());
    }

    IEnumerator GameOneScene(){       
        
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("glitching",true);
		anim2.SetBool("glitching",true);
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("Transition");
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("GameA1");
    }

    

    IEnumerator SettingsScene(){       
        
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("glitching",true);
		anim2.SetBool("glitching",true);
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("Transition");
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("Settings");
    }

    IEnumerator MenuScene(){

        yield return new WaitForSeconds(0.5f);
        anim.SetBool("glitching",true);
		anim2.SetBool("glitching",true);
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("Transition");
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.StopAll();
    }

    IEnumerator CreditsScene(){
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("glitching",true);
		anim2.SetBool("glitching",true);
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("Transition");
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("Credits");
    }
    IEnumerator PlayerWonTransition()
	{
		Singleton.GetInstance.robotAnim.Death();
        ObjectPooler.instance.StopAllBalls();
        GameObject.Find("NICE FX CAMERA").GetComponent<AudioListener>().enabled = false;
        AudioManager.instance.StopAll();
		print("LINHA 200");
        yield return new WaitForSeconds(2f);
		print("LINHA 201");
        Singleton.GetInstance.sceneController.anim.SetBool("glitching",true);
        Singleton.GetInstance.sceneController.anim2.SetBool("glitching",true);
        GameObject.Find("NICE FX CAMERA").GetComponent<AudioListener>().enabled = true;
        AudioManager.instance.Play("Transition");
        print("LINHA 207");
        yield return new WaitForSeconds(1.5f);
		print("LINHA 208");
        SetLevel();
	}
    public void SetLevel(){
		if(PlayerPrefs.GetInt("Level") == 0 || !PlayerPrefs.HasKey("Level")){
			PlayerPrefs.SetInt("Level", 1);
			PlayerPrefs.SetInt("LevelsWon", 1);
			
		}
		else if(PlayerPrefs.GetInt("Level") == 1){
			PlayerPrefs.SetInt("Level", 2);
			PlayerPrefs.SetInt("LevelsWon", 2);
			SceneManager.LoadScene("GameA2");
		}
		else if(PlayerPrefs.GetInt("Level") == 2){
			PlayerPrefs.SetInt("Level", 3);
			PlayerPrefs.SetInt("LevelsWon", 3);
			SceneManager.LoadScene("GameA3");
		}
		else if(PlayerPrefs.GetInt("Level") == 3){
			PlayerPrefs.SetInt("Level", 4);
			PlayerPrefs.SetInt("LevelsWon", 4);
			SceneManager.LoadScene("GameA4");
		}
		else{
			SceneManager.LoadScene("Victory");
		}

		PlayerPrefs.Save();
	}

}
