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
    //自身位置
    public int row;
    public int column;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

	private void OnTriggerEnter2D(Collider2D collider)
	{
        if (collider.CompareTag("Bullet_player"))
        {
            gameObject.SetActive(false);
            if (row <= 1)
            {
                destroy_count += 1;
            }
            else if (row <= 3)
            {
                destroy_count += 2;
            }
            else
            {
                destroy_count += 4;
            }
        }

 
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            direction = -(direction);
            if (down_check)
            {
                Camera.main.GetComponent<EnemyGrid>().Grid_Down();
                down_check = false;
            }
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
