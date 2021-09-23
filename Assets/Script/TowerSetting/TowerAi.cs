using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAi : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��
    public int nowenemyCount = 0; // �� ������Ʈ �� ���갪
    public Transform enemyPos; // �� ������Ʈ ��ġ��
    public GameObject target = null; // Ÿ�� ������

    public GameObject normalAttack; // �Ϲݰ���   

    private float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private float distance; // Ÿ���� �� ������ �Ÿ� 

    float timer; // �ð� Ÿ�̸�
    public float waitingtime; // �Լ� ��ȣ�� ���ð�(���� ������)

    public bool canattack;

    private void Start()
    {
        timer = 5.0f;
        waitingtime = 5;
        enemySpawnList = new List<GameObject>(); // �迭 ����
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ���      
        target = null;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ�
        nowenemyCount = GameObject.Find("Controller").GetComponent<EnemySpawn>().nowEnemyCount; // ���� �� ���� �޾ƿ��� 
        if(target == null)
        {
            Targeting();
        }
        transform.LookAt(target.transform);
        if (target != null)
        {
            if (timer > waitingtime) // ���� ������ ����
            {                
                NormalAttack();
                timer = 0f;
            }
        }        
    }

    public void Targeting() // �� Ÿ�� �˻�
    {
        for (int i = 0; i < nowenemyCount; i++)
        {
            enemyPos = enemySpawnList[i].transform;
            distance = (enemyPos.position - transform.position).magnitude;
            CanAttack();
            if (canattack == true)
            {
                target = enemySpawnList[i]; //Ÿ�� ����
            }
        }
    }

    public bool CanAttack() // ���� ���ɿ���
    {
        if (towerRange >= distance && distance > 0)
        {
            return canattack = true;
        }
        else
        {
            return canattack = false;
        }

    }

    public void NormalAttack() // �Ϲ� ���� ����
    {
        Instantiate(normalAttack, transform.position, transform.rotation);
        Debug.Log("Attack!");
    }
}
