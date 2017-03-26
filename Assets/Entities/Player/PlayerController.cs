using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 0.55f;
	public GameObject laserPrefab;
	float xMin;
	float xMax;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 laserPostion = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
			GameObject laser = Instantiate(laserPrefab, laserPostion, Quaternion.identity) as GameObject;
			// Make this laser instance a child of the player component folder
			laser.transform.parent = transform;
		}
		
		// Restrict player position on the x axis
		float newX = Mathf.Clamp (this.transform.position.x, xMin, xMax);
		
		// Update the player position, ensuring they are within the gamespace
		this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
	}
}
