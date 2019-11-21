using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PixelDestroyerA : MonoBehaviour {
	
	private ObjectPoolerParticles objParticles;
	private SpriteRenderer sp;
	private int willSpawn;
	private bool hasColor;
	private int score;
	
	void Start(){

		//print("Number info (2):" + PlayerPrefs.GetInt("Level"));
        
		sp = GetComponent<SpriteRenderer>();
		StartCoroutine(ChoosingColors());
		objParticles = Singleton.GetInstance.objectParticles;
		
	}

	private void CountingPixels (Collider2D coll){

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
		while(!hasColor){

			//0 = Pink / 1 = Green / 2 = Blue
			willSpawn =  Random.Range(0,3);
			if(willSpawn == 0 && Singleton.GetInstance.gm.canSpawnPinkPixels > 0){
				sp.color = Singleton.GetInstance.ssHeartColors[0];
				Singleton.GetInstance.gm.canSpawnPinkPixels--;
				this.gameObject.tag = "Pink";
				hasColor = true;
			}

			else if(willSpawn == 1 && Singleton.GetInstance.gm.canSpawnGreenPixels > 0){
				sp.color = Singleton.GetInstance.ssHeartColors[1];
				Singleton.GetInstance.gm.canSpawnGreenPixels--;
				this.gameObject.tag = "Green";
				hasColor = true;
			}
			else if(willSpawn == 2 && Singleton.GetInstance.gm.canSpawnPinkPixels > 0){
				sp.color = Singleton.GetInstance.ssHeartColors[2];
				Singleton.GetInstance.gm.canSpawnBluePixels--;
				this.gameObject.tag = "Blue";
				hasColor = true;
			}
		
		yield return new WaitForSeconds(0.5f);
		
		}

	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		
		if(coll.gameObject.tag == this.gameObject.tag)
		{
			CountingPixels(coll);

       //condição de vitoria
		if (Singleton.GetInstance.gm.totalPixelsDestroyed == Singleton.GetInstance.gm.totalPixels)
		{
				
			score = Mathf.CeilToInt((Singleton.GetInstance.time.minutes * 60f + Singleton.GetInstance.time.seconds)* 100);
            
            Score();
		   
		}
		else if(Singleton.GetInstance.gm.heartGainPixels >= Singleton.GetInstance.gm.totalPixels * 0.35){
			
			Singleton.GetInstance.gm.heartGainPixels = 0; 
			Instantiate(Singleton.GetInstance.collectableHeart ,transform.position,Quaternion.identity);
		}

		Sound();

		ParticleSystem[] ex = Explode.Self.GetExplosion();
		ex[0].transform.position = transform.position;
		ex[1].transform.position = transform.position;
		
		ex[0].Play();
		ex[1].Play();
		gameObject.SetActive(false);
			
		}  
	}

	
	void Sound()
	{
		if(Singleton.GetInstance.gm.switchSound)
		{		
			AudioManager.instance.Play("Crack");
			Singleton.GetInstance.gm.switchSound = false;
		//	print("tocando o  crack");	
		}
		else{
			AudioManager.instance.Play("Attack");
			Singleton.GetInstance.gm.switchSound = true;
		//	print("attack");
		}
	}

    void Score()
	{
		switch(SceneManager.GetActiveScene().buildIndex)
			{
				case 5 /*index da cena*/:
				if(score > PlayerPrefs.GetInt("Record1") || !PlayerPrefs.HasKey("Record1"))
			{
				PlayerPrefs.SetInt("Record1" , score);
				PlayerPrefs.Save();
			}
				break;

				case 6:
                if(score > PlayerPrefs.GetInt("Recor2") || !PlayerPrefs.HasKey("Record2"))
			{
				PlayerPrefs.SetInt("Record2" , score);
				PlayerPrefs.Save();
			}
				break;

				case 7:
                if(score > PlayerPrefs.GetInt("Record3") || !PlayerPrefs.HasKey("Record3"))
			{
				PlayerPrefs.SetInt("Record3" , score);
				PlayerPrefs.Save();
			}
				break;

				case 8:
                if(score > PlayerPrefs.GetInt("Record4") || !PlayerPrefs.HasKey("Record4"))
			{
				PlayerPrefs.SetInt("Record4" , score);
				PlayerPrefs.Save();
			}
				break;
			}
			 Singleton.GetInstance.sceneController.TransitionPlayerWon();
			 //StartCoroutine(PlayerWonTransition());
	}

	

}