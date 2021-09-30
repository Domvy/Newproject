using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlime : MonoBehaviour
{
    public float FullHP = 1000; // �ִ�ü��
    public float HP = 1000; // ����ü��
    public int Armor = 10; // ����
    private float skillTimer = 0.0f;
    private int skillDelay = 5;
    public Canvas canvasObj; // hp�� ǥ��
    public int Difficulty = 1;
    Animator ani;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Boss"); // EnemyNavi ��ũ��Ʈ�� ���� Ÿ�� ���� 
        Difficulty = GameObject.Find("Controller").GetComponent<GameStartScene>().Difficulty;
        FullHP = FullHP * Difficulty;
        HP = HP * Difficulty;
        Armor = Armor * Difficulty;
        ani = GetComponent<Animator>();

    }

    void Update()
    {
        if (HP < 0.1f)
        {
            Die();
            HP = 0.1f;
        }

        skillTimer += Time.deltaTime;
        if (skillTimer > skillDelay)
        {
            skillTimer = 0;
            ani.SetTrigger("Heal");
            Heal();
            
        }

        canvasObj.transform.rotation = Quaternion.Euler(0, 0, -1); // hp�� ȸ���� ����
        canvasObj.GetComponentInChildren<Slider>().value = HP / FullHP;
    }

    void Die() // ����� EnemySpawn ��ũ��Ʈ �Լ� ȣ��
    {
        gameObject.GetComponent<EnemyNavi2>().enabled = false;
        this.gameObject.layer = 0;
        this.gameObject.tag = "Untagged";
        ani.SetBool("Die", true);
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject, 100);
    }

    public void Hit(int Damage, int ArmorPearce)
    {
        if (Damage <= Armor && Damage !=0)
        {
            HP -= 1 + ArmorPearce;
        }
        else if (Damage == 0)
        {
            HP -= ArmorPearce;
        }
        else
        HP -= (Damage - Armor) + ArmorPearce;
    }

    public void Heal() // �浹�� ������ �ο�
    {        
        Collider[] Splash = Physics.OverlapSphere(transform.position, 10.0f); // ���� ����
        foreach (Collider hit in Splash)
        {
            if (hit.gameObject.tag == "Enemy")
            {
                hit.gameObject.GetComponent<NormalEnemy>().HP += FullHP * 0.01f;
            }
            else if (hit.gameObject.tag == "SpeedEnemy")
            {
                hit.gameObject.GetComponent<SpeedEnemy>().HP += FullHP * 0.01f;
            }
            else if (hit.gameObject.tag == "BigEnemy")
            {
                hit.gameObject.GetComponent<BigEnemy>().HP += FullHP * 0.01f;
            }
        }
    }

}
