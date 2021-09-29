using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlime : MonoBehaviour
{
    public float FullHP = 1000; // 최대체력
    public float HP = 1000; // 현재체력
    public int Armor = 10; // 방어력
    public Canvas canvasObj; // hp바 표시
    public int Difficulty = 1;
    Animator ani;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Boss"); // EnemyNavi 스크립트에 몬스터 타입 전송 
        Difficulty = GameObject.Find("Controller").GetComponent<GameStartScene>().Difficulty;
        FullHP = FullHP * Difficulty;
        HP = HP * Difficulty;
        Armor = Armor * Difficulty;
        StartCoroutine(Heal());
    }

    void Update()
    {
        if (HP < 0.1f)
        {
            Die();
            HP = 0.1f;
        }

        canvasObj.transform.rotation = Quaternion.Euler(0, 0, -1); // hp바 회전값 고정
        canvasObj.GetComponentInChildren<Slider>().value = HP / FullHP;
    }

    void Die() // 사망시 EnemySpawn 스크립트 함수 호출
    {
        StopCoroutine(Heal());
        gameObject.GetComponent<EnemyNavi2>().enabled = false;
        this.gameObject.layer = 0;
        this.gameObject.tag = "Untagged";
        ani = GetComponent<Animator>();
        ani.SetBool("Die", true);
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject, 100);
    }

    public void Hit(int Damage, int ArmorPearce)
    {
        if (Damage - Armor < 0)
        {
            Damage = 0;
            Armor = 0;
        }
        HP -= (Damage - Armor) + ArmorPearce;
    }

    public IEnumerator Heal()
    {
        Collider[] Splash = Physics.OverlapSphere(transform.position, 5.0f); // 범위 지정
        foreach (Collider hit in Splash)
        {
            if (hit.gameObject.tag == "Enemy")
            {
                hit.gameObject.GetComponent<NormalEnemy>().HP += FullHP * 1 / 10;
            }
            if (hit.gameObject.tag == "SpeedEnemy")
            {
                hit.gameObject.GetComponent<NormalEnemy>().HP += FullHP * 1 / 10;
            }
            if (hit.gameObject.tag == "BigEnemy")
            {
                hit.gameObject.GetComponent<NormalEnemy>().HP += FullHP * 1 / 10;
            }
        }
        yield return new WaitForSeconds(10.0f);
    }
}
