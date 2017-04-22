﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

	public float speed = 20;
	public float jumpSpeed = 5;
	public Transform Target;
	public GameObject bullet;
 
	// Use this for initialization
	void Start () {
		
	}
		
	void FixedUpdate () {

		if (Input.GetMouseButtonDown(0)) {
			var pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			pos = Camera.main.ScreenToWorldPoint(pos);

			var qu = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
			var go = Instantiate(bullet, transform.position, qu);
			go.GetComponent<Rigidbody2D>().AddForce(go.transform.up * 500);
			Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			moveLeft (speed);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveRight (speed);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D>().AddForce(transform.localPosition + transform.up * jumpSpeed);
		}

		Vector3 vectorToTarget = Target.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		transform.rotation = q;
	}

	private void moveRight(float speed) {
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}

	private void moveLeft(float speed) {
		transform.localPosition -= transform.right * speed * Time.deltaTime;
	}
} 
