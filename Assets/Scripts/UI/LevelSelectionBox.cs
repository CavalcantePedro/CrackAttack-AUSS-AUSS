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

    [Header("Record")]  
    [SerializeField] private Text recordText;
    private string recordSt;

    private string recordPlayerPref;

    [Header("Difficulty")]
    [SerializeField] private Toggle difficultySwitch;
    [HideInInspector] public string difficulty;
    

    void Start()
    {
        levelNumber = 1;
        ManagingLevels();
        CheckingRecord();
    }

    public void SelectNextLevel()
    {
        levelNumber++;
        ManagingLevels();
        CheckingRecord();
    }

    public void SelectPreviousLevel()
    {
        levelNumber--;
        ManagingLevels();
        CheckingRecord();
    }
    
    public void DifficultyChange()
    {
        if(difficultySwitch.isOn)
        {
            difficulty = "hard";
        }

        else
        {
            difficulty = "easy";
        }

    }

    void ManagingLevels()
    {
        numberUI.sprite = numberSprites[levelNumber];
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

    void CheckingRecord()
    {
      switch(levelNumber)
      {
          case 1:
            recordPlayerPref = "Record1";
          break;
          
          case 2:
            recordPlayerPref = "Record2";
          break;

          case 3:
           recordPlayerPref = "Record3";
          break;

          case 4:
           recordPlayerPref = "Record4";
          break;
      }
        ShowingRecord();
    }

    void ShowingRecord()
    {
        if(PlayerPrefs.HasKey(recordPlayerPref))
        {
            recordSt = PlayerPrefs.GetInt(recordPlayerPref).ToString();
            recordText.text ="Record:" + recordSt;
        }
            else
        {
            recordText.text = "Record:0";
        }
    }
}
