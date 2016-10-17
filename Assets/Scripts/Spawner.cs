﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	private string enemyText;

	private string SortingLayerName = "Default";
	private int SortingOrder = 0;


	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}


	void Spawn ()
	{
		// Instantiate a random enemy.
	/*	int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
		*/
		//Debug.Log (FrameworkCore.currentContent);
		enemyText = FrameworkCore.currentContent.getTerm ();
		makeEnemy (enemyText);
		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}

	private void makeEnemy(string item){
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		GameObject temp = (GameObject)Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
		temp.GetComponentInChildren<TextMesh>().text = "" + item;
		temp.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
		temp.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
	}
}
