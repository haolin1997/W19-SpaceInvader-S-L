using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Bullet_player")) 
		{
			Debug.Log ("hit by player");
			//GameObject.Find ("Player").GetComponent<PlayerMovement> ().bullet_out = false;

			Destroy (gameObject);
		}
	}
}
