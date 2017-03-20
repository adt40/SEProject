using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour {

	public Nexus Nexus;
	public Enemy[] EnemyPrefabs;
	
	public List<Enemy> Enemies;
	
	private float period;
	
	// Use this for initialization
	void Start () {
		period = 0;
	}
	
	// Update is called once per frame
	void Update () {
		int spawnDelay = 1;
		
		if (period > spawnDelay) {
			period = 0;
			createEnemy ();
			
		}
		period += Time.deltaTime;
	}
	
	//TODO spawn locations
	
	void createEnemy () {
		//Change the Vector3 values to change the spawn location
		Enemy enemy = (Enemy)Instantiate(EnemyPrefabs[0], new Vector3(3, 3), Quaternion.identity);
		enemy.Nexus = Nexus;
		Enemies.Add(enemy);
	}
}

