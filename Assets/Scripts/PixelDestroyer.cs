using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PixelDestroyer : MonoBehaviour {

	private ObjectPoolerParticles objParticles;

	void Start() {
		objParticles = Singleton.GetInstance.objectParticles;
	}

	private void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.tag == this.gameObject.tag || this.gameObject.tag == "Untagged" )
		{
            Singleton.GetInstance.gm.pixelsDestroyed++;
            if (Singleton.GetInstance.gm.pixelsDestroyed++ >= 630)
           {
                SceneManager.LoadScene(4);
        }
           // AudioManager.instance.Play("Crack");
			// var obj = objParticles.GetPooledObject();
			// obj.transform.position = transform.position;
			
			// obj.SetActive(true);
			// obj.GetComponentsInChildren<ParticleSystem>()[0].Stop();
			// obj.GetComponentsInChildren<ParticleSystem>()[0].Play();
			// obj.GetComponentsInChildren<ParticleSystem>()[1].Stop();
			// obj.GetComponentsInChildren<ParticleSystem>()[1].Play();
			AudioManager.instance.Play("Crack");
			ParticleSystem[] ex = Explode.Self.GetExplosion();
			ex[0].transform.position = transform.position;
			ex[1].transform.position = transform.position;
			
			ex[0].Play();
			ex[1].Play();
			gameObject.SetActive(false);
		}  
	}
}