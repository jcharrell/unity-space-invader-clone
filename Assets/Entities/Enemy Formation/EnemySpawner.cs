using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 1f;
	public float padding = 5f;
	string direction = "left";
	float xMin;
	float xMax;
	
	// Use this for initialization
	void Start () {	
		// Determine the left and right boundaries of the game space
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		// Define the minimum and maximum x coordinates of the game space
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
			
		// Loop through each child items (positions) within the EnemyFormation collection
		foreach(Transform child in transform) {
			// Spawn enemies on each position
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if(direction == "left") {
			if(transform.position.x > xMin) {
				transform.position += Vector3.left * speed * Time.deltaTime;
			} else {
				direction = "right";
			}
		} else if(direction == "right") {
			if(transform.position.x < xMax) {
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else {
				direction = "left";
			}		
		}
		
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), transform.position.y, transform.position.z);
	}
}
