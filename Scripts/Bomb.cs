using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

<<<<<<< HEAD
	public Transform Target;
=======
	public GameObject Target;
>>>>>>> c36899b635abb5e15222bc6b499c2726b439c593

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
<<<<<<< HEAD
	void FixedUpdate () {
		Vector3 vectorToTarget = Target.position - transform.position;
=======
	void Update () {
		Vector3 vectorToTarget = Target.transform.position - transform.position;
>>>>>>> c36899b635abb5e15222bc6b499c2726b439c593
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		transform.rotation = q;
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
