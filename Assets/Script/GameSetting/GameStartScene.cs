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
    public Text startCountDown;
    public GameObject UI; // ���� UI
    public GameObject SettingScreen;
    public int Difficulty = 1; // ���̵� ���� ����
    public Text killCountUI;

    public void Restart() // ���� �����
    {
        BasicSetting.instance.playerLife = 3; // �÷��̾� ��� �ʱ�ȭ
        BasicSetting.instance.PlayerMoney = 100; // �÷��̾� �� �ʱ�ȭ
        SceneManager.LoadScene(0);
    }
    public void StartGame() // ���ӽ���
    {
        SceneManager.LoadScene(2);
        BasicSetting.instance.timer = 0.0f;
        BasicSetting.instance.timerSet = 0;
    }

    public void QuitGame() // ��������
    {
        Application.Quit();
    }

    public void NormalButton()
    {
        UI.SetActive(true);
        SettingScreen.SetActive(false);
        BasicSetting.instance.timerSet = 1;
    }

    public void HardButton()
    {
        Difficulty = 2;
        UI.SetActive(true);
        SettingScreen.SetActive(false);
        BasicSetting.instance.timerSet = 1;
    }

    private void Update()
    {
        if (RoundComplete == 1)
        {
            gameRound.SetActive(true);
        }

        money.text = "Money : " + BasicSetting.instance.PlayerMoney; // �÷��̾� �� �ؽ�Ʈ ���

        // ���� �� ī��Ʈ�ٿ�
        startCountDown.text = $"{(int)10 - (int)BasicSetting.instance.timer}";
        if((int)10 - (int)BasicSetting.instance.timer == 0)
        {
            startCountDown.text = "START GAME!";            
        }
        else if((int)10 - (int)BasicSetting.instance.timer == -1)
        {
            startCountDown.gameObject.SetActive(false);
        }

        if(BasicSetting.instance.timer > 10) // 10�� ���Ŀ� ���� ���� ����
        {
            gameObject.GetComponent<EnemySpawn>().enabled = true;
        }
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
