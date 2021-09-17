using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    public int HP = 10;
    public int Armor = 0;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Normal"); // EnemyNavi 스크립트에 몬스터 타입 전송
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
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject);
    }

    public void Hit(int Damage, int ArmorPearce)
    {
        HP -= (Damage - Armor) + ArmorPearce;
    }
}
