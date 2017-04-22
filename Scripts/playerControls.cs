﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

	public float speed = 5;
	public float jumpSpeed = 5;
 
	// Use this for initialization
	void Start () {
		
	}
		
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Vector2 position = this.transform.position;
			position.x--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Vector2 position = this.transform.position;
			position.x++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector2 position = this.transform.position;
			position.y++;
			this.transform.position = position;
		}
		CameraAlign ();
	}

	void CameraAlign () {
		Quaternion newRotation = Quaternion.LookRotation (transform.position - transform.position);
		Quaternion newRot = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);
		transform.rotation = new Quaternion(0, 0, newRot.z, newRot.w);
	}
} 
