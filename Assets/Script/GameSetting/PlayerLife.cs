using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int playerLife; // 敲饭捞绢 格见
    public GameObject lifeUI;

    private void Start()
    {
        playerLife = 3;
    }

    void Update()
    {
        GameObject.Find("Life").GetComponent<Text>().text = "Life : " + playerLife; // UI俊 格见钎矫
        if (playerLife == 0)
        {
            lifeUI.SetActive(true);  
        }
    }

        
    private void OnTriggerEnter(Collider other) //面倒矫 利 昏力,格见皑家
    {
        other.gameObject.SendMessage("Die");
        playerLife--;
    }
}
