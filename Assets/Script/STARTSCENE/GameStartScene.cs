using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScene : MonoBehaviour
{
    public void StartGame() // ���ӽ���
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() // ��������
    {
        Application.Quit();
    }
}
