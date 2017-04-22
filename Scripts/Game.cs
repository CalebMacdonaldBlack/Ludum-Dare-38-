using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	public GameObject tile;
	public int radius;

	// Use this for initialization
	void Start () {
		Debug.Log ("GAME STARTED BITCHES");

		int searchArea = radius * 3;
		for (int x = 0; x < searchArea; x++) {
			for (int y = 0; y < searchArea; y++) {
				if (((x - 0) * (x - 0) + (y - 0) * (y - 0)) <= radius * radius) {
					var vec1 = new Vector3(x, y, 1);
					var vec2 = new Vector3 (x, y - y - y, 1);
					var vec3 = new Vector3 (x - x - x, y, 1);
					var vec4 = new Vector3 (x - x - x, y - y - y, 1);

					Instantiate(tile, new Vector3(x, y, 1), tile.transform.rotation);
					Instantiate(tile, new Vector3(x, y - y - y, 1), tile.transform.rotation);
					Instantiate(tile, new Vector3(x - x - x, y, 1), tile.transform.rotation);
					Instantiate(tile, new Vector3(x - x - x, y - y - y, 1), tile.transform.rotation);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
