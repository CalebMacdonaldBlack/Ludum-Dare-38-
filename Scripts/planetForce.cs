﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetForce : MonoBehaviour {
		public float pullRadius = 5000;
		public float pullForce = 10;

		public void FixedUpdate() {
		foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, pullRadius)) {
			
			if (collider.tag != "Tile") {
				Vector2 forceDirection = transform.position - collider.transform.position;
				collider.GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
			}
		}
	}
}
