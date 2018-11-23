using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebOpenUrl : MonoBehaviour {

	public void OpenSite(string name){
		Application.OpenURL(name);
	}
}
