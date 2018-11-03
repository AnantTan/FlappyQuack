using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

	public static GameControl instance;
	public GameObject gameOverText;
	public GameObject gameWinText;
	public Text scoreText;
	public bool gameOver = false;
	public float scrollSpeed = -2f;
	private int score = 0;

	// Use this for initialization
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		gameOverText.SetActive (false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
			if (gameOver) {
				SceneManager.LoadScene ("Main");
			}
		}
	}

	public void BirdScored()
	{
		if(gameOver)
		{
			return;
		}
		score++;
		scoreText.text = "score:" + score.ToString();
	}
		
	public void BirdDied()
	{
		gameOverText.SetActive(true);
		gameOver = true;
	}
	public void GameWin()
	{
		gameWinText.SetActive (true);
		gameOver = true;
	}
}