using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collision2D collision)
	{
		Debug.Log ("TRGGERED");
		if (collision.collider.tag == "Tile") {
			Destroy (collision.collider.gameObject);
		}
		Destroy (this.gameObject);
	}
}
