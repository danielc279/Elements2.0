using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{    public int timeLeft = 61;
 
    void Start(){

        InvokeRepeating("Countdown", 1, 1);
    }

    void Countdown(){
        if(timeLeft != 0){
            timeLeft--;
            string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
            string seconds = (timeLeft % 60).ToString("00");
        
            gameObject.GetComponent<TextMeshProUGUI>().SetText(string.Format("{0}:{1}", minutes, seconds));
        }
    }
 
    void Update(){
        if(timeLeft == 0){
            PlayerPrefs.SetInt("Complete", ScoreManager.complete);
            SceneManager.LoadScene("LevelComplete");
        } 
    }
}
