using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCount : MonoBehaviour {

	[SerializeField] private Text textCount;
	
	public void UpdateUI (int ballCount) {
		textCount.text =  "" + ballCount;
	}
}
