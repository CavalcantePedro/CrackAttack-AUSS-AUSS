using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PixelDestroyer : MonoBehaviour {
	private ObjectPoolerParticles objParticles;
	
	void Start()
	 {

		objParticles = Singleton.GetInstance.objectParticles;
		
	 }

	 private void CountingPixels(Collision2D coll)
	 {
		 Singleton.GetInstance.gm.totalPixelsDestroyed++;
		 Singleton.GetInstance.gm.heartGainPixels++;

		 switch(coll.gameObject.tag)
		 {
			 case "Pink":

             Singleton.GetInstance.gm.pinkPixelsDestroyed++;

			 break;

			 case "Green":

             Singleton.GetInstance.gm.greenPixelsDestroyed++;

			 break;

			 case "Blue":

			 Singleton.GetInstance.gm.bluePixelsDestroyed++;

			 break;
		 }


	 }
	private void OnCollisionEnter2D(Collision2D coll) 
	{
		
		if(coll.gameObject.tag == this.gameObject.tag)
		{
            CountingPixels(coll);

            if (Singleton.GetInstance.gm.totalPixelsDestroyed >= Singleton.GetInstance.gm.totalPixels * 0.7)
           {
                SceneManager.LoadScene(4);
        	}

			else if(Singleton.GetInstance.gm.heartGainPixels >= Singleton.GetInstance.gm.totalPixels * 0.15)
			{
				Singleton.GetInstance.gm.heartGainPixels = 0; 
				Instantiate(Singleton.GetInstance.collectableHeart ,transform.position,Quaternion.identity);
			}
           
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