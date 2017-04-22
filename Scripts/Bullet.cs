using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frasadfasdfasdfe
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("TRGGERED");
		if (collision.collider.tag == "Tile" || collision.collider.tag == "Bomb") {
			Destroy (collision.collider.gameObject);
			Destroy (this.gameObject);
		}
	}
}
