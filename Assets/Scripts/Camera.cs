﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

	public GameObject player;
	public Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		this.transform.position = offset + player.transform.position;
	}
}
