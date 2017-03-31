using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 200f;
	public GameObject projectilePrefab;
	public float projectileSpeed = 1f;
	public float firingRate = 0.5f;
	public int pointValue = 20;
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update() {
		float probability = Time.deltaTime * firingRate;
		
		if(probability > Random.value) {
			fire ();
		}
	}
	
	public void OnTriggerEnter2D(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		
		// Determine if hit by a projectile
		if(projectile) {
			projectile.Hit();
			health -= projectile.GetDamage();
			if(health <= 0) {
				die();
			}
		}
	}
	
	private void fire() {
		//Vector3 projectilePosition = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
		GameObject projectile = Instantiate (projectilePrefab, transform.position, Quaternion.identity) as GameObject;
		projectile.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	private void die() {
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		scoreKeeper.addPoints(pointValue);
	}
}
