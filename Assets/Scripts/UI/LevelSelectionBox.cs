using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionBox : MonoBehaviour
{
    
    [Header("Level Numbers")]

    [SerializeField] private Image numberUI;
    [SerializeField] private Sprite[] numberSprites;
    [SerializeField] private Animator numberAnim;
    [SerializeField] private GameObject plusOneBtn;
    [SerializeField] private GameObject minusOneBtn;
    private int levelNumber;

    void Start()
    {
        levelNumber = 1;
        ManagingLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SelectNextLevel()
    {
        levelNumber++;
        ManagingLevels();
    }

    public void SelectPreviousLevel()
    {
        levelNumber--;
        ManagingLevels();
    }

    void ManagingLevels()
    {
        numberUI.sprite = numberSprites[levelNumber];
        print("a");
        numberAnim.SetInteger("TransitionTo",levelNumber);
        switch(levelNumber)
        {
        case 1 :
        minusOneBtn.SetActive(false);
        break;

        case 4 :
        plusOneBtn.SetActive(false);
        break;

        default:
        if(!minusOneBtn.activeSelf || !plusOneBtn.activeSelf)
        {
        minusOneBtn.SetActive(true);
        plusOneBtn.SetActive(true);
        }
        break;
        }

    }
}
