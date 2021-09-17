using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScene : MonoBehaviour
{
    public void Restart() // ���� �����
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame() // ���ӽ���
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() // ��������
    {
        Application.Quit();
    }
}
