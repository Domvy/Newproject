using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // 생성된 적 배열값
    public float bulletSpeed = 50; // 발사체 속도

    private float towerRange; //타워 사거리
    public int towerRangeX = 20; // 사거리 설정값(곱해주는 값)

    public int nowenemyCount = 0;// 총 생산횟수

    private int NormalDamage = 10; // 공격력

    void Start()
    {
        enemySpawnList = new List<GameObject>(); // 배열 선언  
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // 타워 사거리 계산            
    }

    // Update is called once per frame
    void Update()
    {                
        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // 적 생성 배열값 받아옴
        nowenemyCount = GameObject.Find("Controller").GetComponent<EnemySpawn>().nowEnemyCount; // 현재 적 숫자 받아오기
        Distance(); // 공격함수 실행
        Destroy(gameObject,5.0f);
    }

    void Distance() //사거리 내의 오브젝트를 찾고 공격
    {
        for(int i = 0; i < nowenemyCount; i++)
        {
            if(towerRange >= (enemySpawnList[i].transform.position - transform.position).magnitude)
            {
                transform.position = Vector3.MoveTowards(transform.position, enemySpawnList[i].transform.position, bulletSpeed * Time.deltaTime);
            }
        }
    }

    public void OnTriggerEnter(Collider other) // 충돌시 데미지 부여
    {
        Destroy(gameObject);
        other.gameObject.SendMessage("Hit", NormalDamage);     
    }
}
