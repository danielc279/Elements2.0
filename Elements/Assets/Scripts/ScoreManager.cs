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

    public static bool complete { get; set; }


    public GameObject battery1;
    public GameObject battery2;
    public GameObject battery3;

    public TextMeshProUGUI scoreText;

    private List<GameObject> batteryPack;
    
    void Start(){

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        batteries = 0;
        batteryPack = new List<GameObject> { battery1, battery2, battery3 };

        foreach(var battery in batteryPack){
            if(SceneManager.GetActiveScene().name == "Level1"){
                battery.SetActive(false);
            }
        }

        //if(SceneManager.GetActiveScene().name == "LevelComplete") LevelComplete();
    }

    public void BatteryCollection(){
        batteries++;
        batteryPack[batteries-1].SetActive(true);
        UpdateScore(10);
    }

    // public void LevelComplete(){

    //     if(complete){
    //         GameObject.Find("YouLose").SetActive(false);

    //         for(var i = 0; i < batteries; i++){
    //             batteryPack[i].GetComponent<Image>().color = Color.white;
    //         }

    //         GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>().SetText(score.ToString());
    //     }else{
    //         GameObject.Find("LevelComplete").SetActive(false);
    //     }

    // }

    public void UpdateScore(int points){
        score += points;
        scoreText.SetText(score.ToString());
    }
}
