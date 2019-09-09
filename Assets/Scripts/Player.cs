using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody rg;
	private Animator anim;
	public float speed;
	public Vector3 playerDirection;

	public Joystick moveJs;
	// Use this for initialization
	void Start ()
	{
		rg = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		playerDirection.x = moveHorizontal;
		playerDirection.z = moveVertical;

//		if (moveHorizontal > 0 || moveVertical > 0) {
//			anim.SetBool ("Run", true);
//		} else {
//			anim.SetBool ("Run", false);
//		}
		if (moveJs.direction != Vector3.zero) {
			anim.SetBool ("Run", true);
			playerDirection = moveJs.direction;
			transform.rotation = Quaternion.Euler (moveJs.direction);
		} else {
			anim.SetBool ("Run", false);
		}

		rg.AddForce (playerDirection.normalized * speed * Time.deltaTime);
	}

	void FixedUpdate ()
	{
		rg.velocity = new Vector3 (rg.velocity.x * 0.95f, rg.velocity.y, rg.velocity.z * 0.95f);
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Coin") {
			GameManager.instance.UpdateScore ();
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Obstacle") {
			GameManager.instance.GameOver ();
		}
	}
}
