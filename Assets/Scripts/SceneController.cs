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

    IEnumerator SettingsScene(){       

        anim.SetBool("glitching",true);
		anim2.SetBool("glitching",true);
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("Transition");
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("Settings");
    }

    IEnumerator MenuScene(){
        anim.SetBool("glitching",true);
		anim2.SetBool("glitching",true);
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("Transition");
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("MainMenu");
    }
}
