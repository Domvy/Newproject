using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("적 생산 설정")]
    public GameObject Enemy; // 생산할 적 오브젝트
    public int enemyCount = 10; // 총 생산 숫자
    public float spawnCount = 5f; // 생산 중간 딜레이
    public Transform spawnPoint; // 생산 위치
    public List<GameObject> enemyList; // 생산된 적 리스트
    private GameObject clone = null; // 생산된 적 값 보관
    public int nowEnemyCount = 0; // 현재 생산되어 있는 적 숫자


    void Start()
    {
        enemyList = new List<GameObject>();
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (enemyCount == 0)
        {
            StopCoroutine(SpawnEnemy());
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
            clone = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation); // 적 생성            
            enemyList.Add(clone); // 생성된 값 배열추가
            nowEnemyCount++; //생산되어있는 적 숫자 증가
            yield return new WaitForSeconds(spawnCount);
            enemyCount--; // 총 생성 카운트 감소
            Debug.Log("EnemySpawn!");            
        }
    }

    public void Die(GameObject enemy) // 적 사망시 호출되는 함수
    {
        enemyList.Remove(enemy); // 리스트 삭제
        Destroy(enemy.gameObject); // 오브젝트 삭제
        nowEnemyCount--; // 생산되어있는 적 숫자 감소
    }
}
