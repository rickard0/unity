using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues; 
	public int hazardCount;
	public float spawnWait; 
	public float startWait;
	public float waveWait;

	public GUIText scoreText; 
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;



	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ()); 
	}

	IEnumerator SpawnWaves() 
	{ 
		while (true) 
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				SpawnAsteroid ();
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}

	void Update()
	{
		if (restart)
		{
			if(Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}

	void SpawnAsteroid()
	{
		GameObject hazard = hazards [Random.Range (0, hazards.Length)]; 
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score; 
	}

	public void AddScore(int valueToAdd) 
	{
		score += valueToAdd;
		UpdateScore ();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true; 
	}
}
