using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetForce : MonoBehaviour {
		public float pullRadius = 5000;
		public float pullForce = 10;
		public bool isCircle;

		public void FixedUpdate() {
		var pos = transform.position;
		if (isCircle) {
			pos = GetComponent<CircleCollider2D> ().transform.position;
		}
		var all = Physics2D.OverlapCircleAll (pos, pullRadius);
		foreach (Collider2D collider in all) {
			Vector2 forceDirection = pos - collider.transform.position;
			switch (collider.tag) {
			case "Bomb":
				collider.GetComponent<Rigidbody2D> ().AddForce (forceDirection.normalized * pullForce / 40 * Time.fixedDeltaTime);
				break;

			case "Player":
				if(collider.GetContacts(all) <= 0){
					collider.GetComponent<Rigidbody2D> ().AddForce (forceDirection.normalized * pullForce * Time.fixedDeltaTime);
				}
				break;
			}
		}
	}
}
