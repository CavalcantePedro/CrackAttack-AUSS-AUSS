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
