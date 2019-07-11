using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour {

	public float rotZ;
	public bool isJoystick;
	[SerializeField] private Transform joystickFollow;
	public GameObject angleArrow;
	[SerializeField] private BallCount ballCount;
	[SerializeField] private float delaySetColor, minDelaySetColor;
	public float DelaySetColor{
		get {return delaySetColor;}
		set {delaySetColor = value;}
	}
	[SerializeField] private SpriteRenderer paddleSprite;
	[SerializeField] private SpriteRenderer arrowSprite;
	[SerializeField] private float offset;
    [SerializeField] private float[] limits;
	[SerializeField] private List<Color_Name> colors;
	public bool changeColor;

    void Start() 
	{
		changeColor = true;
		SetColorsPaddle();	
		angleArrow.SetActive(false);
		StartCoroutine(SetColor());
    }


	void Update ()
    {
		Vector3 difference = Difference();
		rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		if(rotZ >= 0)
		{
			rotZ = Mathf.Clamp(rotZ, limits[0], limits[1]);
			transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
		}
	}

	void SetColorsPaddle(){
		colors[0].color = Singleton.GetInstance.ssHeartColors[0];
		colors[1].color = Singleton.GetInstance.ssHeartColors[2];
		colors[2].color = Singleton.GetInstance.ssHeartColors[1];
	}

	public Vector3 Difference()
    {
		if(isJoystick)
        {
			return joystickFollow.position - transform.position;
		}
		return Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	}

	public void SetJoystick(Transform joy){
		joystickFollow = joy;
	}

	public void Shot(PaddleController playerScript) {

		var obj =  ObjectPooler.instance.GetPooledObject();

		SpriteRenderer sp = obj.GetComponentInChildren<SpriteRenderer>();
		sp.color = paddleSprite.color;
		obj.tag = SetTag(sp.color);
		
		if(obj != null){
			obj.transform.position = transform.position;
			obj.SetActive(true);
			if(AudioManager.instance != null)
				AudioManager.instance.Play("Shot");
			playerScript.DecreasingBalls();
		}
	}

	Color RandomBallColor(Color cl){
		Color colorReturn = Color.white;
		Color_Name tempColor;
		//Verificar qual a cor;
		int index = 0;
		for (int i = 0; i < colors.Count; i++)
		{
			if(colors[i].color == cl){
				index = i;
			}
		}
		tempColor = colors[index];
		//Remove-la;
		colors.RemoveAt(index);

		//Cor aleatoria;
		int randomIndex = Random.Range(0, colors.Count);
		colorReturn = colors[randomIndex].color;

		//Colocar a cor novamente;
		colors.Add(tempColor);
		return colorReturn;
	}
	string SetTag(Color target)
	{
		for(int i = 0; i < colors.Count; i++)
		{
			if(target == colors[i].color)
			{
				return colors[i].name;
			}
		}
		
		return "Error";
	}

	 
	IEnumerator SetColor(){
		while(true){
			if(changeColor){
				paddleSprite.color = RandomBallColor(paddleSprite.color);
				arrowSprite.color = paddleSprite.color;
			}
			yield return new WaitForSeconds(delaySetColor);
		}
	}

	public void ColorChangeSpeed(float delay)
	{
		delaySetColor -= delay;
	}

	public float Variance()
	{
		return delaySetColor - minDelaySetColor;
	}
}