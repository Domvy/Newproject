using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��
    private float bulletSpeed = 30; // �߻�ü �ӵ�

    public float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX; // ��Ÿ� ������(�����ִ� ��)
    private GameObject target; //���� Ÿ��
    private Transform targetposition;

    public int NormalDamage = 20; // ���ݷ�
    public int ArmorPearce = 0; // ���� ���ݷ�
    public float SplashBoundary = 10.0f;
    public int powerUpCount = 0;
    public int rangeUpCount = 0;

    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // �迭 ����

        powerUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().powerUpCount;
        rangeUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().RangeUpCount;
        towerRangeX = 20 + (10 * rangeUpCount);
        NormalDamage = 20 + (10 * powerUpCount);
        SplashBoundary = 10.0f + (5.0f*powerUpCount);
        ArmorPearce = 0;
    }

    void Update()
    {
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ��� 

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
        Collider[] Splash = Physics.OverlapSphere(transform.position, SplashBoundary); // ���� ����
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
