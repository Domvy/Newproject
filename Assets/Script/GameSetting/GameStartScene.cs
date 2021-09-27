using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScene : MonoBehaviour
{
    public Text Round; // 라운드 UI
    public GameObject gameRound; // 패널 오브젝트
    public int RoundComplete = 0;
    public int roundCount = 1; // 라운드 숫자
    public Text money;

    public void Restart() // 게임 재시작
    {
        BasicSetting.instance.playerLife = 3; // 플레이어 목숨 초기화
        BasicSetting.instance.PlayerMoney = 100; // 플레이어 돈 초기화
        BasicSetting.instance.timer = 0.0f;
        BasicSetting.instance.playerdietime = 0.0f;
        SceneManager.LoadScene(0);
    }
    public void StartGame() // 게임시작
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame() // 게임종료
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
