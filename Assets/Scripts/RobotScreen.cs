using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotScreen : MonoBehaviour {

	private int percentTotal;
	private int percentPink;
	private int percentGreen;
	private int percentBlue;

	//HUD
	public GameObject totalPercent;
	public Text totalPercentUI;

	public GameObject colorPercent;
	public Text pinkPercentUI;
	public Text bluePercentUI;
	public Text greenPercentUI;

	public GameObject aussAndAuss;


    private void Start() 
	{

	StartCoroutine(PercentPixels());
	StartCoroutine(ChangingScreens());

    }
	IEnumerator PercentPixels()
	{   
		for(;;)
		{
        percentPink = 100 * (Singleton.GetInstance.gm.pinkPixels - Singleton.GetInstance.gm.pinkPixelsDestroyed) / Singleton.GetInstance.gm.totalPixels;
		pinkPercentUI.text = percentPink + "%";

		percentGreen = 100 * (Singleton.GetInstance.gm.greenPixels - Singleton.GetInstance.gm.greenPixelsDestroyed) / Singleton.GetInstance.gm.totalPixels;
		greenPercentUI.text = percentGreen+ "%";

		percentBlue = 100 * (Singleton.GetInstance.gm.bluePixels - Singleton.GetInstance.gm.bluePixelsDestroyed) / Singleton.GetInstance.gm.totalPixels;
		bluePercentUI.text = percentBlue + "%";

		percentTotal = 100 * (Singleton.GetInstance.gm.totalPixels - Singleton.GetInstance.gm.totalPixelsDestroyed) / Singleton.GetInstance.gm.totalPixels;
		totalPercentUI.text = percentTotal +"%"; 

		yield return new WaitForSeconds (0.5f);
		}
	}



	IEnumerator ChangingScreens()
	{
		for(;;)
		{
			aussAndAuss.SetActive(false);
			totalPercent.SetActive(true);
			yield return new WaitForSeconds(Random.Range(1f,4f));
			totalPercent.SetActive(false);
			colorPercent.SetActive(true);
			yield return new WaitForSeconds(Random.Range(1f,4f));
			colorPercent.SetActive(false);
			aussAndAuss.SetActive(true);		
			yield return new WaitForSeconds(Random.Range(1f,4f));				
		}
	}
}
