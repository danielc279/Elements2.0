using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Game Modes: Title Screen, Level Select, Play Level, Game Over
public class GameManager : MonoBehaviour {
	
	public ScoreManager _ScoreMan;
	public static int lastLevel { get; set; }

	public GameObject two;

	public GameObject three;

	public void Start()
	{
		Scene scene = SceneManager.GetActiveScene();
		_ScoreMan = GameObject.FindObjectOfType<ScoreManager>();
		if(scene.name == "LevelSelect")
		{
		two = GameObject.Find("2");
		three = GameObject.Find("3");
		
			if(PlayerPrefs.GetInt("LevelsUnlocked") > 1){
				two.GetComponent<Image>().color = Color.white;
			}

			if(PlayerPrefs.GetInt("LevelsUnlocked") > 2){
				three.GetComponent<Image>().color = Color.white;
			}

		if(PlayerPrefs.GetInt("HighLevel1", 0) < 1)
		{
				GameObject.Find("Star11").SetActive(false);
		}
		if(PlayerPrefs.GetInt("HighLevel1", 0) < 6)
		{
				GameObject.Find("Star12").SetActive(false);
		}
		if(PlayerPrefs.GetInt("HighLevel1", 0) < 9)
		{
				GameObject.Find("Star13").SetActive(false);
		}

		if(PlayerPrefs.GetInt("HighLevel2", 0) < 1)
		{
				GameObject.Find("Star21").SetActive(false);
		}
		if(PlayerPrefs.GetInt("HighLevel2", 0) < 5)
		{
				GameObject.Find("Star22").SetActive(false);
		}
		if(PlayerPrefs.GetInt("HighLevel2", 0) < 8)
		{
				GameObject.Find("Star23").SetActive(false);
		}	

		if(PlayerPrefs.GetInt("HighLevel3", 0) < 1)
		{
				GameObject.Find("Star31").SetActive(false);
		}
		if(PlayerPrefs.GetInt("HighLevel3", 0) < 7)
		{
				GameObject.Find("Star32").SetActive(false);
		}
		if(PlayerPrefs.GetInt("HighLevel3", 0) < 10)
		{
				GameObject.Find("Star33").SetActive(false);
		}	
		}		
	}

	public void LevelSelect()
	{ 
		SceneManager.LoadScene("LevelSelect");
		//PlayerPrefs.DeleteAll();
	}

	public void Level1()
	{
		SceneManager.LoadScene("Level1");
		PlayerPrefs.SetInt("LastLevel", 1);
		PlayerPrefs.SetInt("LastScore", 0);
	}

	public void Level2()
	{
		if(PlayerPrefs.GetInt("LevelsUnlocked") > 1){
			SceneManager.LoadScene("Level2");
			PlayerPrefs.SetInt("LastLevel", 2);
			PlayerPrefs.SetInt("LastScore", 0);
			}
	}

	public void Level3()
	{
		if(PlayerPrefs.GetInt("LevelsUnlocked") > 2){			
			SceneManager.LoadScene("Level3");
			PlayerPrefs.SetInt("LastLevel", 3);
			PlayerPrefs.SetInt("LastScore", 0);
		}
	}

	public void Instructions()
	{		
		SceneManager.LoadScene("Instructions");
	}

	public void BackToMain()
	{	
		SceneManager.LoadScene("TitleScreen");
	}

    public void RetryLevel()
	{	
		int retry = PlayerPrefs.GetInt("LastLevel");
		SceneManager.LoadScene("Level" + retry);
		_ScoreMan.ResetScore();
	}

    public void playNext()
	{	
		int next = PlayerPrefs.GetInt("LastLevel") + 1;
		PlayerPrefs.SetInt("LastLevel", next);
		SceneManager.LoadScene("Level" + next);
		_ScoreMan.ResetScore();
	}
}
