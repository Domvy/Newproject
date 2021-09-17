using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // 생성된 적 배열값

    private float towerRange; //타워 사거리
    public int towerRangeX = 20; // 사거리 설정값(곱해주는 값)
    private GameObject target; //공격 타겟

    public int nowenemyCount = 0;// 총 생산횟수

    public int NormalDamage = 0; // 공격력
    public int ArmorPearce = 1; // 방어무시 공격력

    public float timer = 0.0f;
    public float waitingTime = 1;

    LayerMask layermask;

    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // 배열 선언  
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // 타워 사거리 계산    
        layermask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // 적 생성 배열값 받아옴
        nowenemyCount = GameObject.Find("Controller").GetComponent<EnemySpawn>().nowEnemyCount; // 현재 적 숫자 받아오기        
        if (target == null)
        {
            Distance(); // 공격함수 실행
        }
        if (timer > waitingTime)
        {
            RayzerAttack();
            timer = 0.0f;
        }
    }

    void Distance() //사거리 내의 오브젝트를 찾고 타겟설정
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

