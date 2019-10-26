using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorBlindSettings : MonoBehaviour
{
    [SerializeField] private Animator[] animators;

    void Start()
    {
        animators[PlayerPrefs.GetInt("ColorBlind")].SetBool("glitching", true);
    }
    public void SetColorBlind(int colorSet){

        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetBool("glitching", false);
        }
        PlayerPrefs.SetInt("ColorBlind", colorSet);
        animators[colorSet].SetBool("glitching", true);
        }
}
