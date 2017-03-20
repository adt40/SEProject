using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public EnemyFactory EnemyFactory;
	
	private Enemy closestEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		findClosestEnemy ();
	}
	
	void findClosestEnemy () {
		float minDist = float.PositiveInfinity;
		foreach(Enemy enemy in EnemyFactory.Enemies) {
			float dist = Vector2.Distance(this.transform.position, enemy.transform.position);
			if (dist < minDist) {
				minDist = dist;
				closestEnemy = enemy;
			}
		}
	}
}
