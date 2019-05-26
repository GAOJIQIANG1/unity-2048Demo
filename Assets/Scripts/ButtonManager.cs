using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void OnEndButtonClicked()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        Debug.Log("编辑状态游戏退出");

#else

            Application.Quit();

            Debug.Log ("游戏退出");

#endif
    }
}
