using UnityEngine;
using System.Collections;

//using System;

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
		int enemyIndex = 0;
		if (item.Equals (" ")) {
			enemyIndex = 2;
		} else {
			enemyIndex = Random.Range (0, 1);
		}

		// Instantiating the germ
		GameObject temp = (GameObject)Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

		//temp.GetComponentInChildren<TextMesh> ().text = "" + item;
		temp.transform.Find ("germText").GetComponentInChildren<TextMesh> ().text = "" + item;
		if (transform.position.x > 0) {
			temp.transform.Find ("germImage").GetComponent<SpriteRenderer> ().flipX = true;
			temp.transform.Find ("germText").transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		temp.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
		temp.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
	}
}
