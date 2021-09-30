using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAi : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��
    public Transform enemyPos; // �� ������Ʈ ��ġ��
    public GameObject target = null; // Ÿ�� ������

    public GameObject normalAttack; // �Ϲݰ���   

    public float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private float distance; // Ÿ���� �� ������ �Ÿ� 
    public int rangeUpCount = 0;

    float timer; // �ð� Ÿ�̸�
    public float waitingtime; // �Լ� ��ȣ�� ���ð�(���� ������)

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
        rangeUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().RangeUpCount;
        towerRangeX = 20 + (10 * rangeUpCount);
        timer += Time.deltaTime;
        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ�
        if(target == null)
        {
            Targeting();
        }
        else if (target != null)
        {
            transform.LookAt(target.transform);
            if (timer > waitingtime) // ���� ������ ����
            {                
                NormalAttack();
                timer = 0f;
            }
        }        
    }

    public void Targeting() // �� Ÿ�� �˻�
    {
        for (int i = 0; i < enemySpawnList.Count; i++)
        {
            enemyPos = enemySpawnList[i].transform;
            distance = (enemyPos.position - transform.position).magnitude;

            if (CanAttack() == true)
            {
                target = enemySpawnList[i]; //Ÿ�� ����
            }
        }
    }

    public bool CanAttack() // ���� ���ɿ���
    {
        if (towerRange >= distance && distance > 0)
        {
            return true;
        }

        return false;
    }

    public void NormalAttack() // �Ϲ� ���� ����
    {
        Instantiate(normalAttack, transform.position, transform.rotation);
        Debug.Log("Attack!");
    }
}
