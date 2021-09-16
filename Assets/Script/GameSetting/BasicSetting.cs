using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSetting : MonoBehaviour
{
    public float timer = 0.0f; // �÷��� �ð� ���
    public int playerLife;
    public float playerdietime;
   

    private void Start()
    {
        
    }
    private void Update()
    {
        playerLife = GameObject.Find("LifeTower").GetComponent<PlayerLife>().playerLife;        
        timer += Time.deltaTime;
        if (playerLife == 0) // �������� �ð� ���
        {            
            playerdietime = timer;
            GameObject.Find("PlayTime").GetComponent<Text>().text = "Playtime : " + playerdietime;
        }
    }
}
