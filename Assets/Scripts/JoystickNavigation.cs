using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickNavigation : MonoBehaviour {
	[SerializeField] private string confirm, back;
	[SerializeField] private Button bStart, bRestart, bMenu; 
	[SerializeField] private bool startGame;

	void Start() 
	{
        PlayerPrefs.SetString("PlayerMovement", "joystick");
	}
	void Update () {
		if(Input.GetButtonDown("Confirm"))
		{
			if(startGame)
			{	
				bStart.onClick.Invoke();
				print("St game");
			}
			else
			{
				bRestart.onClick.Invoke();
			}

		}
		else if(Input.GetButtonDown(back))
		{
			if(bMenu != null)
				bMenu.onClick.Invoke();
		}		
	}
}
