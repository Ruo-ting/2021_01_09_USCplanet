using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;
	public GameObject GM;

	[HideInInspector] public Vector3 pos { get { return transform.position; } }

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<CircleCollider2D>();
	}

	
	public void Push(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	public void ActivateRb()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		print(collision.gameObject.name);
		if (collision.gameObject.name == "Flower")
		{
			print("5");
			//分數加10
			GM.GetComponent<mushdinneGameManager>().AddScore(10);
			SceneManager.LoadScene("level2");
		}
		if (collision.gameObject.name == "Flower2")
		{
			//分數加10
			GM.GetComponent<mushdinneGameManager>().AddScore(20);
			SceneManager.LoadScene("level3");
		}
		if (collision.gameObject.name == "Flower3")
		{
			//分數加10
			GM.GetComponent<mushdinneGameManager>().AddScore(30);
			SceneManager.LoadScene("win");
			
		}


	}
    

}
