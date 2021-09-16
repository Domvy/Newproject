using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��
    public float bulletSpeed = 50; // �߻�ü �ӵ�

    private float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)

    public int nowenemyCount = 0;// �� ����Ƚ��

    private int NormalDamage = 10; // ���ݷ�

    void Start()
    {
        enemySpawnList = new List<GameObject>(); // �迭 ����  
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ���            
    }

    // Update is called once per frame
    void Update()
    {                
        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ�
        nowenemyCount = GameObject.Find("Controller").GetComponent<EnemySpawn>().nowEnemyCount; // ���� �� ���� �޾ƿ���
        Distance(); // �����Լ� ����
        Destroy(gameObject,5.0f);
    }

    void Distance() //��Ÿ� ���� ������Ʈ�� ã�� ����
    {
        for(int i = 0; i < nowenemyCount; i++)
        {
            if(towerRange >= (enemySpawnList[i].transform.position - transform.position).magnitude)
            {
                transform.position = Vector3.MoveTowards(transform.position, enemySpawnList[i].transform.position, bulletSpeed * Time.deltaTime);
            }
        }
    }

    public void OnTriggerEnter(Collider other) // �浹�� ������ �ο�
    {
        Destroy(gameObject);
        other.gameObject.SendMessage("Hit", NormalDamage);     
    }
}
