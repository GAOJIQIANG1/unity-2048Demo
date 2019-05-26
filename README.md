# 一个基于unity的2048Demo
## 2048游戏基本规则
每次可以选择上下左右其中一个方向去滑动，每滑动一次，所有的数字方块都会往滑动的方向靠拢外，系统也会在空白的地方乱数出现一个数字方块，相同数字的方块在靠拢、相撞时会相加。
## 本demo操作介绍
### PC版本（点击[这里](https://pan.baidu.com/s/1qolwKTyvqlKAqV75aAdYpQ)进行下载）提取码：cbzn
键盘上下左右或者wsad，或者鼠标拖拽对应方向，控制方块的移动。
### 安卓版本(待添加)
滑动即可控制方块移动。
## 工程介绍
### [GameManager类](https://github.com/GAOJIQIANG1/unity-2048Demo/blob/master/Assets/Scripts/GameManager.cs)
游戏的入口类以及整体控制类。  
初始挂载在游戏中的GameManager物体上。  
入口方法：OnMove()方法 作为一个订阅者方法，接受InputController中的事件传递信息。  
### [GameNums类](https://github.com/GAOJIQIANG1/unity-2048Demo/blob/master/Assets/Scripts/GameNums.cs)
包含一个二维数组int[][] GameNums。  
以及对于这个数组的各种按照游戏规则的如向上移动，向下移动，判断游戏胜利等各种方法。  
枚举 GameNums.Direction控制方向。  
入口方法： public bool move(Direction direction)。  
### [Map类](https://github.com/GAOJIQIANG1/unity-2048Demo/blob/master/Assets/Scripts/Map.cs)
实例化的绘制棋盘方法类。  
入口方法：initMap()绘制初始棋盘。  
入口方法：drawMap(int[][] GameNums)按目前GameNums传入的数组绘制棋盘。  
### [InputController类](https://github.com/GAOJIQIANG1/unity-2048Demo/blob/master/Assets/Scripts/InputController.cs)
接收设备输入，并将输入传递给手势识别类。  
入口方法：UpDate()。  
### [GestureRecognition类](https://github.com/GAOJIQIANG1/unity-2048Demo/blob/master/Assets/Scripts/GestureRecognition.cs)
依赖于InputController类。  
识别输入，并转换为方向，传递回GameManager。  
自定义事件：EventArgsGestureRecognition Move{ GameNums.Direction direction} 被GameManager中的OnMove方法订阅。  
