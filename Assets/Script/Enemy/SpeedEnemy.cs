using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : MonoBehaviour
{
    public int HP = 20;
    public int Armor = 0;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "SpeedEnemy"); // EnemyNavi ��ũ��Ʈ�� ���� Ÿ�� ����        
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
        BasicSetting.instance.PlayerMoney += 5;
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject);
    }

    public void Hit(int Damage, int ArmorPearce)
    {
        if (Damage - Armor < 0)
        {
            Armor = Damage;
        }
        HP -= (Damage - Armor) + ArmorPearce;
    }
}
