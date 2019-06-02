using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : BaseCharacterMovement
{
    public float speed;

    private Transform _target;


	void Start()
	{
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

    void Update(){
		if (Vector3.Distance(_target.position, transform.position) <= 4.0f){
			transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
		}

		// _animator.SetFloat("speed", Mathf.Abs(horizontal));
		Flip((transform.position.x - _target.position.x) > 0f);

		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.GetChild(2).transform.position, 0.3f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "danger")
            {
                Kill();
            }
        }
    }

	override protected void Kill()
	{
		Destroy(gameObject);
	}
}
