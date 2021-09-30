using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlime : MonoBehaviour
{
    public float FullHP = 1000; // 최대체력
    public float HP = 1000; // 현재체력
    public int Armor = 10; // 방어력
    private float skillTimer = 0.0f;
    private int skillDelay = 5;
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

        canvasObj.transform.rotation = Quaternion.Euler(0, 0, -1); // hp바 회전값 고정
        canvasObj.GetComponentInChildren<Slider>().value = HP / FullHP;
    }

    void Die() // 사망시 EnemySpawn 스크립트 함수 호출
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

    public void Heal() // 충돌시 데미지 부여
    {        
        Collider[] Splash = Physics.OverlapSphere(transform.position, 10.0f); // 범위 지정
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
