using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D collider) {
		Projectile projectileHit = collider.gameObject.GetComponent<Projectile>();
		
		// Determine if hit by a projectile
		if(projectileHit) {			
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}

	}
}
