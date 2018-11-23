using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator an;
    public static CameraController instance;

    void Start(){
        an = GetComponent<Animator>();
    }

    public void CameraShake(){
        an.SetTrigger("shake");
        

            Handheld.Vibrate();
    }
}