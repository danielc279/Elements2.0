using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : BaseCharacterMovement
{

	[SerializeField]
	private bool isGrounded;

    private GameObject Battery1;

    private GameObject Battery2;
    private GameObject Battery3;

    public float star1;
    public float star2;
    public float star3;

    private float userscore;

    [SerializeField]
    public int battery;
	void Start()
	{
        battery = 0;
        Battery1 = GameObject.Find("Battery1");
        Battery2 = GameObject.Find("Battery2");
        Battery3 = GameObject.Find("Battery3");
        Battery1.SetActive(false);
        Battery2.SetActive(false);
        Battery3.SetActive(false);
	}

	void Update()
	{
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "battery")
            {
            battery +=1;
			Destroy (hitColliders[i].gameObject);

                if (battery == 1)
                {
                Battery1.SetActive(true);
                }

                if (battery == 2)
                {
                Battery2.SetActive(true);
                }

                if (battery == 3)
                {
                Battery3.SetActive(true);
                }

            }

            if (hitColliders[i].gameObject.tag == "enemy")
            {
                  SceneManager.LoadScene(7);
            }

            if (hitColliders[i].gameObject.tag == "danger")
            {
                  Kill();
            }
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{

        if (other.gameObject.CompareTag("door") && battery == 3)
        {
            SceneManager.LoadScene(6);
        }
	}

    public void Stars()
    {
        if (userscore < star1)
        {

        }
    }
}