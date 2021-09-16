using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavi2 : MonoBehaviour
{
    public float enemySpeed = 10; // 적 기본 속도
    public int enemyType = 1; // 적 유닛 타입
    Transform[] WayPoint; // 웨이포인트 배열
    public int checkpoint = 1; // 웨이포인트 첫 목표


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
    // 적 이동 함수
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

    public void SpeedSetting(string enemytype) // 몬스터 타입(스피드 변화)
    {
        if(enemytype == "Normal")
        {
            enemyType = 1;
        }
    }
}
