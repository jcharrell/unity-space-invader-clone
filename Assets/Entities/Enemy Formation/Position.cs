using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	void OnDrawGizmos() {
		// Gizmo representing enemy positions within the editor
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
