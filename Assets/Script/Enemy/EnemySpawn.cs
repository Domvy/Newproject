using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("�� ���� ����")]
    public GameObject Enemy; // ������ �� ������Ʈ
    public int enemyCount = 10; // �� ���� ����
    public float spawnCount = 5f; // ���� �߰� ������
    public Transform spawnPoint; // ���� ��ġ
    public List<GameObject> enemyList; // ����� �� ����Ʈ
    private GameObject clone = null; // ����� �� �� ����
    public int nowEnemyCount = 0; // ���� ����Ǿ� �ִ� �� ����


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
    // �� ���� ��ũ��Ʈ
    public IEnumerator SpawnEnemy()
    {
        while (enemyCount > 0)
        {
            if(clone != null)
            {
                clone = null;
            }
            clone = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation); // �� ����            
            enemyList.Add(clone); // ������ �� �迭�߰�
            nowEnemyCount++; //����Ǿ��ִ� �� ���� ����
            yield return new WaitForSeconds(spawnCount);
            enemyCount--; // �� ���� ī��Ʈ ����
            Debug.Log("EnemySpawn!");            
        }
    }

    public void Die(GameObject enemy) // �� ����� ȣ��Ǵ� �Լ�
    {
        enemyList.Remove(enemy); // ����Ʈ ����
        Destroy(enemy.gameObject); // ������Ʈ ����
        nowEnemyCount--; // ����Ǿ��ִ� �� ���� ����
    }
}
