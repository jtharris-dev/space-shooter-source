using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
	public float speed;

	void Start ()
	{
		Rigidbody rigidbody = this.GetComponent<Rigidbody> ();
		rigidbody.velocity = this.transform.forward * this.speed;
	}
}
