using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseCharacterMovement : MonoBehaviour
{
    protected SpriteRenderer _spriteRenderer;

	protected Rigidbody2D _rigidbody;

	protected Animator _animator;

    protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

    protected void Flip(bool flip)
	{
		_spriteRenderer.flipX = flip;
	}



	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("danger"))
		{
			Kill();
		}
	}

	protected virtual void Kill()
    {
		SceneManager.LoadScene(7);
    }

}
