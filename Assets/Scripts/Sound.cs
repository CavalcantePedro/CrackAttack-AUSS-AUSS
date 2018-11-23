using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound{
	
	public string name;
	public AudioClip audio;
	[Range(0f, 1f)] public float volume;
	public bool PlayOnAwake;
	public bool loop;
	[HideInInspector] public AudioSource source;
}
