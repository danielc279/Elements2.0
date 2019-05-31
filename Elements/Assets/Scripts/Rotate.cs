using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rotate : MonoBehaviour
{
// duration of the rotation in seconds, can be set via Inspector

private bool is_Rotating = false;
private GameObject player;

private Rigidbody2D myRB;

private PlayerMovement myPlayerMov;

public int score { get; private set; }

private Animator myAnimator;
private float time;

public TextMeshProUGUI scoreUI;

void Start()
{

    player = GameObject.Find("Player");
    myRB = player.gameObject.GetComponent<Rigidbody2D>();
    myPlayerMov = player.GetComponent<PlayerMovement>();
    myAnimator = player.GetComponent<Animator>();
    score = 0;
}

void Update () {
    if (Input.GetKeyDown(KeyCode.C) && !is_Rotating && myPlayerMov.isGrounded) { 
        score++;
        scoreUI.SetText(score.ToString());
        StartCoroutine(RotateObject(1, 1, 89));
    }
    if (Input.GetKeyDown(KeyCode.V) && !is_Rotating && myPlayerMov.isGrounded) {
        score++;
        scoreUI.SetText(score.ToString());
        StartCoroutine(RotateObject(1, -1,-89));

    }
}

IEnumerator RotateObject(float rotateTime, float offset, float rotateAmount)
{
    myRB.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    myPlayerMov.enabled = false;
    myAnimator.enabled = false;
    Quaternion tmpRotation = transform.rotation;
    is_Rotating = true;
    while (time < rotateTime)
    {
    float timePassed = Time.deltaTime;
    time += timePassed;
    transform.RotateAround(player.transform.GetChild(1).transform.position, Vector3.forward, rotateAmount * timePassed);
    yield return new WaitForSeconds(timePassed/1.5f);
    }
    is_Rotating = false;
    transform.RotateAround(player.transform.GetChild(1).transform.position, Vector3.forward, tmpRotation.eulerAngles.z + rotateAmount + offset - transform.rotation.eulerAngles.z);
    time = 0.0f;
    myRB.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
    myPlayerMov.enabled = true;
    myAnimator.enabled = true;
    yield return null;
}

}
