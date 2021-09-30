using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��

    public float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private GameObject target; // ���� Ÿ��    

    public int NormalDamage = 0; // ���ݷ�
    public int ArmorPearce = 1; // ���� ���ݷ�
    public int powerUpCount = 0;
    public int rangeUpCount = 0;

    private float timer = 0.0f;
    private float waitingTime = 4.9f;
    private float attackTimer = 0.0f;
    private float attackDelay = 0.1f;

    LineRenderer lineRenderer; // ������ ���� ����Ʈ

    LayerMask layermask;


    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // �迭 ����          
        layermask = LayerMask.GetMask("Enemy");

        powerUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().powerUpCount;
        rangeUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().RangeUpCount;
        towerRangeX = 20 + (10 * rangeUpCount);
        NormalDamage = 0;
        ArmorPearce = 1 + (1 * powerUpCount);

        lineRenderer = gameObject.GetComponent<LineRenderer>(); // ������ ����Ʈ ����
        lineRenderer.SetColors(Color.red, Color.red);
        lineRenderer.SetWidth(0.5f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ���        

        timer += Time.deltaTime;
        attackTimer += Time.deltaTime;

        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ� 


        if (target == null)
        {
            gameObject.GetComponent<LineRenderer>().enabled = false;
            Distance(); // �����Լ� ����
        }

        else if ((target.transform.position - transform.position).magnitude > towerRange || target.tag != "Enemy")
        {
            target = null;
        }

        if (attackTimer > attackDelay)
        {
            RayzerAttack();
            attackTimer = 0;
        }

        if (timer > waitingTime)
        {
            Destroy(gameObject);
        }

        lineRenderer.SetPosition(0, transform.localPosition);
        lineRenderer.SetPosition(1, target.transform.position);
    }

    void Distance() //��Ÿ� ���� ������Ʈ�� ã�� Ÿ�ټ���
    {
        for (int i = 0; i < enemySpawnList.Count; i++)
        {
            if (towerRange >= (enemySpawnList[i].transform.position - transform.position).magnitude)
            {
                target = enemySpawnList[i];
                gameObject.GetComponent<LineRenderer>().enabled = true;
                break;
            }
        }
    }

    void RayzerAttack()
    {        
        RaycastHit hit;
        Vector3 dir = target.transform.position - transform.position;
        if (Physics.Raycast(transform.position, dir, out hit, layermask))
        {
            if(hit.collider.gameObject.tag == "Enemy")
                hit.collider.gameObject.GetComponent<NormalEnemy>().Hit(NormalDamage, ArmorPearce);
            else if (hit.collider.gameObject.tag == "SpeedEnemy")
                hit.collider.gameObject.GetComponent<SpeedEnemy>().Hit(NormalDamage, ArmorPearce);
            else if (hit.collider.gameObject.tag == "BigEnemy")
                hit.collider.gameObject.GetComponent<BigEnemy>().Hit(NormalDamage, ArmorPearce);
            else if (hit.collider.tag == "BossEnemy")           
                hit.collider.GetComponent<BossSlime>().Hit(NormalDamage, ArmorPearce);            
        }
        Debug.DrawRay(transform.position, dir, Color.red);
    }
}

