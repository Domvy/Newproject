using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // 생성된 적 배열값
    private float bulletSpeed = 50; // 발사체 속도

    public float towerRange; //타워 사거리
    public int towerRangeX = 20; // 사거리 설정값(곱해주는 값)
    private GameObject target; //공격 타겟

    public int NormalDamage = 10; // 공격력
    public int ArmorPearce = 0; // 방어무시 공격력
    public int powerUpCount = 0;
    public int rangeUpCount = 0;

    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // 배열 선언   
        powerUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().powerUpCount;
        rangeUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().RangeUpCount;

        towerRangeX = 20 + (10 * rangeUpCount);
        NormalDamage = 10;
        ArmorPearce = 0 + (5 * powerUpCount);
    }

    void Update()
    {
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // 타워 사거리 계산    

        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // 적 생성 배열값 받아옴     
        if (target == null || target.tag != "Enemy")
        {
            Distance(); // 공격함수 실행
        }
        //공격        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        Destroy(gameObject,1f); //n초가 지나면 자동으로 오브젝트 삭제
    }

    void Distance() //사거리 내의 오브젝트를 찾고 타겟설정
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

    public void OnTriggerEnter(Collider other) // 충돌시 데미지 부여
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
