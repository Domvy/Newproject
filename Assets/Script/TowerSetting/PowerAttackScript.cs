using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��
    private float bulletSpeed = 30; // �߻�ü �ӵ�

    private float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private GameObject target; //���� Ÿ��
    private Transform targetposition;


    private int NormalDamage = 20; // ���ݷ�
    private int ArmorPearce = 0; // ���� ���ݷ�

    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // �迭 ����  
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ��� 
        
    }

    void Update()
    {
        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ�    
        if (target == null || target.tag != "Enemy")
        {
            Distance(); // �����Լ� ����
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 1.0f); //n�ʰ� ������ �ڵ����� ������Ʈ ����
    }

    void Distance() //��Ÿ� ���� ������Ʈ�� ã�� Ÿ�ټ���
    {
        for (int i = 0; i < enemySpawnList.Count; i++)
        {
            if (towerRange >= (enemySpawnList[i].transform.position - transform.position).magnitude)
            {
                target = enemySpawnList[i];
                break;
            }
        }
    }

    public void OnTriggerEnter(Collider other) // �浹�� ������ �ο�
    {
        Destroy(gameObject);
        Collider[] Splash = Physics.OverlapSphere(transform.position, 10.0f); // ���� ����
        foreach(Collider hit in Splash)
        {
            if(hit.gameObject.tag == "Enemy")
            {
                hit.gameObject.GetComponent<NormalEnemy>().Hit(NormalDamage, ArmorPearce);
            }
            else if (hit.gameObject.tag == "SpeedEnemy")
            {
                hit.gameObject.GetComponent<SpeedEnemy>().Hit(NormalDamage, ArmorPearce);
            }
            else if (hit.gameObject.tag == "BigEnemy")
            {
                hit.gameObject.GetComponent<BigEnemy>().Hit(NormalDamage, ArmorPearce);
            }
            else if (hit.gameObject.tag == "BossEnemy")
            {
                hit.gameObject.GetComponent<BossSlime>().Hit(NormalDamage, ArmorPearce);
            }
        }
    }
}
