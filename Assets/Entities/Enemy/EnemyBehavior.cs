using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D col) {
		Destroy(col.gameObject);
		Destroy(gameObject);
	}
}
