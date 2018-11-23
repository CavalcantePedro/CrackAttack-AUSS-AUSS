using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	public ParticleSystem explosion1;
	public ParticleSystem explosion2;
	ParticleSystem[] explosionParticle = new ParticleSystem[2];

	static Explode self;
	public static Explode Self{
		get{
				return self;
		}
	}
	private void Awake() {
		if (self == null)
				self = this;
	}
	private void Start() {
		explosionParticle[0] = explosion1;
		explosionParticle[1] = explosion2;
	}
	public ParticleSystem[] GetExplosion(){
		explosionParticle[0].time = 0;
		explosionParticle[0].Pause();
		explosionParticle[1].time = 0;
		explosionParticle[1].Pause();
		return explosionParticle;
	}
}
