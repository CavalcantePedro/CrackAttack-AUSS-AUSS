using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAssembly : MonoBehaviour {

	[SerializeField] private GameObject pinkPixel;
	[SerializeField] private GameObject bluePixel;
	[SerializeField] private GameObject greenPixel;
	[SerializeField] private GameObject yellowPixel;
	[SerializeField] private GameObject borderPixel;
	[SerializeField] private Transform beginFirstLine;

	
	private GameObject[,] pixels;
	void Start () {
	
	pixels = new GameObject[66,41];
	for (int i = 0; i < 66; i++)
	{
 		print("glub glub");
		for (int j = 0; j < 41; j++)
	{
		//1°fileira
		if(i == 1)
		{
			if(j<=4)
			{
				//vazio
			}
			else if(j<= 50 && j > 4)
			{
				if(j == 5)
				{
					print("aids");
				Instantiate(borderPixel,beginFirstLine.position, Quaternion.identity);
				}
				else
				{
					print("cusujo");
				Instantiate(borderPixel , new Vector2(pixels[i,j-1].transform.position.x +0.081f , pixels[i,j-1].transform.position.y ) , Quaternion.identity);
				}
			}
		}
		//2° fileira
		if(i==2)
		{}

	}

	}

	}
	}
	
	