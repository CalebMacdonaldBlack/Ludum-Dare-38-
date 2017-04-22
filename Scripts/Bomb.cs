using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("BOOM BITCHES");
		foreach (ContactPoint2D contact in collision.contacts)
		{
			foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, 4)) {

				if (collider.tag == "Tile") {
					Destroy (collider.gameObject);
				}
			}
			Destroy (this.gameObject);
		}
	}
}
