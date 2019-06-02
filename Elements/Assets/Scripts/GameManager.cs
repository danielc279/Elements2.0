using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Game Modes: Title Screen, Level Select, Play Level, Game Over
public class GameManager : MonoBehaviour {
	
	public static int lastLevel { get; set; }

	public void LevelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void Level1()
	{
		SceneManager.LoadScene("Level1");
		PlayerPrefs.SetInt("LastLevel", 1);
	}

	public void Level2()
	{
		SceneManager.LoadScene("Level2");
		PlayerPrefs.SetInt("LastLevel", 2);
	}

	public void Level3()
	{
		SceneManager.LoadScene("Level3");
		PlayerPrefs.SetInt("LastLevel", 3);
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
	}

    public void playNext()
	{
		int next = PlayerPrefs.GetInt("LastLevel") + 1;
		PlayerPrefs.SetInt("LastLevel", next);
		SceneManager.LoadScene("Level" + next);
	}

	public void PlayGame(){
		
	}
}
