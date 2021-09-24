using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��
    private float bulletSpeed = 50; // �߻�ü �ӵ�

    private float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private GameObject target; //���� Ÿ��

    public int nowenemyCount = 0;// �� ����Ƚ��

    private int NormalDamage = 10; // ���ݷ�
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
        nowenemyCount = GameObject.Find("Controller").GetComponent<EnemySpawn>().nowEnemyCount; // ���� �� ���� �޾ƿ���        
        if (target == null)
        {
            Distance(); // �����Լ� ����
        }
        //����
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 1.0f); //n�ʰ� ������ �ڵ����� ������Ʈ ����
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

    public void OnTriggerEnter(Collider other) // �浹�� ������ �ο�
    {
        Destroy(gameObject);
        if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<NormalEnemy>().Hit(NormalDamage, ArmorPearce);
        else if (other.gameObject.tag == "SpeedEnemy")
            other.gameObject.GetComponent<SpeedEnemy>().Hit(NormalDamage, ArmorPearce);
        else if (other.gameObject.tag == "BigEnemy")
            other.gameObject.GetComponent<BigEnemy>().Hit(NormalDamage, ArmorPearce);
    }
}
