using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GestureRecognition
{
    static readonly GestureRecognition _gestureRecognition = new GestureRecognition();
    public static GestureRecognition gestureRecognitionInstance
    {
        get { return _gestureRecognition; }
    }
    public class EventArgsGestureRecognition : EventArgs
    {
        public GameNums.Direction direction { get; set; }
    }
    public event EventHandler<EventArgsGestureRecognition> move;
    public Vector2 MoveStartPosition;
    public float MoveTime = 0;
    public void MoveStart(Vector2 pst)
    {
        MoveStartPosition = pst;
        MoveTime = Time.time;
    }
    public void MoveEnd(Vector2 MoveEndPosition)
    {
        if (Time.time - MoveTime > 0.5f)
        {//时间过长，视为无效操作。
            return;
        }
        else
        {
            Vector2 moveVector = MoveEndPosition - MoveStartPosition;
            if(moveVector.magnitude < 10)
            {//距离过短，视为无效操作
                return;
            }
            moveVector.Normalize();
            float degree = Mathf.Rad2Deg * Mathf.Atan2(moveVector.y, moveVector.x);
            Debug.Log(degree);
            if (degree > 45 && degree <= 135)
            {
                move(this, new EventArgsGestureRecognition() { direction = GameNums.Direction.Up });
            }
            if (degree > 135 || degree <= -135)
            {
                move(this, new EventArgsGestureRecognition() { direction = GameNums.Direction.Left });
            }
            if (degree <= 45 && degree > -45)
            {
                move(this, new EventArgsGestureRecognition() { direction = GameNums.Direction.Right });
            }
            if (degree >= -135 && degree < -45)
            {
                move(this, new EventArgsGestureRecognition() { direction = GameNums.Direction.Down });
            }
        }
    }

}
