using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScene : MonoBehaviour
{
    public Text Round; // ���� UI
    public GameObject gameRound; // �г� ������Ʈ
    public int RoundComplete = 0;
    public int roundCount = 1; // ���� ����


    public void Restart() // ���� �����
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame() // ���ӽ���
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame() // ��������
    {
        Application.Quit();
    }

    private void Update()
    {
        if (RoundComplete == 1)
        {
            gameRound.SetActive(true);
        }
    }

    public void StartNextRound()
    {
        RoundComplete--;
        roundCount++;
        Round.text = "Round : " + roundCount;
        GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyCount = 10 * roundCount;
        StartCoroutine(GameObject.Find("Controller").GetComponent<EnemySpawn>().SpawnEnemy());
        gameRound.SetActive(false);
    }
}
