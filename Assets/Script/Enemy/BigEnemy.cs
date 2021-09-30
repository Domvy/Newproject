using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemy : MonoBehaviour
{
    public float FullHP = 100;
    public float HP = 100;
    public int Armor = 5;
    public Canvas canvasObj; // hp�� ǥ��
    public int Difficulty = 1;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Big"); // EnemyNavi ��ũ��Ʈ�� ���� Ÿ�� ����
        Difficulty = GameObject.Find("Controller").GetComponent<GameStartScene>().Difficulty;
        FullHP = FullHP * Difficulty;
        HP = HP * Difficulty;
        Armor = Armor * Difficulty;
    }

    void Update()
    {
        if (HP < 0.1f)
        {
            Die();
            HP = 0.1f;
        }

        canvasObj.transform.rotation = Quaternion.Euler(0, 0, -1); // hp�� ȸ���� ����
        canvasObj.GetComponentInChildren<Slider>().value = HP / FullHP;
    }

    void Die() // ����� EnemySpawn ��ũ��Ʈ �Լ� ȣ��
    {
        gameObject.GetComponent<EnemyNavi2>().enabled = false;
        this.gameObject.layer = 0;
        this.gameObject.tag = "Untagged";
        Animator ani;
        ani = GetComponent<Animator>();
        ani.SetBool("Die", true);
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject,10);        
    }

    public void Hit(int Damage, int ArmorPearce)
    {
        if(Damage <= Armor && Damage != 0)
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
}
