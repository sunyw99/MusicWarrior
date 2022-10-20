using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextTutorial : MonoBehaviour
{

    ///private Text shortNoteInstruction;
    [SerializeField] private GameObject Player;
    [SerializeField] private TextMeshProUGUI shortNoteInstruction;
    [SerializeField] private TextMeshProUGUI longNoteInstruction;
    [SerializeField] private TextMeshProUGUI upSwitchInstruction;
    [SerializeField] private TextMeshProUGUI downSwitchInstruction;
    [SerializeField] private TextMeshProUGUI blockInstruction;
    [SerializeField] private TextMeshProUGUI finishInstruction;
    [SerializeField] private TextMeshProUGUI TripleInstruction;
    [SerializeField] private TextMeshProUGUI passdownInstruction;
    [SerializeField] private TextMeshProUGUI passupInstruction;
    
    private PlayerControl playerControl;
    
    private bool shortNoteLearned = false;
    private bool tripleLearned1 = false;
    private bool tripleLearned2 = false;
    
    private bool longNoteLearned = false;
    private bool upSwitchLearned = false;
    private bool downSwitchLearned = false;
    private bool blockLearned = false;
    private bool passdownLearned = false;
    private bool passupLearned = false;

    private float firstShortNoteTime = 2f;
    private float t1ShortNoteTime = 3.55f;
    private float t2ShortNoteTime = 4.75f;
    
    private float firstLongNoteTime = 8.2f;
    // private float firstBlockTime = 7.5f;
    private float firstUpSwitchTime = 12f;
    private float firstDownSwitchTime = 14f;
    private float passdownSwitchTime = 16f;
    private float passupSwitchTime = 18f;
    private float finishTime = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        shortNoteInstruction.enabled = false;
        longNoteInstruction.enabled = false;
        upSwitchInstruction.enabled = false;
        downSwitchInstruction.enabled = false;
        blockInstruction.enabled = false;
        finishInstruction.enabled = false;
        TripleInstruction.enabled=false;
        passdownInstruction.enabled=false;
        passupInstruction.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {

        // if(fading){
        //     Alpha = Alpha - (Time.deltaTime)/2;
        //     colorOri.a = Alpha;
        //     notification.color = colorOri;
        //     if(Alpha<=0){
        //         fading=false;
        //     }
        // }else{
        //     Alpha = Alpha + (Time.deltaTime)/2;
        //     colorOri.a = Alpha;
        //     notification.color = colorOri;
        //     if(Alpha>=1){
        //         fading=true;
        //     }
        // }

        if(!shortNoteLearned && Time.timeSinceLevelLoad >= firstShortNoteTime){
            Time.timeScale = 0f;
            shortNoteInstruction.enabled = true;
            if (Input.GetKeyDown(KeyCode.J)) {
                shortNoteLearned = true;
                shortNoteInstruction.enabled = false;
                Time.timeScale = 1f;
            }
        }
        if(!tripleLearned1 && Time.timeSinceLevelLoad >= t1ShortNoteTime){
            Time.timeScale = 0f;
            TripleInstruction.enabled = true;
            if (Input.GetKeyDown(KeyCode.J)) {
                tripleLearned1 = true;
                TripleInstruction.enabled = false;
                Time.timeScale = 1f;
            }
        }
       
        
        if(!longNoteLearned && Time.timeSinceLevelLoad >= firstLongNoteTime){
            Time.timeScale = 0f;
            longNoteInstruction.enabled = true;
            if (Input.GetKeyDown(KeyCode.K)) {
                longNoteLearned = true;
                longNoteInstruction.enabled = false;
                Time.timeScale = 1f;
            }
        }
        // if(!blockLearned && Time.timeSinceLevelLoad >= firstBlockTime){
        //     Time.timeScale = 0f;
        //     blockInstruction.enabled = true;
        //     if (Input.GetKeyDown(KeyCode.J)) {
        //         blockLearned = true;
        //         blockInstruction.enabled = false;
        //         Time.timeScale = 1f;
        //     }
        // }
        if (Time.timeSinceLevelLoad < firstUpSwitchTime) {
            playerControl = Player.GetComponent<PlayerControl>();
            playerControl.canChangeGravity = false;
        }
        if(!upSwitchLearned && Time.timeSinceLevelLoad >= firstUpSwitchTime){
            Time.timeScale = 0f;
            upSwitchInstruction.enabled = true;
            playerControl = Player.GetComponent<PlayerControl>();
            playerControl.canChangeGravity = true;
            if (Input.GetKeyDown(KeyCode.W)) {
                upSwitchLearned = true;
                upSwitchInstruction.enabled = false;
                playerControl.canChangeGravity = false;
                Time.timeScale = 1f;
            }
        }
        if(!downSwitchLearned && Time.timeSinceLevelLoad >= firstDownSwitchTime){
            Time.timeScale = 0f;
            downSwitchInstruction.enabled = true;
            playerControl = Player.GetComponent<PlayerControl>();
            playerControl.canChangeGravity = true;
            if (Input.GetKeyDown(KeyCode.S)) {
                downSwitchLearned = true;
                downSwitchInstruction.enabled = false;
                playerControl.canChangeGravity = false;
                Time.timeScale = 1f;
            }
        }
        if(!passdownLearned && Time.timeSinceLevelLoad >= passdownSwitchTime){
            Time.timeScale = 0f;
            passdownInstruction.enabled = true;
            playerControl = Player.GetComponent<PlayerControl>();
            playerControl.canChangeGravity = true;
            if (Input.GetKeyDown(KeyCode.S)) {
                passdownLearned = true;
                passdownInstruction.enabled = false;
                playerControl.canChangeGravity = false;
                Time.timeScale = 1f;
            }
        }
        if(!passupLearned && Time.timeSinceLevelLoad >= passupSwitchTime){
            Time.timeScale = 0f;
            passupInstruction.enabled = true;
            playerControl = Player.GetComponent<PlayerControl>();
            playerControl.canChangeGravity = true;
            if (Input.GetKeyDown(KeyCode.W)) {
                passupLearned = true;
                passupInstruction.enabled = false;
                Time.timeScale = 1f;
            }
        }
        if(Time.timeSinceLevelLoad >= finishTime){
            Time.timeScale = 0f;
            finishInstruction.enabled = true;
            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("LevelMenu");
            }
        }
    }

}
