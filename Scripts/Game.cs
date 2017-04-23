﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour {
	public GameObject tile;
	public GameObject bomb;
	public int radius;
	public float period = 0.0f;
	private List<Vector3> RandomSpawnLocations = new List<Vector3> ();
	public static int originalTileCount = 0;
	public static bool gameover = false;

	// Use this for initialization
	void Start () {
		int searchArea = radius * 3;
		for (int x = 0; x < searchArea; x++) {
			for (int y = 0; y < searchArea; y++) {
				if (((x - 0) * (x - 0) + (y - 0) * (y - 0)) <= radius * radius) {
					Instantiate(tile, new Vector3(x, y, 1), tile.transform.rotation);
					Instantiate(tile, new Vector3(x, y - y - y, 1), tile.transform.rotation);
					Instantiate(tile, new Vector3(x - x - x, y, 1), tile.transform.rotation);
					Instantiate(tile, new Vector3(x - x - x, y - y - y, 1), tile.transform.rotation);
				}
			}
		}
		this.GetComponentInChildren<Animator> ();
		radius = 100;
		searchArea = radius * 3;
		for (int x = 0; x < searchArea; x++) {
			for (int y = 0; y < searchArea; y++) {
				if (((x - 0) * (x - 0) + (y - 0) * (y - 0)) <= radius * radius) {
					var vec1 = new Vector3(x, y, 1);

					if(Vector3.Distance(vec1, new Vector3(0, 0, 1)) > 99){
						RandomSpawnLocations.Add (new Vector3(x, y, 1));
						RandomSpawnLocations.Add (new Vector3(x, y - y - y, 1));
						RandomSpawnLocations.Add (new Vector3(x - x - x, y, 1));
						RandomSpawnLocations.Add (new Vector3(x - x - x, y - y - y, 1));
					}
				}
			}
		}
		originalTileCount = GameObject.FindGameObjectsWithTag("Tile").Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (period > 1.5 - Bullet.score / 10000 && !gameover)
		{
			Instantiate (bomb, RandomSpawnLocations[Random.Range (0, RandomSpawnLocations.Count - 1)], bomb.transform.rotation);
			period = 0;
		}
		period += UnityEngine.Time.deltaTime;

		if (GameObject.FindGameObjectsWithTag ("Tile").Length < originalTileCount * 0.1 && !gameover) {
			Debug.Log ("GAME OVER");
			gameover = true;
			Destroy (GameObject.FindGameObjectsWithTag ("Music") [0]);
			GameObject.FindGameObjectsWithTag ("Tile").ToList ().ForEach (x => Destroy (x));
			GameObject.FindGameObjectsWithTag ("Bomb").ToList ().ForEach (x => Destroy (x));
			GameObject.FindGameObjectsWithTag ("Bullet").ToList ().ForEach (x => Destroy (x));
		}
	}
}
