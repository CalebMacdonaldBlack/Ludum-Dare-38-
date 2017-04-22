using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Bullet : MonoBehaviour {
	public static int score = 0;
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
			if (collision.collider.tag == "Bomb") {
				score += 100;
			}
		}
	}

	void OnGUI(){
		GUI.Label (new Rect(20,20,100,100), "Score: " + score);
		//Alternatively use
	}
}
