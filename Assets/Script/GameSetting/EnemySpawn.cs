using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("�� ���� ����")]
    public GameObject Enemy; // ������ �� ������Ʈ
    public GameObject BigEnemy;
    public GameObject SpeedEnemy;

    public int enemyCount = 10; // �� ���� ����
    public float spawnCount = 5f; // ���� �߰� ������
    public Transform spawnPoint; // ���� ��ġ
    public List<GameObject> enemyList; // ����� �� ����Ʈ
    private GameObject clone = null; // ����� �� �� ����
    private int totalSpawn = 0;

    public int roundCount; // ���� ���� ����


    void Start()
    {
        roundCount = GameObject.Find("Controller").GetComponent<GameStartScene>().roundCount;
        enemyCount = enemyCount * roundCount;
        enemyList = new List<GameObject>();
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
    // �� ���� ��ũ��Ʈ
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
            else
            {
                clone = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation); // �� ���� 
            }
            enemyList.Add(clone); // ������ �� �迭�߰�
            totalSpawn++;
            yield return new WaitForSeconds(spawnCount);
            enemyCount--; // �� ���� ī��Ʈ ����
            Debug.Log("EnemySpawn!");            
        }
    }

    public void Die(GameObject enemy) // �� ����� ȣ��Ǵ� �Լ�
    {
        enemyList.Remove(enemy); // ����Ʈ ����
        Destroy(enemy.gameObject); // ������Ʈ ����     
    }
}
