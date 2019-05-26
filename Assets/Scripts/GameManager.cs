using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject LoseUI;
    GameNums gameNums;
    void Awake()
    {
        GestureRecognition.gestureRecognitionInstance.move += OnMove;
        gameObject.AddComponent<InputController>();
        gameNums = new GameNums();
        Map.MapInstance.initMap();
        Map.MapInstance.drawMap(gameNums);
    }
    public void getDirection(GameNums.Direction direction)
    {
        if (gameNums.move(direction))
            Map.MapInstance.drawMap(gameNums);
        else
        {
            gameEnd();
        }
    }

    private void gameEnd()
    {
        LoseUI.SetActive(true);
        gameObject.GetComponent<InputController>().enabled = false ;
    }
    void OnMove(object sender,GestureRecognition.EventArgsGestureRecognition e)
    {
        Debug.Log(e.direction);
        getDirection(e.direction);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
