using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Bullet : MonoBehaviour {
	public static int score = 0;
	public AudioSource bugdie;
	public Canvas scoreClone;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frasadfasdfasdfe
	void Update () {
		if (transform.position.x > 300 || transform.position.x < -300 || transform.position.y > 300 || transform.position.y < -300) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Tile" || collision.collider.tag == "Bomb") {
			Destroy (collision.collider.gameObject);
			Destroy (this.gameObject);
			if (collision.collider.tag == "Bomb") {
				Instantiate (bugdie);
				score += 100;
				GameObject oldScore = GameObject.FindGameObjectsWithTag ("Score") [0];
				Destroy (oldScore);
				scoreClone.GetComponent<Text> ().text = "Score: " + score;
				Instantiate (scoreClone);
			}
		}
	}
}
