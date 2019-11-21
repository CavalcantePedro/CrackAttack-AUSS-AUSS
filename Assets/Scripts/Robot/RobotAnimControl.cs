using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotAnimControl : MonoBehaviour
{
    public Animator[] robotAnims;

    public Animator curRobotAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        curRobotAnim = robotAnims[PlayerPrefs.GetInt("ColorBlind")];

        if(SceneManager.GetActiveScene().name == "GameA2" || SceneManager.GetActiveScene().name == "GameA2"|| SceneManager.GetActiveScene().name == "GameA4")
        {
            StartDancing();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Death();
        }
    }

    // Update is called once per frame
    public void Death()
    {
        curRobotAnim.SetTrigger("death");
    }

    public void  StartDancing()
    {
        curRobotAnim.SetBool("dancing", true);
    }
}
