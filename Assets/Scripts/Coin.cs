using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		transform.Rotate (90f, 0f, 0f, Space.World);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (0f, 0f, 3f, Space.Self);	
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerStay (Collider collider)
	{
		if (collider.gameObject.tag == "Obstacle") {
			Destroy (this.gameObject);
		}
	}
}
