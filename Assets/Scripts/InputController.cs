using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    const string GameManagerName = "GameManager";
    void Update()
    {
        KeyBoardCheck();
        MouseCheck();
    }
    private void KeyBoardCheck()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            GameObject.Find(GameManagerName).SendMessage("getDirection", GameNums.Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            GameObject.Find(GameManagerName).SendMessage("getDirection", GameNums.Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            GameObject.Find(GameManagerName).SendMessage("getDirection", GameNums.Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject.Find(GameManagerName).SendMessage("getDirection", GameNums.Direction.Right);
        }
    }
    private void MouseCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GestureRecognition.gestureRecognitionInstance.MoveStart(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GestureRecognition.gestureRecognitionInstance.MoveEnd(Input.mousePosition);
        }
    }
    private void TouchCheck()
    {
        if(Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            GestureRecognition.gestureRecognitionInstance.MoveStart(touch.position);
        }
        else if (touch.phase == TouchPhase.Ended){
            GestureRecognition.gestureRecognitionInstance.MoveEnd(touch.position);
        }
    }
}
