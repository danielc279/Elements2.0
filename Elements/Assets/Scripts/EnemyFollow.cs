using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : BaseCharacterMovement{
    public float speed;

    private GameObject[] _spikes;

    private Transform _target;

	public GameObject left;

	public GameObject right;

	public GameObject button;

	public GameObject wall;

	void Start(){
		left = GameObject.Find("LeftCheck");
		right = GameObject.Find("RightCheck");
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _spikes = GameObject.FindGameObjectsWithTag("danger");
		button = GameObject.FindGameObjectWithTag("button");
		wall = GameObject.FindGameObjectWithTag("wall");
	}

    void Update(){

		if (Vector3.Distance(_target.position, transform.position) <= 4.0f){
			//Check if the rays hit 
			if(Physics2D.Raycast(left.transform.position, Vector2.down, 0.01f))
			{

				if(Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime).x < transform.position.x)
				{
					transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
				}	
			}

			if(Physics2D.Raycast(right.transform.position, Vector2.down, 0.01f))
			{
				if(Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime).x > transform.position.x)
				{
					transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
				}	
			}


		Flip((transform.position.x - _target.position.x) > 0f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "danger"){
                Kill();
            }
		if (collider.gameObject.tag == "button"){
                Destroy(button);
				Destroy(wall);
            }	
    }

	override protected void Kill(){
		Destroy(gameObject);
	}

	// override protected void Flip(bool flip){
	// 	_spriteRenderer.flipX = flip;

	// }
}
