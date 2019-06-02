using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour{
    public static int score { get; private set; }

    [SerializeField]
    public int batteries;

    public static int complete { get; set; }

    public GameObject battery1;
    public GameObject battery2;
    public GameObject battery3;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI finalScoreText;

    public TextMeshProUGUI youLose;

    public TextMeshProUGUI youWin;

    //private List<GameObject> batteryPack;
    
    void Start(){

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        finalScoreText = GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        youLose = GameObject.Find("YouLose").GetComponent<TextMeshProUGUI>();
        youWin = GameObject.Find("LevelComplete").GetComponent<TextMeshProUGUI>();

        batteries = 0;
        // batteryPack = new List<GameObject> { battery1, battery2, battery3 };

        // foreach(var battery in batteryPack){
        //     if(SceneManager.GetActiveScene().name == "Level1"){
        //         battery.SetActive(false);
        //     }
        // }
    }

    public void BatteryCollection(){
        batteries++;
        // batteryPack[batteries-1].SetActive(true);
        UpdateScore(10);
    }

    

    public void UpdateScore(int points){
        score += points;
        scoreText.SetText(score.ToString());
    }

    public void SaveScore(){
        PlayerPrefs.SetInt("LastScore", score);
    }
}
