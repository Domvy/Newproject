using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��

    private float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private GameObject target; //���� Ÿ��

    public int nowenemyCount = 0;// �� ����Ƚ��

    public int NormalDamage = 0; // ���ݷ�
    public int ArmorPearce = 1; // ���� ���ݷ�

    public float timer = 0.0f;
    public float waitingTime = 1;

    LayerMask layermask;

    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // �迭 ����  
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ���    
        layermask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ�
        nowenemyCount = GameObject.Find("Controller").GetComponent<EnemySpawn>().nowEnemyCount; // ���� �� ���� �޾ƿ���        
        if (target == null)
        {
            Distance(); // �����Լ� ����
        }
        if (timer > waitingTime)
        {
            RayzerAttack();
            timer = 0.0f;
        }
    }

    void Distance() //��Ÿ� ���� ������Ʈ�� ã�� Ÿ�ټ���
    {
        for (int i = 0; i < nowenemyCount; i++)
        {
            if (towerRange >= (enemySpawnList[i].transform.position - transform.position).magnitude)
            {
                target = enemySpawnList[i];
                break;
            }
        }
    }

    void RayzerAttack()
    {
        Vector3 dir = target.transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, layermask))
        {
            hit.collider.gameObject.GetComponent<NormalEnemy>().Hit(NormalDamage, ArmorPearce);
        }
    }
}

