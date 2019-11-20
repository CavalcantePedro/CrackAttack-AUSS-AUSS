using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionBox : MonoBehaviour
{
    
    [Header("Level Numbers")]

    [SerializeField] private Image numberUI;
    [SerializeField] private Sprite[] numberSprites;
    [SerializeField] private Animator numberAnim;
    [SerializeField] private GameObject plusOneBtn;
    [SerializeField] private GameObject minusOneBtn;
    [SerializeField] private int levelNumber;

    [Header("Record")]  
    [SerializeField] private Text recordText;
    private string recordSt;

    private int recordPlayer;

    [Header("Difficulty")]
    [SerializeField] private Toggle difficultySwitch;
    [HideInInspector] public string difficulty;
    

    void Start(){

        levelNumber = 1;
        //GameInit();
        ManagingLevels();
        CheckingRecord();
    
        StartCoroutine(UpdateBox());
    }

    void UpdateStatus(){
        numberUI.sprite = numberSprites[levelNumber];
        numberAnim.SetInteger("TransitionTo", levelNumber);
    }

    public void SelectNextLevel(){
        levelNumber++;
        ManagingLevels();
        CheckingRecord();
       // GameInit();
        StartCoroutine(InteractionSwitch());
    }

    public void SelectPreviousLevel(){
        levelNumber--;
        ManagingLevels();
        CheckingRecord();
        //GameInit();
        StartCoroutine(InteractionSwitch());
    }
    
    /* public void DifficultyChange(){
        
        if(difficultySwitch.isOn){
            difficulty = "hard";
        }

        else{
            difficulty = "easy";
        }

    }*/

    void ManagingLevels()
    {
        switch(levelNumber)
        {
            case 1 :
                minusOneBtn.SetActive(false);
            break;

            case 4 :
                plusOneBtn.SetActive(false);
            break;

            default:
                if(!minusOneBtn.activeSelf || !plusOneBtn.activeSelf){
                    minusOneBtn.SetActive(true);
                    plusOneBtn.SetActive(true);
                }
            break;
        }
    }

    void CheckingRecord()
    {

        switch(levelNumber) {
            case 1:
                recordPlayer = PlayerPrefs.GetInt("Record1");
            break;
            
            case 2:
                recordPlayer = PlayerPrefs.GetInt("Record2");
            break;

            case 3:
                recordPlayer = PlayerPrefs.GetInt("Record3");
            break;

            case 4:
                recordPlayer = PlayerPrefs.GetInt("Record4");
            break;
        }
        
        ShowingRecord();
    }

    void ShowingRecord() {
        if(recordPlayer > 0) {
            //recordSt = PlayerPrefs.GetInt(recordPlayerPref).ToString();
            recordText.text ="Record:" + recordPlayer.ToString();
        }
        else {
            recordText.text = "Record:0";
        }
    }

    public void GameInit(){

        

        print("Number info (1):" + PlayerPrefs.GetInt("Level"));

         switch(levelNumber){
            case 1:
                print("Entrou");
                 PlayerPrefs.SetInt("Level", levelNumber);
                SceneManager.LoadScene("Cutscene");
            break;
            
            case 2:
                print("Entrou2");
                 PlayerPrefs.SetInt("Level", levelNumber);
                SceneManager.LoadScene("GameA2");
            break;

            case 3:
             PlayerPrefs.SetInt("Level", levelNumber);
               SceneManager.LoadScene("GameA3");
            break;

            case 4:
             PlayerPrefs.SetInt("Level", levelNumber);
                SceneManager.LoadScene("GameA4");
            break;
        }
    }

    IEnumerator InteractionSwitch()
    {
        plusOneBtn.GetComponent<Button>().interactable = !plusOneBtn.GetComponent<Button>().interactable;
        minusOneBtn.GetComponent<Button>().interactable = !minusOneBtn.GetComponent<Button>().interactable;
        yield return new WaitForSeconds(0.25f);
        plusOneBtn.GetComponent<Button>().interactable = !plusOneBtn.GetComponent<Button>().interactable;
        minusOneBtn.GetComponent<Button>().interactable = !minusOneBtn.GetComponent<Button>().interactable;
    }

    IEnumerator UpdateBox() {
        for(;;){
            UpdateStatus();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
