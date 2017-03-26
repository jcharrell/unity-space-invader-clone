using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 1f;
	public float padding = 5f;
	
	private bool movingRight = false;
	private float xMin;
	private float xMax;
	
	// Use this for initialization
	void Start () {	
		// Determine the left and right boundaries of the game space
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
		
		// Define the minimum and maximum x coordinates of the game space
		xMin = leftBoundary.x + padding;
		xMax = rightBoundary.x - padding;
			
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
		if(transform.position.x == xMin || transform.position.x == xMax) {
			movingRight = !movingRight;
		}
		
		if(!movingRight) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		// Restrict the x position to be between the calculated xMin and xMax coordinates
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), transform.position.y, transform.position.z);
	}
}
