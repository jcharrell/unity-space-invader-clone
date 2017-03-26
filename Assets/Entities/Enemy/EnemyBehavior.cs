using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 200f;
	
	public void OnTriggerEnter2D(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		
		// Determine if hit by a projectile
		if(projectile) {
			projectile.Hit();
			health = health - projectile.GetDamage();
			if(health <= 0) {
				Destroy(gameObject);
			}
		}

	}
}
