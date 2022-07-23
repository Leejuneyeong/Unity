using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public void ClickExit()
    {
        Debug.Log("메인화면으로");
        SceneManager.LoadScene("GameTItle");
    }

}
