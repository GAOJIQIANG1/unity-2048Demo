using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map
{
    GameObject gameMap;
    GameObject gameNum;
    GameObject scoreText;
    GameObject Num;
    const int starti = -150;
    const int startj = 150;
    static readonly Dictionary<int, int> fontDictionary = new Dictionary<int, int>
    {
        { 1,40},{2,40},{3,40},{4,30},{5,25}
    };
    static readonly Map _map = new Map();
    public static Map MapInstance
    {
        get
        {
            return _map;
        }
    }

    public void initMap()
    {
        gameMap = GameObject.Find("Map");
        gameNum = GameObject.Find("Num");
        scoreText = GameObject.Find("ScoreText");
        Num = (GameObject)Resources.Load("Num");
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                GameObject newNum = UnityEngine.GameObject.Instantiate(Num, gameMap.transform);
                newNum.transform.localPosition = InstantiatePosition(i, j);
                newNum.transform.GetComponentInChildren<Text>().text = "";
            }
    }
    public void drawMap(GameNums gameNums)
    {
        foreach (Transform t in GameObject.Find("Num").transform)
        {
            UnityEngine.GameObject.Destroy(t.gameObject);
        }
        for(int i = 0; i < 4; i++) 
            for(int j = 0; j < 4; j++)
            {
                if(gameNums.gameNums[i][j] != 0)
                {
                    GameObject newNum = UnityEngine.GameObject.Instantiate(Num, gameNum.transform);
                    newNum.transform.localPosition = InstantiatePosition(j, i);
                    string s = gameNums.gameNums[i][j].ToString();
                    newNum.transform.GetComponentInChildren<Text>().text = s;
                    newNum.transform.GetComponentInChildren<Text>().fontSize = fontDictionary[s.Length];
                }
            }
        scoreText.GetComponent<Text>().text = "分数：" + gameNums.score;

    }
    private Vector2 InstantiatePosition(int i,int j)
    {
        return new Vector2(starti + 100 * i, startj - 100 * j);
    }
}
