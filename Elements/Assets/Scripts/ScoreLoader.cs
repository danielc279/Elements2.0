using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLoader : MonoBehaviour
{

    private int complete;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetInt("LastScore", 0).ToString());
        complete = PlayerPrefs.GetInt("Complete", 0);
        LevelComplete();
    }

    public void LevelComplete(){

        if(complete == 1){
            GameObject.Find("YouLose").SetActive(false);
            GameObject.Find("LevelComplete").SetActive(true);

        }else{
            GameObject.Find("YouLose").SetActive(true);
            GameObject.Find("LevelComplete").SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
