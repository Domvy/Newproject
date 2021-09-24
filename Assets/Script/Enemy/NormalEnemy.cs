using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalEnemy : MonoBehaviour
{
    public float FullHP = 10;
    public float HP = 10;
    public int Armor = 1;
    public Canvas canvasObj; // hp�� ǥ��

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

        canvasObj.transform.rotation = Quaternion.Euler(0, 0, -1); // hp�� ȸ���� ����
        canvasObj.GetComponentInChildren<Slider>().value = HP/FullHP;
    }

    void Die() // ����� EnemySpawn ��ũ��Ʈ �Լ� ȣ��
    {
        BasicSetting.instance.PlayerMoney += 1;
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
