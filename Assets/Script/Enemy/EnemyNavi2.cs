using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavi2 : MonoBehaviour
{
    public float enemySpeed = 10; // �� �⺻ �ӵ�
    public int enemyType = 1; // �� ���� Ÿ��
    Transform[] WayPoint; // ��������Ʈ �迭
    public int checkpoint = 1; // ��������Ʈ ù ��ǥ


    void Start()
    {
        enemySpeed = 10 * enemyType;
        WayPoint = GameObject.Find("WayPoint").GetComponentsInChildren<Transform>();
        transform.position = WayPoint[checkpoint].transform.position;
    }

    void Update()
    {
        EnemyMove();
    }
    // �� �̵� �Լ�
    void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, WayPoint[checkpoint].transform.position, enemySpeed * Time.deltaTime);
        if(transform.position == WayPoint[checkpoint].transform.position )
        {
            checkpoint++;
        }
        else if(checkpoint == WayPoint.Length)
        {
            checkpoint = 1;
        }
    }

    public void SpeedSetting(string enemytype) // ���� Ÿ��(���ǵ� ��ȭ)
    {
        if(enemytype == "Normal")
        {
            enemyType = 1;
        }
    }
}
