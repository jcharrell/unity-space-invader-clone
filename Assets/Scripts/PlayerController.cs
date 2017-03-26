﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	
	float xMin;
	float xMax;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		xMin = leftMost.x + 0.55f;
		xMax = rightMost.x - 0.55f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		// Restrict player position on the x axis
		float newX = Mathf.Clamp (this.transform.position.x, xMin, xMax);
		
		// Update the player position, ensuring they are within the gamespace
		this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
	}
}
