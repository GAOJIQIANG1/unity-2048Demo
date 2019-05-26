using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNums
{
    public int[][] gameNums = new int[4][]
    {
        new int[]{0,0,0,0 },
        new int[]{0,0,0,0 },
        new int[]{0,0,0,0 },
        new int[]{0,0,0,0 }
    };

    public GameNums()
    {
        RandomCreateNum(ReturnZeroDoubleNums(gameNums));
        RandomCreateNum(ReturnZeroDoubleNums(gameNums));
    }
    public long score = 0;
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public bool move(Direction direction)
    {
        bool flag = false;
        switch (direction) {
            case Direction.Up:
                flag = moveUp(); break;
            case Direction.Down:
                flag = moveDown(); break;
            case Direction.Right:
                flag =  moveRight(); break;
            case Direction.Left:
                flag = moveLeft(); break;
        };
        if (flag)
        RandomCreateNum(ReturnZeroDoubleNums(gameNums));
        if (ReturnZeroDoubleNums(gameNums).Count == 0)
        {
            if (checkLose())
                return false ;
        }
        return true;
    }

    private bool checkLose()
    {//检查是否还有可移动的数组元素
        if(gameNums[1][1] ==gameNums[1][2] || gameNums[1][1] == gameNums[1][0]
            || gameNums[1][1] == gameNums[2][1]||gameNums[1][1] == gameNums[0][1])
        {
            return false;
        }
        if(gameNums[2][2] == gameNums[1][2] || gameNums[2][2] == gameNums[3][2] 
            || gameNums[2][2] == gameNums[2][3] || gameNums[2][2] == gameNums[2][1])
        {
            return false;
        }
        if (gameNums[0][0] == gameNums[0][1] || gameNums[0][0] == gameNums[1][0]
            || gameNums[0][3] == gameNums[0][2] || gameNums[0][3] == gameNums[1][3]
            || gameNums[3][0] == gameNums[3][1] || gameNums[3][0] == gameNums[2][0]
            || gameNums[3][3] == gameNums[3][2] || gameNums[3][3] == gameNums[2][3])
            return false;
        return true;
    }
    private void RandomCreateNum(List<Vector2Int> EmptyNums)
    {
       if (EmptyNums.Count != 0 )
        {
            int serial = Random.Range(0, EmptyNums.Count);
            int num = 2 * Random.Range(0, 2) + 2;
            int i = EmptyNums[serial].x;
            int j = EmptyNums[serial].y;
            gameNums[i][j] = num;
        }
    }
    private static List<Vector2Int> ReturnZeroDoubleNums(int[][] Nums)
    {
        List<Vector2Int> vector2Ints = new List<Vector2Int>();
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                if (Nums[i][j] == 0)
                {
                    vector2Ints.Add(new Vector2Int(i, j));
                }
            }
        return vector2Ints;
    }
    private static bool CheckZeroNums(int[] nums)
    {
        return  nums[0] == 0 && nums[1] == 0&& nums[2] == 0 && nums[3] == 0;
    }

    private bool moveRight()
    {
        bool flag = false;
        for (int i = 0; i <= 3; i++)
        {
            if (CheckZeroNums(gameNums[i]))
            {
                continue;
            }
            else
            {
                for(int j = 3; j > 0; j--)
                {
                    if(gameNums[i][j] == 0 &&gameNums[i][j - 1] != 0)
                    {
                        gameNums[i][j] = gameNums[i][j - 1];
                        gameNums[i][j - 1] = 0;
                        j = 4;
                        flag = true;
                    }
                }
                for (int j = 3; gameNums[i][j] != 0 && j > 0; j--)
                {
                    if (gameNums[i][j] == gameNums[i][j - 1] && gameNums[i][j] != 0)
                    {
                        sumScore(ref gameNums[i][j]);
                        flag = true;
                        for (int k = j - 1; k > 0; k--)
                        {
                            gameNums[i][k] = gameNums[i][k - 1];
                        }
                        gameNums[i][0] = 0;
                    }
                }
            }
        }
        return flag;
    }

    private bool moveLeft()
    {
        bool flag = false;
        for (int i = 0; i <= 3; i++)
        {
            if (CheckZeroNums(gameNums[i]))
            {
                continue;
            }
            else
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameNums[i][j] == 0 && gameNums[i][j + 1] != 0)
                    {
                        gameNums[i][j] = gameNums[i][j + 1];
                        gameNums[i][j + 1] = 0;
                        j = -1;
                        flag = true;
                    }
                }
                for (int j = 0; gameNums[i][j] != 0 && j < 3; j++)
                {
                    if (gameNums[i][j] == gameNums[i][j + 1] && gameNums[i][j] != 0)
                    {
                        sumScore(ref gameNums[i][j]);
                        flag = true;
                        for (int k = j + 1; k < 3; k++)
                        {
                            gameNums[i][k] = gameNums[i][k + 1];
                        }
                        gameNums[i][3] = 0;
                    }
                }
            }
        }
        return flag;
    }

    private bool moveUp()
    {
        bool flag = false;
        for (int j = 0; j < 4; j++)
        {
            if (CheckZeroNums(new int[] { gameNums[0][j], gameNums[1][j], gameNums[2][j], gameNums[3][j] }))
            {
                continue;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (gameNums[i][j] == 0 && gameNums[i + 1][j] != 0)
                    {
                        gameNums[i][j] = gameNums[i + 1][j];
                        gameNums[i + 1][j] = 0;
                        i = -1;
                        flag = true;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (gameNums[i][j] == gameNums[i + 1][j] && gameNums[i][j] != 0)
                    {
                        sumScore(ref gameNums[i][j]);
                        flag = true;
                        for (int k = i + 1; k < 3; k++)
                        {
                            gameNums[k][j] = gameNums[k + 1][j];
                        }
                        gameNums[3][j] = 0;
                    }
                }
            }
        }
        return flag;
    }
    private bool moveDown()
    {
        bool flag = false;
        for (int j = 0; j < 4; j++)
        {
            if (CheckZeroNums(new int[] { gameNums[0][j], gameNums[1][j], gameNums[2][j], gameNums[3][j] }))
            {
                continue;
            }
            else
            {
                for (int i = 3; i > 0; i--)
                {
                    if (gameNums[i][j] == 0 && gameNums[i - 1][j] != 0)
                    {
                        gameNums[i][j] = gameNums[i - 1][j];
                        gameNums[i - 1][j] = 0;
                        i = 4;
                        flag = true;
                    }
                }
                for (int i = 3; i > 0; i--)
                {
                    if (gameNums[i][j] == gameNums[i - 1][j] &&gameNums[i][j] != 0)
                    {
                        sumScore(ref gameNums[i][j]);
                        flag = true;
                        for (int k = i - 1; k > 0; k--)
                        {
                            gameNums[k][j] = gameNums[k - 1][j];
                        }
                        gameNums[0][j] = 0;
                    }
                }
            }
        }
        return flag;
    }
    private void sumScore(ref int gameNum)
    {
        gameNum *= 2;
        score += gameNum;
    }
}