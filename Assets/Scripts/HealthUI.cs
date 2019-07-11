using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour {

    public TimerCount tc;
	public GameObject[] UIHeart;

	private bool heart3;
	private bool heart2;
	private bool heart1;

	 private void Start() 
	 {
		heart3 = true;
		heart2 = true;
		heart1 = true;
 	 }

	IEnumerator DestroingHeart(GameObject corazon)
	{	
	
		corazon.GetComponent<SetGlitch>().GlitchNow();
		yield return new WaitForSeconds(0.45f);
		corazon.SetActive(false);
		
	}

	IEnumerator CreatingHeart(GameObject corazon)
	{
		corazon.GetComponent<SetGlitch>().GlitchNow();
		yield return new WaitForSeconds(0.45f);
		corazon.SetActive(true);
	}


	public void LifeCheck(int playerHealth)
	{
		switch(playerHealth)
		{
			case 3:
			

			if(!heart3)
			{
			heart3 = true;
			StartCoroutine(CreatingHeart(UIHeart[3]));
			}
			break;

			case 2:
		
			//se estiver ativo
				if(heart3)
				{
				
					heart3 = false;
					StartCoroutine(DestroingHeart(UIHeart[3]));
				}
			//se nao estiver
				else if(!heart2)
				{
					print("a");
					heart2 = true;
					StartCoroutine(CreatingHeart(UIHeart[2]));
				}

			break;

			case 1:
			
			//se estiver ativo
				if(heart2)
				{
					print("b");
					heart2 = false;
					StartCoroutine(DestroingHeart(UIHeart[2]));
				}
			//se nao estiver	
				else if(!heart1)
				{
					
					heart1 = true;
					StartCoroutine(CreatingHeart(UIHeart[1]));
				}

			break;

			case 0:
				StartCoroutine(DestroingHeart(UIHeart[1]));
                Singleton.GetInstance.playerScript.speed = 0;
                Singleton.GetInstance.transitionToGameOver.PlayerLosed();
                tc.runTime = false;
                break;

		}
	}
}
