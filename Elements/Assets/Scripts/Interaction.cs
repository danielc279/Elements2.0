using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : BaseCharacterMovement
{

	[SerializeField]
	private bool _isGrounded;

    private ScoreManager _ScoreMan;

    void Start(){
        _ScoreMan = GameObject.FindObjectOfType<ScoreManager>();
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
                ScoreManager.complete = false;
                SceneManager.LoadScene("LevelComplete");
            }

            if (hitColliders[i].gameObject.tag == "danger")
            {
                ScoreManager.complete = false;
                Kill();
            }
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("door") && _ScoreMan.batteries == 3)
        {
            ScoreManager.complete = true;
            SceneManager.LoadScene("LevelComplete");
        }
	}
}