using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mushdinneGameManager : MonoBehaviour
{
	Camera cam;

	public Ball ball;
	public Trajectory trajectory;
	public GameObject t;
	public GameObject score;
	
	[SerializeField] float pushForce = 4f;

	public float timer = 0;
	public GameObject player;
	public GameObject m_OverObj = null;

	private bool m_IsGameOver = false;

	public Text m_Score = null;
	public Text m_Time = null;

	
	bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;

	//---------------------------------------
	void Start ()
	{
		cam = Camera.main;
		ball.DesactivateRb ();
		Refresh();
	}
	public void AddScore(int add)
	{
		Scoreboard.score += add;
		Refresh();
	}
	private void Refresh()
	{
		m_Score.GetComponent<Text>().text = Scoreboard.score.ToString("分數:0"); ;
	}


	void Update ()
	{
		
		if (m_IsGameOver)
			{
				return;
			}
		if (Input.GetMouseButtonDown (0)) {
			isDragging = true;
			OnDragStart ();
		}
		if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
			OnDragEnd ();
		}

		if (isDragging) {
			OnDrag ();
		}
		if (timer > 0)
		{
			timer -= Time.deltaTime;
			t.GetComponent<Text>().text = timer.ToString("時間:0,0");
		}
		else if (timer <= 0)
		{
			player.SetActive(false);
			m_IsGameOver = true;
			m_OverObj.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("level1");
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

	}

	//-Drag--------------------------------------
	void OnDragStart ()
	{
		ball.DesactivateRb ();
		startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

		trajectory.Show ();
	}

	void OnDrag ()
	{
		endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
		distance = Vector2.Distance (startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		Debug.DrawLine (startPoint, endPoint);


		trajectory.UpdateDots (ball.pos, force);
	}

	void OnDragEnd ()
	{
		//push the ball
		ball.ActivateRb ();

		ball.Push (force);

		trajectory.Hide ();
	}

}
