﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                         
public class CoinSpawn : MonoBehaviour
{

	public GameObject coin;

	float spawnRate = 3f;
	float nextSpawn = 0f;

	// Update is called once per frame
	void Update ()
	{
		SpawnCoins ();
	}

	void SpawnCoins ()
	{
//		Vector3 fromDirection = new Vector3 (90f, 0f, 0f);
//		Vector3 toDirection = new Vector3 (90f, 3f, 0f);

		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			Vector3 spawnPosition = new Vector3 (Random.Range (-10f, 11f), 0.5f, Random.Range (-13f, 9f));
			Instantiate (coin, spawnPosition, Quaternion.identity);
		}
	}
}
