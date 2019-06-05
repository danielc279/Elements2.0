using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateGrid : MonoBehaviour
{
// duration of the rotation in seconds, can be set via Inspector

    public bool is_Rotating = false;

    private GameObject player;

    private Rigidbody2D _RB;

    private PlayerMovement _PlayerMov;

    private Animator _Animator;

    private float time;

    private int _totalRotations = 0;

    private int _sendScore = 0;

    private ScoreManager _ScoreMan;
    void Start()
    {

        player = GameObject.Find("Player");
        _RB = player.gameObject.GetComponent<Rigidbody2D>();
        _PlayerMov = player.GetComponent<PlayerMovement>();
        _Animator = player.GetComponent<Animator>();

        _ScoreMan = FindObjectOfType<ScoreManager>();
    }

    void Update (){
        if (Input.GetKeyDown(KeyCode.C) && !is_Rotating && _PlayerMov.isGrounded) { 
            _totalRotations++;
            _sendScore = -1;
            _ScoreMan.UpdateScore(_sendScore);
            StartCoroutine(RotateObject(1, 1, 89));
        }
        if (Input.GetKeyDown(KeyCode.V) && !is_Rotating && _PlayerMov.isGrounded) {
            _totalRotations++;
            _sendScore = -1;
            _ScoreMan.UpdateScore(_sendScore);
            StartCoroutine(RotateObject(1, -1,-89));

        }
    }

    IEnumerator RotateObject(float rotateTime, float offset, float rotateAmount)
    {
        _RB.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        _PlayerMov.enabled = false;
        _Animator.enabled = false;
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
        _RB.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
        _PlayerMov.enabled = true;
        _Animator.enabled = true;
        yield return null;
    }

}
