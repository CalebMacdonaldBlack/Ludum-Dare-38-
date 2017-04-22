﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

	public float speed = 20;
	public float jumpSpeed = 5;
	public Transform Target;
	public Sprite standing;
	public Sprite leftSprite;
	public Sprite rightSprite;

	public SpriteRenderer spriteRenderer;
 
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = standing;
	}
		
	void FixedUpdate () {

		if (Input.GetKey (KeyCode.LeftArrow)) {
			moveLeft (speed);
			ChangeSprite (leftSprite);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveRight (speed);
			ChangeSprite (rightSprite);
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			moveLeft (speed);
			ChangeSprite (standing);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			moveRight (speed);
			ChangeSprite (standing);
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

	private void ChangeSprite(Sprite spriteChange){
		spriteRenderer.sprite = spriteChange;
	}
} 
