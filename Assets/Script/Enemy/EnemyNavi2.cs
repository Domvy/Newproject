using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavi2 : MonoBehaviour
{
    public float enemySpeed = 10; // 적 기본 속도
    public float enemyType = 0; // 적 유닛 타입
    Transform[] WayPoint; // 웨이포인트 배열
    public int checkpoint = 1; // 웨이포인트 첫 목표
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
    // 적 이동 함수
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

    public void SpeedSetting(string enemytype) // 몬스터 타입(스피드 변화)
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
