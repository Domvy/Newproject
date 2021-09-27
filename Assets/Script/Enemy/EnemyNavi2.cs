using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavi2 : MonoBehaviour
{
    public float enemySpeed = 10; // �� �⺻ �ӵ�
    public float enemyType = 0; // �� ���� Ÿ��
    Transform[] WayPoint; // ��������Ʈ �迭
    public int checkpoint = 1; // ��������Ʈ ù ��ǥ
    Animator animator;


    void Start()
    {        
        WayPoint = GameObject.Find("WayPoint").GetComponentsInChildren<Transform>();
        transform.position = WayPoint[checkpoint].transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        enemySpeed = 10 * enemyType;
        EnemyMove();
        
    }
    // �� �̵� �Լ�
    void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, WayPoint[checkpoint].transform.position, enemySpeed * Time.deltaTime);
        transform.LookAt(WayPoint[checkpoint]);
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
        if (enemytype == "Big")
        {
            enemyType = 0.5f;
        }
        if (enemytype == "Speed")
        {
            enemyType = 2;
        }
    }
}
