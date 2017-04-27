using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Nexus Nexus;
	private Vector2 vector;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate () {
		move ();
		turn ();
	}
	
	void move () {
		//Need to do real A* here eventually
		float moveX = Nexus.transform.position.x - this.transform.position.x;
		float moveY = Nexus.transform.position.y - this.transform.position.y;
		vector = new Vector2 (moveX, moveY).normalized;
		rigidbody2D.velocity = vector;
	}
	
	void turn () {
		float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
