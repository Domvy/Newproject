using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��
    private float bulletSpeed = 50; // �߻�ü �ӵ�

    public float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private GameObject target; //���� Ÿ��

    public int NormalDamage = 10; // ���ݷ�
    public int ArmorPearce = 0; // ���� ���ݷ�
    public int powerUpCount = 0;
    public int rangeUpCount = 0;

    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // �迭 ����   
        powerUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().powerUpCount;
        rangeUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().RangeUpCount;

        towerRangeX = 20 + (10 * rangeUpCount);
        NormalDamage = 10;
        ArmorPearce = 0 + (5 * powerUpCount);
    }

    void Update()
    {
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ���    

        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ�     
        if (target == null || target.tag != "Enemy")
        {
            Distance(); // �����Լ� ����
        }
        //����        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        Destroy(gameObject,1f); //n�ʰ� ������ �ڵ����� ������Ʈ ����
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
        if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<NormalEnemy>().Hit(NormalDamage, ArmorPearce);
        else if (other.gameObject.tag == "SpeedEnemy")
            other.gameObject.GetComponent<SpeedEnemy>().Hit(NormalDamage, ArmorPearce);
        else if (other.gameObject.tag == "BigEnemy")
            other.gameObject.GetComponent<BigEnemy>().Hit(NormalDamage, ArmorPearce);
        else if (other.gameObject.tag == "BossEnemy")        
            other.gameObject.GetComponent<BossSlime>().Hit(NormalDamage, ArmorPearce);        
    }
}
