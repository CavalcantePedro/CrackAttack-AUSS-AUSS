using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public Animator anim;
	public Animator anim2;
    
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
}
