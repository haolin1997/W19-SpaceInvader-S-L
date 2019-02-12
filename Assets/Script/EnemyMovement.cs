using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private static int direction = 1;
    //destroy_count是给计分器留的参数
    public static int destroy_count = 0;
    //跳帧计时器
    private float timer = 0;
    //向下移动check
    private static bool down_check = true;


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
        if (collider.CompareTag("Wall"))
        {
            direction = -(direction);
            if (down_check)
            {
                Camera.main.GetComponent<EnemyGrid>().Grid_Down();
                down_check = false;
            }
        }
        if (collider.CompareTag("Bullet_player"))
        {
            gameObject.SetActive(false);
            destroy_count += 1;
        }

 
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            {
            down_check = true;
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
