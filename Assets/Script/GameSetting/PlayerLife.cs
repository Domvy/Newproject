using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int playerLife = 3; // �÷��̾� ���

    void Update()
    {
        if(playerLife == 0)
        {
            Debug.Log("Game Over");
        }
    }
    
    private void OnTriggerEnter(Collider other) //�浹�� �� ����,�������
    {        
        playerLife--;
    }
}
