using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour {

	public Nexus Nexus;
	public Enemy[] EnemyPrefabs;
	
	public List<Enemy> Enemies;
	
	private float period;
	private Transform northSpawn;
	private Transform northEastSpawn;
	private Transform eastSpawn;
	private Transform southEastSpawn;
	private Transform southSpawn;
	private Transform southWestSpawn;
	private Transform westSpawn;
	private Transform northWestSpawn;
	
	// Use this for initialization
	void Start () {
		period = 0;
		findSpawnNodes ();
	}
	
	// Update is called once per frame
	void Update () {
		int spawnDelay = 4;
		
		if (period > spawnDelay) {
			period = 0;
			createEnemy ();
			
		}
		period += Time.deltaTime;
	}
	
	void createEnemy () {
		//Right now uses random spawning. Can be modified later for predefined waves
		//Also we need to randomize areas between nodes where enemies can spawn, because this looks silly
		int spawnLoc = Random.Range(0, 8);
		Debug.Log (spawnLoc);
		Enemy enemy = (Enemy)Instantiate(EnemyPrefabs[0], intToSpawnNode (spawnLoc).position, Quaternion.identity);
		enemy.Nexus = Nexus;
		Enemies.Add(enemy);
	}
	
	void findSpawnNodes () {
		GameObject[] spawnNodeGameObjects = GameObject.FindGameObjectsWithTag("EnemySpawnNode");
		
		for (int i = 0; i < spawnNodeGameObjects.Length; i++) {
			switch (spawnNodeGameObjects[i].name) {
			case "North":
				northSpawn = spawnNodeGameObjects[i].transform;
				break;
			case "NorthEast":
				northEastSpawn = spawnNodeGameObjects[i].transform;
				break;
			case "East":
				eastSpawn = spawnNodeGameObjects[i].transform;
				break;
			case "SouthEast":
				southEastSpawn = spawnNodeGameObjects[i].transform;
				break;
			case "South":
				southSpawn = spawnNodeGameObjects[i].transform;
				break;
			case "SouthWest":
				southWestSpawn = spawnNodeGameObjects[i].transform;
				break;
			case "West":
				westSpawn = spawnNodeGameObjects[i].transform;
				break;
			case "NorthWest":
				northWestSpawn = spawnNodeGameObjects[i].transform;
				break;
			default:
				break;
			}
		}
	}
	
	Transform intToSpawnNode (int val) {
		switch (val) {
			case 0:
				return northSpawn;
			break;
			case 1:
				return northEastSpawn;
			break;
			case 2:
				return eastSpawn;
			break;
			case 3:
				return southEastSpawn;
			break;
			case 4:
				return southSpawn;
			break;
			case 5:
				return southWestSpawn;
			break;
			case 6:
				return westSpawn;
			break;
			case 7:
				return northWestSpawn;
			break;
			default:
				return northSpawn;
		}
		
		
	}
}

