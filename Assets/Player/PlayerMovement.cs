﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public int speed = 5;
	private Rigidbody2D m_rigidbody;
	public GameObject bullet_prefeb;
	public bool bullet_out;


	// Use this for initialization
	void Start () {
		m_rigidbody = this.GetComponent<Rigidbody2D>();
		bullet_out = false;
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
		if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Mouse0))) && !(bullet_out))
		{
			Vector2 center = this.transform.position;
			Instantiate(bullet_prefeb, center, Quaternion.identity);
			bullet_out = true;
		}

	}
}
