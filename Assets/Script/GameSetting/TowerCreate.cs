using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerCreate : MonoBehaviour
{
    public GameObject normaltower; // 타워 프리팹
    public GameObject Powertower;
    public GameObject Speartower;
    Ray ray;
    RaycastHit hit;
    LayerMask turretPoint;
    LayerMask ground;

    public GameObject notice;
    public Text text;


    public void NormalTowerCreate() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이캐스트 설정   
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint) && EventSystem.current.IsPointerOverGameObject())
            {
                BasicSetting.instance.PlayerMoney -= 10;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("골드 부족");
                    BasicSetting.instance.PlayerMoney += 10;
                    notice.SetActive(true);
                    text.text = "골드가 부족합니다";
                }
                else
                    Instantiate(normaltower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground) && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("타워 배치 불가");
                notice.SetActive(true);
                text.text = "타워를 배치할 수 없는 지역입니다.";
            }

        }
    }
    public void PowerTowerCreate() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이캐스트 설정 
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint) && EventSystem.current.IsPointerOverGameObject())
            {
                BasicSetting.instance.PlayerMoney -= 50;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("골드 부족");
                    BasicSetting.instance.PlayerMoney += 50;
                    notice.SetActive(true);
                    text.text = "골드가 부족합니다";
                }
                else
                    Instantiate(Powertower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground) && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("타워 배치 불가");
                notice.SetActive(true);
                text.text = "타워를 배치할 수 없는 지역입니다..";
            }

        }
    }
    public void SpearTowerCreate() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이캐스트 설정
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint) && EventSystem.current.IsPointerOverGameObject())
            {
                BasicSetting.instance.PlayerMoney -= 30;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("골드 부족");
                    BasicSetting.instance.PlayerMoney += 30;
                    notice.SetActive(true);
                    text.text = "골드가 부족합니다";
                }
                else
                    Instantiate(Speartower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground) && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("타워 배치 불가");
                notice.SetActive(true);
                text.text = "타워를 배치할 수 없는 지역입니다..";
            }

        }
    }


    public void NormalTowerCreateTouch() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //레이캐스트 설정   
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.touchCount == 1)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint))
            {
                BasicSetting.instance.PlayerMoney -= 10;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("골드 부족");
                    BasicSetting.instance.PlayerMoney += 10;
                    notice.SetActive(true);
                    text.text = "골드가 부족합니다";
                }
                else
                    Instantiate(normaltower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                Debug.Log("타워 배치 불가");
                notice.SetActive(true);
                text.text = "타워를 배치할 수 없는 지역입니다.";
            }
        }
    }
    public void PowerTowerCreateTouch() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //레이캐스트 설정 
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.touchCount == 1)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint))
            {
                BasicSetting.instance.PlayerMoney -= 50;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("골드 부족");
                    BasicSetting.instance.PlayerMoney += 50;
                    notice.SetActive(true);
                    text.text = "골드가 부족합니다";
                }
                else
                    Instantiate(Powertower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                Debug.Log("타워 배치 불가");
                notice.SetActive(true);
                text.text = "타워를 배치할 수 없는 지역입니다..";
            }

        }
    }
    public void SpearTowerCreateTouch() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //레이캐스트 설정
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.touchCount == 1)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint))
            {
                BasicSetting.instance.PlayerMoney -= 30;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("골드 부족");
                    BasicSetting.instance.PlayerMoney += 30;
                    notice.SetActive(true);
                    text.text = "골드가 부족합니다";
                }
                else
                    Instantiate(Speartower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                Debug.Log("타워 배치 불가");
                notice.SetActive(true);
                text.text = "타워를 배치할 수 없는 지역입니다..";
            }

        }
    }
}
