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
    
    private PlayerControl playerControl;
    
    private bool shortNoteLearned = false;
    private bool longNoteLearned = false;
    private bool upSwitchLearned = false;
    private bool downSwitchLearned = false;
    private bool blockLearned = false;

    private float firstShortNoteTime = 2f;
    private float firstLongNoteTime = 3.75f;
    private float firstBlockTime = 7.5f;
    private float firstUpSwitchTime = 9.15f;
    private float firstDownSwitchTime = 10.75f;
    private float finishTime = 12.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        shortNoteInstruction.enabled = false;
        longNoteInstruction.enabled = false;
        upSwitchInstruction.enabled = false;
        downSwitchInstruction.enabled = false;
        blockInstruction.enabled = false;
        finishInstruction.enabled = false;
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
        if(!longNoteLearned && Time.timeSinceLevelLoad >= firstLongNoteTime){
            Time.timeScale = 0f;
            longNoteInstruction.enabled = true;
            if (Input.GetKeyDown(KeyCode.K)) {
                longNoteLearned = true;
                longNoteInstruction.enabled = false;
                Time.timeScale = 1f;
            }
        }
        if(!blockLearned && Time.timeSinceLevelLoad >= firstBlockTime){
            Time.timeScale = 0f;
            blockInstruction.enabled = true;
            if (Input.GetKeyDown(KeyCode.J)) {
                blockLearned = true;
                blockInstruction.enabled = false;
                Time.timeScale = 1f;
            }
        }
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
