using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemy : MonoBehaviour
{
    public float FullHP = 100;
    public int HP = 100;
    public int Armor = 10;
    public Canvas canvasObj; // hp�� ǥ��

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

        canvasObj.transform.rotation = Quaternion.Euler(0, 0, -1); // hp�� ȸ���� ����
        canvasObj.GetComponentInChildren<Slider>().value = HP / FullHP;
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
