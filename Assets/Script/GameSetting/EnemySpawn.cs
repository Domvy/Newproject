using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("적 생산 설정")]
    public GameObject Enemy; // 생산할 적 오브젝트
    public GameObject BigEnemy;
    public GameObject SpeedEnemy;
    public GameObject SlimeBoss;

    public int enemyCount = 10; // 총 생산 숫자
    public float spawnCount = 5f; // 생산 중간 딜레이
    public Transform spawnPoint; // 생산 위치
    public List<GameObject> enemyList; // 생산된 적 리스트
    private GameObject clone = null; // 생산된 적 값 보관
    private int totalSpawn = 0; //지금까지 생성된 숫자

    public int roundCount; // 현재 라운드 숫자
    public int killCount; // 죽은 적 숫자

    public int goldUpgradeCount = 1;

    void Start()
    {
        roundCount = GameObject.Find("Controller").GetComponent<GameStartScene>().roundCount;
        enemyCount = enemyCount * roundCount;
        enemyList = new List<GameObject>();
        goldUpgradeCount = 1;
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        roundCount = GameObject.Find("Controller").GetComponent<GameStartScene>().roundCount;

        if (enemyCount == 0)
        {
            StopCoroutine(SpawnEnemy());
        }        
        if(enemyCount == 0 && enemyList.Count == 0)
        {
            GameObject.Find("Controller").GetComponent<GameStartScene>().RoundComplete = 1;
        }
    }
    // 적 생성 스크립트
    public IEnumerator SpawnEnemy()
    {
        while (enemyCount > 0)
        {
            if(clone != null)
            {
                clone = null;
            }

            if(roundCount >= 2 && totalSpawn % 5 == 0)
            {
                clone = Instantiate(SpeedEnemy, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("SpeedEnemySpawn!");
            }
            else if (roundCount >= 3 && totalSpawn % 11 == 0)
            {
                clone = Instantiate(BigEnemy, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("BigEnemySpawn!");
            }
            else if (roundCount == 5 && enemyCount == 50)
            {
                clone = Instantiate(SlimeBoss, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("BossEnemySpawn!");
            }
            else
            {
                clone = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation); // 적 생성 
            }
            enemyList.Add(clone); // 생성된 값 배열추가
            totalSpawn++;
            yield return new WaitForSeconds(spawnCount);
            enemyCount--; // 총 생성 카운트 감소
            Debug.Log("EnemySpawn!");            
        }
    }

    public void Die(GameObject enemy , int n) // 적 사망시 호출되는 함수
    {
        enemyList.Remove(enemy); // 리스트 삭제
        Destroy(enemy.gameObject,1f); // 오브젝트 삭제
        BasicSetting.instance.PlayerMoney += n*goldUpgradeCount;
        killCount++;
    }
}
