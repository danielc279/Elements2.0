using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour{

    
    private int score;
    [SerializeField]
    public int startScore;

    public static int complete { get; set; }

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI finalScoreText;

    public TextMeshProUGUI youLose;

    public TextMeshProUGUI youWin;




    //private List<GameObject> batteryPack;
    
    void Start(){
		Scene scene = SceneManager.GetActiveScene();
        score = startScore;
        if(scene.name == "Level1" || scene.name == "Level2" ||scene.name == "Level3"){
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.SetText(score.ToString());
        }
        if(scene.name == "LevelComplete"){
        finalScoreText = GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        youLose = GameObject.Find("YouLose").GetComponent<TextMeshProUGUI>();
        youWin = GameObject.Find("LevelComplete").GetComponent<TextMeshProUGUI>();
        }

    }

    public void BatteryCollection(){
        // batteryPack[batteries-1].SetActive(true);
        UpdateScore(2);
    }

    

    public void UpdateScore(int points){
        score += points;
        scoreText.SetText(score.ToString());
        if(score == 0){
            PlayerPrefs.SetInt("Complete", ScoreManager.complete);
            SceneManager.LoadScene("LevelComplete");
        } 
    }

    public void SaveScore(){
        PlayerPrefs.SetInt("LastScore", score);
    }

    public void ResetScore(){
        if(PlayerPrefs.GetInt("LastLevel") == 1){
        startScore = PlayerPrefs.GetInt("StartScoreLevel1", 10);
        }
        if(PlayerPrefs.GetInt("LastLevel") == 2){
        startScore = PlayerPrefs.GetInt("StartScoreLevel1", 10);
        }
        if(PlayerPrefs.GetInt("LastLevel") == 3){
        startScore = PlayerPrefs.GetInt("StartScoreLevel1", 10);
        }
        score = startScore;
    }
}
