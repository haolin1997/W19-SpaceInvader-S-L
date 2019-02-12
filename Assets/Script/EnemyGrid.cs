using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGrid : MonoBehaviour
{
    //row和column是给后续升级关卡留的阵型参数
    public int row;
    public int column;
    //敌人阵型
    public EnemyMovement Enemy;
    public EnemyMovement[,] Grid;
    //子弹
    public GameObject bullet_prefab;
    //子弹check
    public static bool bullet_out = false;

    // Start is called before the first frame update
    void Start()
    {
        //在升级关卡时改成函数调参来调整阵型
        row = 5;
        column = 11;
        Grid = new EnemyMovement[row, column];
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
                Grid[y, x].row = y;
                Grid[y, x].column = x;
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

    List<int> avaliable()
    {
        List<int> avaliability = new List<int>();
        for (int x = 0; x < column; x++)
        {
            for (int y = 0; y < row; y++)
            {
                if (Grid[y, x].isActiveAndEnabled)
                {
                    avaliability.Add(x);
                    break;
                }
            }
        }
        return avaliability;
    }


    //把老子的意大利炮拉过来！
    Transform Italy_cannon()
    {
        List<int> avalibility = avaliable();
        int rand = Random.Range(0, avalibility.Count);
        for (int i = 0; i < row; i++)
        {
            if (Grid[i, avalibility[rand]].isActiveAndEnabled)
            {
                return Grid[i, avalibility[rand]].transform;
            }
        }
        SceneManager.LoadScene("Winner");
        return null;
    }

    //开炮！开炮！开炮！！！
    void FIRE()
    {
        Vector2 center = Italy_cannon().position;
        float rand = Random.value;
        if (!bullet_out && rand < 0.5)
        {
            Instantiate(bullet_prefab, center, Quaternion.identity);
            bullet_out = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FIRE();
        if (EnemyMovement.destroy_count == 1100)
        {
            SceneManager.LoadScene("Winner");
        }
    }


}
