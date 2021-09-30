using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public int powerUpCount = 0;
    public int RangeUpCount = 0;
    public Text notice;

    public GameObject UpgradeButton;
    public GameObject UpgradeButton2;
    public GameObject UpgradeButton3;

    private void Start()
    {
        powerUpCount = 0;
        RangeUpCount = 0;
    }

    public void TowerRangeUpgrade()
    {
        if (BasicSetting.instance.PlayerMoney >= 100)
        {
            UpgradeButton.GetComponent<Button>().interactable = false;
            BasicSetting.instance.PlayerMoney -= 100;
            RangeUpCount++;
        }
        else
        {
            notice.text = "골드가 부족합니다";
        }
    }

    public void GoldUp()
    {
        if (BasicSetting.instance.PlayerMoney >= 100)
        {
            BasicSetting.instance.PlayerMoney -= 100;
            GameObject.Find("Controller").GetComponent<EnemySpawn>().goldUpgradeCount++;
            UpgradeButton2.GetComponent<Button>().interactable = false;
        }
        else
        {
            notice.text = "골드가 부족합니다";
        }
    }

    public void PowerUp()
    {
        if (BasicSetting.instance.PlayerMoney >= 150 && powerUpCount < 3)
        {
            BasicSetting.instance.PlayerMoney -= 150;
            powerUpCount++;
            if (powerUpCount == 3)
            {
                UpgradeButton3.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            notice.text = "골드가 부족합니다";
        }
    }



}
