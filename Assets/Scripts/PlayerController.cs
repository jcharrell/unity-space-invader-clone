using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	
	float xMin = -5.0f;
	float xMax = 5.0f;
	
	// Use this for initialization
	void Start () {
	
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
