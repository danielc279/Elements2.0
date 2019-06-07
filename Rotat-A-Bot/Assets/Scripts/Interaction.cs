using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : BaseCharacterMovement
{
    public bool _isDead;

    

    private ScoreManager _ScoreMan;

    void Start(){
        _ScoreMan = GameObject.FindObjectOfType<ScoreManager>();

        ScoreManager.complete = 0;
    }

	void Update()
	{
        if(_isDead == false){


            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.GetChild(2).transform.position, 0.3f);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.tag == "battery")
                {
                    Destroy(hitColliders[i].gameObject);
                    _ScoreMan.BatteryCollection();
                    AudioManager.upgrade.Play(0);               

                }

                if (hitColliders[i].gameObject.tag == "enemy")
                {
                    PlayerPrefs.SetInt("Complete", ScoreManager.complete);
                    _isDead = true;
                    AudioManager.death.Play(0);
                    SceneManager.LoadScene("LevelComplete"); 
                }

                if (hitColliders[i].gameObject.tag == "danger")
                {
                    PlayerPrefs.SetInt("Complete", ScoreManager.complete);
                    _isDead = true;
                    AudioManager.death.Play(0);
                          Kill();

                }
            }
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if(_isDead == false){
            if (other.gameObject.CompareTag("door"))
            {
                ScoreManager.complete = 1;
                PlayerPrefs.SetInt("Complete", ScoreManager.complete);
                _ScoreMan.SaveScore();            
                AudioManager.win.Play(0);
                _isDead = true;      
                        SceneManager.LoadScene("LevelComplete");     
            }
        }
	}
}