using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    //row和column是给后续升级关卡留的阵型参数
    public int row;
    public int column;
    //敌人阵型
    public Enemy Enemy;
    public Enemy[,] Grid;

    // Start is called before the first frame update
    void Start()
    {
        //在升级关卡时改成函数调参来调整阵型
        row = 5;
        column = 11;
        Grid = new Enemy[row, column];
        //向Grid里填充Enemy
        for (int x = 0; x < column; x++)
        {
            for (int y = 0; y < row; y++)
            {
                Grid[y, x] = Enemy;
            }
        }
        //Instantiate Enemy Grid
        for (int x = 0; x < column; x++)
        {
            for (int y = 0; y < row; y++)
            {
                Vector2 enemy_pos = new Vector2(x - 5, y);
                Grid[y, x].transform.position = enemy_pos;
                Grid[y, x] = Instantiate(Grid[y, x]);
            }
        }
    }
    //调用Down()移动整个阵型
    public void Grid_Down()
    {
        for (int x = 0; x < column; x++)
        {
            for (int y = 0; y < row; y++)
            {
                Grid[y, x].Down();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
