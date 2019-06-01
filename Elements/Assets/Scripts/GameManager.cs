using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Game Modes: Title Screen, Level Select, Play Level, Game Over
public class GameManager : MonoBehaviour {
	
	public static string lastLevelPlayed { get; set; }

	public void LevelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void Instructions()
	{
		SceneManager.LoadScene("Instructions");
	}

    public void RetryLevel()
	{
		SceneManager.LoadScene(lastLevelPlayed);
	}

    public void playLevel1()
	{
		SceneManager.LoadScene(3);
	}

    public void playLevel2()
	{
		SceneManager.LoadScene(4);
	}

    public void playLevel3()
	{
		SceneManager.LoadScene(5);
	}

	public void PlayGame(){
		
	}

	public void	NextLevel(){
		if(lastLevelPlayed != "Level3"){
			if(lastLevelPlayed == "Level1"){
				playLevel2();
			}else{
				playLevel3();
			}
		}
	}
}
