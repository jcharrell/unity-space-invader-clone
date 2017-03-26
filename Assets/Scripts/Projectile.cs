using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 100f;

	public void Hit() {
		Destroy(gameObject);
	}
}
