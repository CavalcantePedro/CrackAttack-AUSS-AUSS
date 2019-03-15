using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	public Sound[] sounds;

	void Awake() {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else{
			Destroy(gameObject);
		}
		SetAudio();
	}

	void SetAudio(){
		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.audio;
			s.source.volume = s.volume;
			s.source.playOnAwake = s.PlayOnAwake;
			s.source.loop = s.loop;
			if(s.PlayOnAwake) s.source.Play();
		}
	}

	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound: " + name + "doesn't exist!");
			return;
		}
		s.source.Play();
       
	}

	public void Pause(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound: " + name + "doesn't exist!");
			return;
		}
		s.source.Pause();
	} 

	public void StopAll(){
		foreach(Sound s in sounds){
			s.source.Stop();
		}
      
	}

	public float GetMusicTime(string name){
		foreach(Sound s in sounds){
			if(s.name == name){
				return s.source.time;
			}
		}
		return 0;
	}
	
}
