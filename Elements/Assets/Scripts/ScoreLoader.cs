using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreLoader : MonoBehaviour
{

    private int complete;

    public TextMeshProUGUI finalScoreText;

    public TextMeshProUGUI gameEndScoreText;
    public int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = PlayerPrefs.GetInt("LastScore", 0);
        finalScoreText = GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        finalScoreText.SetText(finalScore.ToString());
        gameEndScoreText = GameObject.Find("GameEndScoreText").GetComponent<TextMeshProUGUI>();
        gameEndScoreText.SetText(finalScore.ToString());
        complete = PlayerPrefs.GetInt("Complete", 0);
        LevelComplete();
    }

    public void LevelComplete(){

        if(complete == 1){
            
            if(PlayerPrefs.GetInt("LastLevel") == 1){
                GameObject.Find("YouLose").SetActive(false);
                GameObject.Find("GameEnd").SetActive(false);
                GameObject.Find("LevelComplete").SetActive(true);
                int last1 = PlayerPrefs.GetInt("LastLevel", 0);
                int high1 = PlayerPrefs.GetInt("Highlevel1", 0);
                if(finalScore > high1){
                    PlayerPrefs.SetInt("HighLevel1", finalScore);
                }
                PlayerPrefs.SetInt("LevelsUnlocked", last1 + 1);
                if(finalScore < 4)
                {
                     GameObject.Find("Star2").SetActive(false);
                }
                if(finalScore < 8)
                {
                     GameObject.Find("Star3").SetActive(false);
                }
            }
            if(PlayerPrefs.GetInt("LastLevel") == 2){
                GameObject.Find("YouLose").SetActive(false);
                GameObject.Find("GameEnd").SetActive(false);
                GameObject.Find("LevelComplete").SetActive(true);
                int last2 = PlayerPrefs.GetInt("LastLevel", 0);
                int high2 = PlayerPrefs.GetInt("Highlevel2", 0);
                if(finalScore > high2){
                    PlayerPrefs.SetInt("HighLevel2", finalScore);
                }
                PlayerPrefs.SetInt("LevelsUnlocked", last2 + 1);
                if(finalScore < 4)
                {
                     GameObject.Find("Star2").SetActive(false);
                }
                if(finalScore < 8)
                {
                     GameObject.Find("Star3").SetActive(false);
                }
            }
            if(PlayerPrefs.GetInt("LastLevel") == 3){
                GameObject.Find("YouLose").SetActive(false);
                GameObject.Find("GameEnd").SetActive(true);
                GameObject.Find("LevelComplete").SetActive(false);
                int last3 = PlayerPrefs.GetInt("LastLevel", 0);
                int high3 = PlayerPrefs.GetInt("Highlevel3", 0);
                if(finalScore > high3){
                    PlayerPrefs.SetInt("HighLevel3", finalScore);
                }             
                if(finalScore < 4)
                {
                     GameObject.Find("Star2").SetActive(false);
                }
                if(finalScore < 8)
                {
                     GameObject.Find("Star3").SetActive(false);
                }
            }

        }else{
            GameObject.Find("YouLose").SetActive(true);
            GameObject.Find("LevelComplete").SetActive(false);
            GameObject.Find("GameEnd").SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
