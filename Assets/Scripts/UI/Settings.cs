using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {
	
	[SerializeField] private Animator arrowsAnim;
	[SerializeField] private Animator swipeAnim;
	[SerializeField] private Animator joyAnim;

	[Header("Flags Animation")] 
	[SerializeField] private Animator ptFlag;
	[SerializeField] private Animator enFlag;

	void OnEnable()
	{
		if(PlayerPrefs.GetString("PlayerMovement") == "arrows"){
			swipeAnim.SetBool("glitching" , false);
			joyAnim.SetBool("glitching", false);
			arrowsAnim.SetBool("glitching" , true);
		}  
		else if(PlayerPrefs.GetString("PlayerMovement") == "swipe"){
			arrowsAnim.SetBool("glitching" , false);
			joyAnim.SetBool("glitching", false);
			swipeAnim.SetBool("glitching" , true);
		}
		else if(PlayerPrefs.GetString("PlayerMovement") == "joystick")
		{
			arrowsAnim.SetBool("glitching" , false);
			swipeAnim.SetBool("glitching" , false);
			joyAnim.SetBool("glitching", true);
		}

		UpdateFlags();
	}

	public void UpdateFlags(){
		
		
		//Put this animation On later...!!!!!!

		switch(PlayerPrefs.GetInt("Language"))
        {
            case 0: // ligou o ingles
				enFlag.SetBool("glitching",true);
                ptFlag.SetBool("glitching",false);
            break;

            case 1: // ligou o pt
                ptFlag.SetBool("glitching",true);
                enFlag.SetBool("glitching",false);
            break;
        }
		
	}

	public void ChoosingArrows()
	{
		PlayerPrefs.SetString("PlayerMovement" , "arrows");
		//animações
		swipeAnim.SetBool("glitching" , false);
		joyAnim.SetBool("glitching", false);
		arrowsAnim.SetBool("glitching" , true);
		PlayerPrefs.Save();
	}

	public void ChoosingSwipe()
	{
		PlayerPrefs.SetString("PlayerMovement" , "swipe");
		//animações
		arrowsAnim.SetBool("glitching" , false);
		joyAnim.SetBool("glitching", false);
		swipeAnim.SetBool("glitching" , true);
		PlayerPrefs.Save();
	}

	public void ChoosingJoystick(){
		PlayerPrefs.SetString("PlayerMovement", "joystick");
		arrowsAnim.SetBool("glitching" , false);
		swipeAnim.SetBool("glitching" , false);
		joyAnim.SetBool("glitching", true);
		PlayerPrefs.Save();
	}

}
