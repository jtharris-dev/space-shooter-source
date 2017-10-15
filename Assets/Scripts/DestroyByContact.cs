using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject exposion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject) 
		{
			this.gameController = gameControllerObject.GetComponent<GameController> ();
		} 
		else 
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Boundary")) 
		{
			return;
		} 
		else if (other.CompareTag("Player")) 
		{
			Instantiate(this.playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		Instantiate(this.exposion, this.transform.position, this.transform.rotation);
		this.gameController.AddScore(this.scoreValue);

		Destroy(other.gameObject);
		Destroy(this.gameObject);
	}
}
