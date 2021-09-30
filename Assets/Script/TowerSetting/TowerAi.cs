using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAi : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // 생성된 적 배열값
    public Transform enemyPos; // 적 오브젝트 위치값
    public GameObject target = null; // 타겟 설정용

    public GameObject normalAttack; // 일반공격   

    public float towerRange; //타워 사거리
    public int towerRangeX = 20; // 사거리 설정값(곱해주는 값)
    private float distance; // 타워와 적 사이의 거리 
    public int rangeUpCount = 0;

    float timer; // 시간 타이머
    public float waitingtime; // 함수 재호출 대기시간(공격 딜레이)

    private void Start()
    {
        timer = 5.0f;
        waitingtime = 5;
        enemySpawnList = new List<GameObject>(); // 배열 선언
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // 타워 사거리 계산      
        target = null;
    }

    private void Update()
    {
        rangeUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().RangeUpCount;
        towerRangeX = 20 + (10 * rangeUpCount);
        timer += Time.deltaTime;
        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // 적 생성 배열값 받아옴
        if(target == null)
        {
            Targeting();
        }
        else if (target != null)
        {
            transform.LookAt(target.transform);
            if (timer > waitingtime) // 공격 딜레이 생성
            {                
                NormalAttack();
                timer = 0f;
            }
        }        
    }

    public void Targeting() // 적 타겟 검사
    {
        for (int i = 0; i < enemySpawnList.Count; i++)
        {
            enemyPos = enemySpawnList[i].transform;
            distance = (enemyPos.position - transform.position).magnitude;

            if (CanAttack() == true)
            {
                target = enemySpawnList[i]; //타겟 설정
            }
        }
    }

    public bool CanAttack() // 공격 가능여부
    {
        if (towerRange >= distance && distance > 0)
        {
            return true;
        }

        return false;
    }

    public void NormalAttack() // 일반 공격 실행
    {
        Instantiate(normalAttack, transform.position, transform.rotation);
        Debug.Log("Attack!");
    }
}
