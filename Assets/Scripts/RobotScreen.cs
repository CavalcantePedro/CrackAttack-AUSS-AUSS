using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotScreen : MonoBehaviour {

	private float percentTotal;
	private float percentPink;
	private float percentGreen;
	private float percentBlue;

	//HUD
	public GameObject totalPercent;
	public Text totalPercentUI;

	public GameObject colorPercent;
	public Text pinkPercentUI;
	public Text bluePercentUI;
	public Text greenPercentUI;

    private void Start() 
	{
	totalPercent.SetActive(true);
	StartCoroutine(PercentPixels());
	StartCoroutine(ChangingScreens());

    }

	public void StopChanging()
	{
		colorPercent.SetActive(false);
		totalPercent.SetActive(false);	
		StopAllCoroutines();
	}

	IEnumerator PercentPixels()
	{   
		for(;;)
		{	

			//Rosa
			percentPink = Mathf.CeilToInt(100 * (Singleton.GetInstance.gm.pinkPixels - Singleton.GetInstance.gm.pinkPixelsDestroyed) / Singleton.GetInstance.gm.totalPixels);
			if(percentPink < 0)
			{
				pinkPercentUI.text = "0%";
			}
			else
			{
			pinkPercentUI.text = percentPink + "%";
			}

			//Verde
			percentGreen = Mathf.CeilToInt(100 * (Singleton.GetInstance.gm.greenPixels - Singleton.GetInstance.gm.greenPixelsDestroyed) / Singleton.GetInstance.gm.totalPixels);
			if(percentGreen < 0)
			{
				greenPercentUI.text = "0%";
			}
			else
			{
			greenPercentUI.text = percentGreen + "%";
			}

			//Azul
			percentBlue = Mathf.CeilToInt(100 * (Singleton.GetInstance.gm.bluePixels - Singleton.GetInstance.gm.bluePixelsDestroyed) / Singleton.GetInstance.gm.totalPixels);
			if(percentBlue < 0)
			{
				bluePercentUI.text = "0%";
			}
			else
			{
			bluePercentUI.text = percentBlue + "%";
			}

			//Total
			percentTotal = Mathf.CeilToInt(100 * (Singleton.GetInstance.gm.totalPixels - Singleton.GetInstance.gm.totalPixelsDestroyed) / Singleton.GetInstance.gm.totalPixels);
			totalPercentUI.text = percentTotal +"%"; 

			yield return new WaitForSeconds (0.5f);
		}
	}



	IEnumerator ChangingScreens()
	{
		for(;;)
		{
			
			yield return new WaitForSeconds(Random.Range(1f,4f));
			totalPercent.SetActive(false);
			colorPercent.SetActive(true);
			yield return new WaitForSeconds(Random.Range(1f,4f));
			colorPercent.SetActive(false);	
			totalPercent.SetActive(true);			
			yield return new WaitForSeconds(Random.Range(1f,4f));				
		}
	}
}
