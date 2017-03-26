﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	
	// Use this for initialization
	void Start () {		
		// Loop through each child items (positions) within the EnemyFormation collection
		foreach(Transform child in transform) {
			// Spawn enemies on each position
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
