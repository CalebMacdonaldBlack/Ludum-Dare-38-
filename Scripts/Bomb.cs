using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour {

	public GameObject Target;
	public AudioSource planetdie;
	public GameObject animation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
		void FixedUpdate () {
		Vector3 vectorToTarget = Target.transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		transform.rotation = q;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Instantiate (animation, transform.position, transform.rotation);
		foreach (ContactPoint2D contact in collision.contacts)
		{
			bool played = false;
			foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, 4)) {

				if (collider.tag == "World") {
					GameObject world = GameObject.FindGameObjectsWithTag ("World")[0];
					Instantiate (planetdie);
					world.transform.localScale -= new Vector3 (0.4f, 0.4f, 0.0f);
				}

				if (collider.tag == "Tile") {
					if (!played) {
						Instantiate (planetdie);
						played = true;
					}
					Destroy (collider.gameObject);
				}
			}
			Destroy (this.gameObject);
		}
	}
}
