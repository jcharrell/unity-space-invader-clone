using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 200f;
	public GameObject projectilePrefab;
	public float projectileSpeed = 1f;
	public float firingRate = 0.2f;
	
	public void Start() {
		InvokeRepeating("fire", 0.001f, firingRate);
	}
	
	public void OnTriggerEnter2D(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		
		// Determine if hit by a projectile
		if(projectile) {
			projectile.Hit();
			health -= projectile.GetDamage();
			if(health <= 0) {
				Destroy(gameObject);
			}
		}
	}
	
	public void fire() {
		Vector3 projectilePosition = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
		GameObject projectile = Instantiate (projectilePrefab, projectilePosition, Quaternion.identity) as GameObject;
		projectile.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
	}
}
