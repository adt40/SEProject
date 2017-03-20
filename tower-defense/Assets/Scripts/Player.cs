using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
		move ();
		turn ();
		
	}
	
	void move () {
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
		rigidbody2D.velocity = new Vector2 (movex * Speed, movey * Speed);
	}
	
	void turn () {
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
		lookPos = lookPos - transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
