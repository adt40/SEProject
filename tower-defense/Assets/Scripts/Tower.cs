using UnityEngine;
using System.Collections;

/*
	To make a new tower type (ie a tower with a red gem), extend this class.
	To do this in C#, the class definition would be like: public class RedTower : Tower
*/


public class Tower : MonoBehaviour {

	public EnemyFactory EnemyFactory;
	public float AggroRange;
	
	private Enemy closestEnemy;
	private Vector2 vector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		findClosestEnemy ();
		turn ();
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
	
	void turn () {
		float moveX = closestEnemy.transform.position.x - this.transform.position.x;
		float moveY = closestEnemy.transform.position.y - this.transform.position.y;
		vector = new Vector2 (moveX, moveY);
		if (vector.magnitude < AggroRange) {
			float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
