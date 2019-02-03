using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public int speed = 5;
	private Rigidbody2D m_rigidbody;
	public GameObject bullet_prefeb;
	private bool bullet_out = false;


	// Use this for initialization
	void Start () {
		m_rigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		bullet ();
		
	}

	void Move()
	{
		float movementModifier = Input.GetAxis ("Horizontal");
		Vector2 current_velocity = m_rigidbody.velocity;
		m_rigidbody.velocity = new Vector2(movementModifier * speed, current_velocity.y);

	}

	void bullet()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector2 AboveMe = this.transform.position + Vector3.up;
			Instantiate(bullet_prefeb, AboveMe, Quaternion.identity);
			bullet_out = true;
		}

	}
}
