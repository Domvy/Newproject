using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public GameObject lifeUI;

    private void Start()
    {
        
    }

    void Update()
    {
        GameObject.Find("Life").GetComponent<Text>().text = "Life : " + BasicSetting.instance.playerLife; // UI俊 格见钎矫
        if (BasicSetting.instance.playerLife == 0)
        {
            lifeUI.SetActive(true);  
        }
    }

        
    private void OnTriggerEnter(Collider other) //面倒矫 利 昏力,格见皑家
    {
        other.gameObject.SendMessage("Die");
        BasicSetting.instance.playerLife--;
    }
}
