using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 0.55f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	
	private float xMin;
	private float xMax;
	
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
		}
		
		// Fire projectile
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("fire", 0.001f, firingRate);
		}
		
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke();
		}
		
		// Restrict player position on the x axis
		float newX = Mathf.Clamp (this.transform.position.x, xMin, xMax);
		
		// Update the player position, ensuring they are within the gamespace
		this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
	}
	
	void fire() {
		Vector3 projectilePosition = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
		GameObject laser = Instantiate(projectile, projectilePosition, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
		
		// Make this projectile instance a child of the player component folder
		projectile.transform.parent = transform;
	}
}
