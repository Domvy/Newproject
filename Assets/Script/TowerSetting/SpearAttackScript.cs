using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttackScript : MonoBehaviour
{
    public List<GameObject> enemySpawnList; // ������ �� �迭��

    private float towerRange; //Ÿ�� ��Ÿ�
    public int towerRangeX = 20; // ��Ÿ� ������(�����ִ� ��)
    private GameObject target; // ���� Ÿ��    
    

    private int NormalDamage = 0; // ���ݷ�
    private int ArmorPearce = 1; // ���� ���ݷ�

    private float timer = 0.0f;
    private float waitingTime = 5;
    private float attackTimer = 0.0f;
    private float attackDelay = 0.1f;

    LineRenderer lineRenderer; // ������ ���� ����Ʈ

    LayerMask layermask;


    void Start()
    {
        target = null;
        enemySpawnList = new List<GameObject>(); // �迭 ����  
        towerRange = new Vector3(1, 1, 1).magnitude * towerRangeX; // Ÿ�� ��Ÿ� ���    
        layermask = LayerMask.GetMask("Enemy");

        lineRenderer = gameObject.GetComponent<LineRenderer>(); // ������ ����Ʈ ����
        lineRenderer.SetColors(Color.red, Color.red);
        lineRenderer.SetWidth(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        attackTimer += Time.deltaTime;

        enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // �� ���� �迭�� �޾ƿ�       
        if (target == null)
        {
            gameObject.GetComponent<LineRenderer>().enabled = false;
            Distance(); // �����Լ� ����
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
        }
        Debug.DrawRay(transform.position, dir, Color.red);
    }
}

