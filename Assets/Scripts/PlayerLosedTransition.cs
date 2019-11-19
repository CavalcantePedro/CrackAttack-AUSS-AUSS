using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLosedTransition : MonoBehaviour {
	
    [SerializeField] private ParticleSystem zeroParticle;
    [SerializeField] private ParticleSystem oneParticle;
    [SerializeField] private Animator animGlitchUp;
    [SerializeField] private Animator animGlitchDown;

    
    // Update is called once per frame
    public void PlayerLosed ()
    {
        StartCoroutine(StopingEverything());
        
    }

    IEnumerator StopingEverything()
    { 
        oneParticle.Pause();
        zeroParticle.Pause();
        Singleton.GetInstance.robot.GetComponent<Animator>().enabled = false;
        Singleton.GetInstance.dich.GetComponent<Animator>().enabled = false;
        Singleton.GetInstance.mono.GetComponent<Animator>().enabled = false;
        Singleton.GetInstance.trich.GetComponent<Animator>().enabled = false; 
        Singleton.GetInstance.corazon.GetComponent<Animator>().enabled = false;
        ObjectPooler.instance.StopAllBalls();
        GameObject.Find("NICE FX CAMERA").GetComponent<AudioListener>().enabled = false;
        AudioManager.instance.StopAll();
        yield return new WaitForSeconds(2f);
        animGlitchUp.SetBool("glitching",true);
        animGlitchDown.SetBool("glitching",true);
        GameObject.Find("NICE FX CAMERA").GetComponent<AudioListener>().enabled = true;
        AudioManager.instance.Play("Transition");
        
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneBuildIndex: 2);
        

    }
}
   
