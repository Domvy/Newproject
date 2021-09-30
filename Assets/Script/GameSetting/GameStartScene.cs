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
    public Text startCountDown;
    public GameObject UI; // 게임 UI
    public GameObject SettingScreen;
    public int Difficulty = 1; // 난이도 설정 숫자
    public Text killCountUI;

    public void Restart() // 게임 재시작
    {
        BasicSetting.instance.playerLife = 3; // 플레이어 목숨 초기화
        BasicSetting.instance.PlayerMoney = 100; // 플레이어 돈 초기화
        SceneManager.LoadScene(0);
    }
    public void StartGame() // 게임시작
    {
        SceneManager.LoadScene(2);
        BasicSetting.instance.timer = 0.0f;
        BasicSetting.instance.timerSet = 0;
    }

    public void QuitGame() // 게임종료
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

        money.text = "Money : " + BasicSetting.instance.PlayerMoney; // 플레이어 돈 텍스트 출력

        // 생성 전 카운트다운
        startCountDown.text = $"{(int)10 - (int)BasicSetting.instance.timer}";
        if((int)10 - (int)BasicSetting.instance.timer == 0)
        {
            startCountDown.text = "START GAME!";            
        }
        else if((int)10 - (int)BasicSetting.instance.timer == -1)
        {
            startCountDown.gameObject.SetActive(false);
        }

        if(BasicSetting.instance.timer > 10) // 10초 이후에 몬스터 생성 시작
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
