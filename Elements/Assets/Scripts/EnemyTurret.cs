using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{    
    private Transform _target;

    private Rigidbody2D _rigidbody;


    void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();

        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

    void Update(){

        float angle = Mathf.Atan2(_target.position.y, _target.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (Vector3.Distance(_target.position, transform.position) <= 4.0f){ 
		}
    }
}
