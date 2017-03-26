using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			Vector3 position = this.transform.position;
			position.x = position.x - speed;
			this.transform.position = position;
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			Vector3 position = this.transform.position;
			position.x = position.x + speed;
			this.transform.position = position;
		}
	}
}
