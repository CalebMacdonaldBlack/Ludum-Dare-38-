using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetForce : MonoBehaviour {
		public float pullRadius = 5000;
		public float pullForce = 10;

		public void FixedUpdate() {
		Debug.Log (pullRadius);
		foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, pullRadius)) {
			Debug.Log ("Finding Objects");
			// calculate direction from target to me
			Vector2 forceDirection = transform.position - collider.transform.position;

			Debug.Log ("Pulling Objects");
			// apply force on target towards me
			collider.GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
		}
	}
}
