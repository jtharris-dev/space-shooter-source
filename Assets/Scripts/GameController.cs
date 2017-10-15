using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		this.gameOver = false;
		this.restart = false;
		this.restartText.text = "";
		this.gameOverText.text = "";

		this.score = 0;
		this.UpdateScore();
		StartCoroutine(this.SpawnWaves());
	}

	void Update ()
	{
		if (this.restart) 
		{
			if (Input.GetKeyDown(KeyCode.R)) 
			{
//				Application.LoadLevel(Application.loadedLevel);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(this.startWait);

		while (true) 
		{
			for (int i = 0; i < this.hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-this.spawnValues.x, this.spawnValues.x), this.spawnValues.y, this.spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (this.hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (this.spawnWait);
			}
			yield return new WaitForSeconds(this.waveWait);

			if (this.gameOver) 
			{
				this.restartText.text = "Press 'R' for Restart";
				this.restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		this.score += newScoreValue;
		this.UpdateScore();
	}

	void UpdateScore ()
	{
		this.scoreText.text = "Score: " + this.score.ToString();
	}

	public void GameOver ()
	{
		this.gameOverText.text = "Game Over";
		this.gameOver = true;
	}
}
