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


    public void Restart() // 게임 재시작
    {
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
