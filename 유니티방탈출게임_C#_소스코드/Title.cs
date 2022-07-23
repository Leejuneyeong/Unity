using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public void ClickStart()
    {
        Debug.Log("로딩");
        SceneManager.LoadScene("GameStage");
    }

    public void ClickHelp()
    {
        Debug.Log("게임 방법");
        SceneManager.LoadScene("Help");
    }

    public void ClickExit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

}
