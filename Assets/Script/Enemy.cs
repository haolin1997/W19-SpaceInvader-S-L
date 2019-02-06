using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static int direction = 1;
    //destroy_count是给计分器留的参数
    public static int destroy_count;
    //跳帧计时器
    private float timer = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
        if (collider.CompareTag("Bullet_player"))
        {
            Destroy(gameObject);
        }

        else if (collider.CompareTag("Wall"))
        {
            direction = -(direction);
            //把这个想想办法改成trigger之后只触发一次
            Camera.main.GetComponent<EnemyGrid>().Grid_Down();
        }
	}

	void Move ()
	{
        //每秒跳一次
        if (timer > 1)
        {
            Vector2 new_position = this.transform.position;
            new_position.x = this.transform.position.x + direction;
            this.transform.position = new_position;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        } 
	}

    //使单个enemy向下移动
    public void Down()
    {
        Vector2 new_position = this.transform.position;
        new_position.y = this.transform.position.y - 1;
        this.transform.position = new_position;
    }



}
