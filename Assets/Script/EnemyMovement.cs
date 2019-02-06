using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public int speed = 3;
	private int direction = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Bullet_player")) 
		{
			Debug.Log ("hit by player");
			//GameObject.Find ("Player").GetComponent<PlayerMovement> ().bullet_out = false;

			Destroy (gameObject);
		}

		if (collider.CompareTag ("Wall")) 
		{
			direction = direction * -1;
			Debug.Log (direction);
		}
	}


	void Move ()
	{
		this.transform.Translate (new Vector2 (speed * Time.deltaTime * direction, 0));
	}
}
