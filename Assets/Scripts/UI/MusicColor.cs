using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicColor : MonoBehaviour {

	[SerializeField] private BallShot ballShot;
	

	void Start () {
		ballShot.DelaySetColor = 2f;	
	}

	void Update () {
		print(AudioManager.instance.GetMusicTime("Glitch 3.0"));
		
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 8f)
		{
			ballShot.DelaySetColor = 1.75f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 15f)
		{
			ballShot.DelaySetColor = 1.45f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 23f)
		{
			ballShot.DelaySetColor = 1.35f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 37f)
		{
			ballShot.DelaySetColor = 1.15f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 67f)
		{
			ballShot.DelaySetColor = 1.0f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 74f)
		{
			ballShot.DelaySetColor = 0.95f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 81f)
		{
			ballShot.DelaySetColor = 0.93f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 110f)
		{
			ballShot.DelaySetColor = 1.0f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 126f)
		{
			ballShot.DelaySetColor = 0.95f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 131f)
		{
			ballShot.DelaySetColor = 0.93f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 148f)
		{
			ballShot.DelaySetColor = 0.95f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 177f)
		{
			ballShot.DelaySetColor = 0.8f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 198f)
		{
			ballShot.DelaySetColor = 0.01f;
		}

	}	
}
