using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : BaseCharacterMovement
{

	[SerializeField]
	private bool _isGrounded;

    private int level;

    private ScoreManager _ScoreMan;

    void Start(){
        _ScoreMan = GameObject.FindObjectOfType<ScoreManager>();
        ScoreManager.complete = 0;
    }

	void Update()
	{
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.GetChild(2).transform.position, 0.3f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "battery")
            {
                Destroy(hitColliders[i].gameObject);
                _ScoreMan.BatteryCollection();

            }

            if (hitColliders[i].gameObject.tag == "enemy")
            {
                PlayerPrefs.SetInt("Complete", ScoreManager.complete);
                SceneManager.LoadScene("LevelComplete");
            }

            if (hitColliders[i].gameObject.tag == "danger")
            {
                PlayerPrefs.SetInt("Complete", ScoreManager.complete);
                Kill();
            }
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("door"))
        {
            ScoreManager.complete = 1;
            PlayerPrefs.SetInt("Complete", ScoreManager.complete);
            _ScoreMan.SaveScore();
            SceneManager.LoadScene("LevelComplete");             
        }
	}
}