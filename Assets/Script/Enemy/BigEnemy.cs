using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public int HP = 100;
    public int Armor = 10;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Big"); // EnemyNavi ��ũ��Ʈ�� ���� Ÿ�� ����
    }

    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die() // ����� EnemySpawn ��ũ��Ʈ �Լ� ȣ��
    {
        BasicSetting.instance.PlayerMoney += 10;
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject);        
    }

    public void Hit(int Damage, int ArmorPearce)
    {
        if(Damage - Armor < 0)
        {
            Armor = Damage;
        }
        HP -= (Damage - Armor) + ArmorPearce;
    }
    public void Hit(int Damage)
    {
        if (Damage - Armor < 0)
        {
            Armor = Damage;
        }
        HP -= (Damage - Armor);
    }
}
