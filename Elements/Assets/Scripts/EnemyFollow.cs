using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : BaseCharacterMovement{
    public float speed;

    private GameObject[] _spikes;

	public RotateGrid rotateGrid;
    private Transform _target;

	private Interaction _Interact;

	public GameObject left;

	public GameObject right;

	public GameObject button;

	public GameObject wall;

	public bool _isAlive;

	void Start(){
		_isAlive = true;
		rotateGrid = GameObject.Find("Grid").GetComponent<RotateGrid>();
		left = GameObject.Find("LeftCheck");
		right = GameObject.Find("RightCheck");
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		_Interact = GameObject.Find("Player").GetComponent<Interaction>();
        _spikes = GameObject.FindGameObjectsWithTag("danger");
		button = GameObject.FindGameObjectWithTag("button");
		wall = GameObject.Find("Wall");
	}

    void Update(){

		if (Vector3.Distance(_target.position, transform.position) <= 5.0f && !rotateGrid.is_Rotating && _Interact._isDead == false){
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


		Flip((transform.position.x - _target.position.x) < 0f);

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
		_isAlive = false;
	}

	// override protected void Flip(bool flip){
	// 	_spriteRenderer.flipX = flip;

	// }
}
