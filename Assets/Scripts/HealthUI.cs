using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour {

    public TimerCount tc;
	public GameObject[] UIHeart;
	
	IEnumerator DestroingHeart(GameObject corazon)
	{

		corazon.GetComponent<SetGlitch>().GlitchNow();
		yield return new WaitForSeconds(0.45f);
		corazon.SetActive(false);
	}

	public void LifeCheck(int playerHealth)
	{
		switch(playerHealth)
		{
			case 2:
				StartCoroutine(DestroingHeart(UIHeart[2]));
			break;

			case 1:
				StartCoroutine(DestroingHeart(UIHeart[1]));
			break;

			default:
				StartCoroutine(DestroingHeart(UIHeart[0]));
                Singleton.GetInstance.playerScript.speed = 0;
                Singleton.GetInstance.transitionToGameOver.PlayerLosed();
                tc.runTime = false;
                break;

		}
	}
}
