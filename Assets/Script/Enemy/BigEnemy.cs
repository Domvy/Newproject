using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public int HP = 100;
    public int Armor = 10;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Big"); // EnemyNavi 스크립트에 몬스터 타입 전송
    }

    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die() // 사망시 EnemySpawn 스크립트 함수 호출
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
