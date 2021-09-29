using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalEnemy : MonoBehaviour
{
    public float FullHP = 10; // �ִ�ü��
    public float HP = 10; // ����ü��
    public int Armor = 1; // ����
    public Canvas canvasObj; // hp�� ǥ��
    public int Difficulty = 1;

    private void Start()
    {
        gameObject.GetComponent<EnemyNavi2>().SendMessage("SpeedSetting", "Normal"); // EnemyNavi ��ũ��Ʈ�� ���� Ÿ�� ���� 
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
        canvasObj.GetComponentInChildren<Slider>().value = HP/FullHP;
    }

    void Die() // ����� EnemySpawn ��ũ��Ʈ �Լ� ȣ��
    {
        gameObject.GetComponent<EnemyNavi2>().enabled = false;
        this.gameObject.layer = 0;
        this.gameObject.tag = "Untagged";
        Animator ani;
        ani = GetComponent<Animator>();
        ani.SetBool("Die", true);
        GameObject.Find("Controller").GetComponent<EnemySpawn>().Die(gameObject,1);
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
}
