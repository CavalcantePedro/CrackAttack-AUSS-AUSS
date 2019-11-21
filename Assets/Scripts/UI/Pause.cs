using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused;
    [SerializeField] private GameObject pauseMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if(!paused)
        {
            Time.timeScale = 0;
            AudioManager.instance.Pause("Glitch 3.0");
            pauseMenu.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            AudioManager.instance.Play("Glitch 3.0");
            pauseMenu.SetActive(false);
        }


        StartCoroutine(ToggleVariableWithDelay());
    }

    IEnumerator ToggleVariableWithDelay()
    {
        yield  return new WaitForSeconds(0.5f);
        paused = !paused;
    }

}
