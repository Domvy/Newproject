using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemy : MonoBehaviour
{
    public float FullHP = 100;
    public int HP = 100;
    public int Armor = 10;
    public Canvas canvasObj; // hp바 표시
    public int Difficulty = 1;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Big"); // EnemyNavi 스크립트에 몬스터 타입 전송
        Difficulty = GameObject.Find("Controller").GetComponent<GameStartScene>().Difficulty;
        FullHP = FullHP * Difficulty;
        HP = HP * Difficulty;
        Armor = Armor * Difficulty;
    }

    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }

        canvasObj.transform.rotation = Quaternion.Euler(0, 0, -1); // hp바 회전값 고정
        canvasObj.GetComponentInChildren<Slider>().value = HP / FullHP;
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
            Damage = 0;
            Armor = 0;
        }
        HP -= (Damage - Armor) + ArmorPearce;
    }
}
