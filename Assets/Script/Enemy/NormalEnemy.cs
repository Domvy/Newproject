using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    public int HP = 10;
    public int Armor = 0;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Normal"); // EnemyNavi ��ũ��Ʈ�� ���� Ÿ�� ����
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
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject);
    }

    public void Hit(int Damage, int ArmorPearce)
    {
        HP -= (Damage - Armor) + ArmorPearce;
    }
}
