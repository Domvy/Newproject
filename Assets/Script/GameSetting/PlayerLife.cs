using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject lifeObj;

    private void Start()
    {
        
    }

    void Update()
    {
        if (BasicSetting.instance.playerLife == 0)
        {
            GameOverUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }

        
    private void OnTriggerEnter(Collider other) //面倒矫 利 昏力,格见皑家
    {
        other.gameObject.SendMessage("Die");
        BasicSetting.instance.playerLife--;
        lifeObj = GameObject.Find("LifeObj");
        lifeObj.transform.GetChild(BasicSetting.instance.playerLife).gameObject.SetActive(false);
    }
}
