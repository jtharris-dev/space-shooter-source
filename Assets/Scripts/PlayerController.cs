using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			this.GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Rigidbody rigidBody = this.GetComponent<Rigidbody> ();
		rigidBody.velocity = movement * this.speed;

		rigidBody.position = new Vector3 
		(
			Mathf.Clamp (rigidBody.position.x, this.boundary.xMin, this.boundary.xMax),
			0.0f,
			Mathf.Clamp (rigidBody.position.z, this.boundary.yMin, this.boundary.yMax)
		);

		rigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidBody.velocity.x * -this.tilt);
	}
}
