﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControls : MonoBehaviour {

	public float speed = 20;
	public float jumpSpeed = 5;
	public Transform Target;
	public GameObject bullet;
	public float bulletSpeed;
	public Sprite standing;
	public Sprite leftSprite;
	public Sprite rightSprite;
	float lastStep, timeBetweenSteps = 0.18f;
	float lastStepJump, timeBetweenStepsJump = 1f;
	public AudioSource laser;
 
	public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = standing;
	}
		
	void FixedUpdate () {
		if (Input.GetMouseButton(0)) {
			if(Time.time - lastStep > timeBetweenSteps){
				lastStep = Time.time;

				var pos = Input.mousePosition;
				pos.z = transform.position.z - Camera.main.transform.position.z;
				pos = Camera.main.ScreenToWorldPoint(pos);
				Instantiate (laser);
				var qu = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
				var go = Instantiate(bullet, transform.position, qu);
				go.GetComponent<Rigidbody2D>().AddForce(go.transform.up * bulletSpeed);
				Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
		}

		if (Input.GetKey (KeyCode.A)) {
			moveLeft (speed);
			ChangeSprite (leftSprite);
		}
		if (Input.GetKey (KeyCode.D)) {
			moveRight (speed);
			ChangeSprite (rightSprite);
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			ChangeSprite (standing);
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			ChangeSprite (standing);
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			if (Time.time - lastStepJump > timeBetweenStepsJump) {
				lastStepJump = Time.time;
				GetComponent<Rigidbody2D> ().AddForce (transform.localPosition + transform.up * jumpSpeed);
			}
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