using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int playerLife; // �÷��̾� ���
    public GameObject lifeUI;

    private void Start()
    {
        playerLife = 3;
    }

    void Update()
    {
        GameObject.Find("Life").GetComponent<Text>().text = "Life : " + playerLife; // UI�� ���ǥ��
        if (playerLife == 0)
        {
            lifeUI.SetActive(true);  
        }
    }

        
    private void OnTriggerEnter(Collider other) //�浹�� �� ����,�������
    {
        other.gameObject.SendMessage("Die");
        playerLife--;
    }
}
