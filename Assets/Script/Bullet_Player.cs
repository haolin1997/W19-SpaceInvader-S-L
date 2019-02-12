using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet_Player : MonoBehaviour
{

	public int speed = 5;
	private Rigidbody2D m_rigidbody;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Wall") || collider.CompareTag("Enemy"))
        {
            PlayerMovement.bullet_out = false;
            Destroy(gameObject);
        }
    }

	void Move ()
	{
		this.transform.Translate (new Vector2 (0, speed * Time.deltaTime));
	}
}
