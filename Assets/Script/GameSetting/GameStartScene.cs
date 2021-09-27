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
    public Text money;

    public void Restart() // ���� �����
    {
        BasicSetting.instance.playerLife = 3; // �÷��̾� ��� �ʱ�ȭ
        BasicSetting.instance.PlayerMoney = 100; // �÷��̾� �� �ʱ�ȭ
        BasicSetting.instance.timer = 0.0f;
        BasicSetting.instance.playerdietime = 0.0f;
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

        money.text = "Money : " + BasicSetting.instance.PlayerMoney;
    }

    public void StartNextRound()
    {
        RoundComplete = 0;
        roundCount++;
        Round.text = "Round : " + roundCount;
        GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyCount = 10 * roundCount;
        StartCoroutine(GameObject.Find("Controller").GetComponent<EnemySpawn>().SpawnEnemy());
        gameRound.SetActive(false);
    }
}
