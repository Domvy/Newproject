using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScene : MonoBehaviour
{
    public void StartGame() // 게임시작
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() // 게임종료
    {
        Application.Quit();
    }
}
