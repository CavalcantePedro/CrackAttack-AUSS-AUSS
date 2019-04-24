using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PixelDestroyerB : MonoBehaviour {
	
	private ObjectPoolerParticles objParticles;
	private SpriteRenderer sp;
	private int willSpawn;
	private bool hasColor;
	
	void Start()
	 {
		sp = GetComponent<SpriteRenderer>();
		StartCoroutine(ChoosingColors());
		objParticles = Singleton.GetInstance.objectParticles;
		
	 }
//(Collider2D coll)
//(Collision2D coll)
	 private void CountingPixels (Collision2D coll)
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

	 IEnumerator ChoosingColors()
	 {
		 while(!hasColor)
		 {
		//0 = Pink / 1 = Green / 2 = Blue
		willSpawn =  Random.Range(0,3);
		if(willSpawn == 0 && Singleton.GetInstance.gm.canSpawnPinkPixels > 0)
		{
			sp.color = Singleton.GetInstance.ssHeartColors[0];
			Singleton.GetInstance.gm.canSpawnPinkPixels--;
			this.gameObject.tag = "Pink";
			hasColor = true;
		}

		else if(willSpawn == 1 && Singleton.GetInstance.gm.canSpawnGreenPixels > 0)
		{
			sp.color = Singleton.GetInstance.ssHeartColors[1];
			Singleton.GetInstance.gm.canSpawnGreenPixels--;
			this.gameObject.tag = "Green";
			hasColor = true;
		}

		else if(willSpawn == 2 && Singleton.GetInstance.gm.canSpawnPinkPixels > 0)
		{
			sp.color = Singleton.GetInstance.ssHeartColors[2];
			Singleton.GetInstance.gm.canSpawnBluePixels--;
			this.gameObject.tag = "Blue";
			hasColor = true;
		}
		
		yield return new WaitForSeconds(0.5f);
		}

	 }

     //OnTriggerEnter2D(Collider2D coll)
	 //OnCollisionEnter2D(Collision2D coll)
	private void OnCollisionEnter2D(Collision2D coll)
	{
		
		if(coll.gameObject.tag == this.gameObject.tag)
		{
            CountingPixels(coll);

            if (Singleton.GetInstance.gm.totalPixelsDestroyed == Singleton.GetInstance.gm.totalPixels)
           {
			   int score = Mathf.CeilToInt((Singleton.GetInstance.time.minutes * 60f + Singleton.GetInstance.time.seconds)* 100);
			   

			if(score > PlayerPrefs.GetInt("Record1") || !PlayerPrefs.HasKey("Record1"))
			{
			   PlayerPrefs.SetInt("Record" , score);
			   PlayerPrefs.Save();
			}
                SceneManager.LoadScene(5);
        	}

			else if(Singleton.GetInstance.gm.heartGainPixels >= Singleton.GetInstance.gm.totalPixels * 0.35)
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