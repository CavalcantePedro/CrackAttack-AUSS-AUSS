using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSettings : MonoBehaviour {

	[SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject startButton;


    private void Start() 
    {
        if (!PlayerPrefs.HasKey("PlayerMovement")){
            PlayerPrefs.SetString("PlayerMovement", "arrows");
        } 
    }
	public void OpenMenu()
	{
        StartCoroutine(OpeningMenu());
	}
		
	public void CloseMenu()
	{
        StartCoroutine(ClosingMenu());
	}


    IEnumerator OpeningMenu()
    {
        yield return new WaitForSeconds(0.5f);
        settingsMenu.SetActive(true);
        startButton.SetActive(false);
    }

    IEnumerator ClosingMenu()
    {
        yield return new WaitForSeconds(0.5f);
        settingsMenu.SetActive(false);
        startButton.SetActive(true);
    }
}
