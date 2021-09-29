using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerCreate : MonoBehaviour
{
    public GameObject normaltower; // Ÿ�� ������
    public GameObject Powertower;
    public GameObject Speartower;
    Ray ray;
    RaycastHit hit;
    LayerMask turretPoint;
    LayerMask ground;

    public GameObject notice;
    public Text text;


    public void NormalTowerCreate() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ĳ��Ʈ ����   
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint) && EventSystem.current.IsPointerOverGameObject())
            {
                BasicSetting.instance.PlayerMoney -= 10;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("��� ����");
                    BasicSetting.instance.PlayerMoney += 10;
                    notice.SetActive(true);
                    text.text = "��尡 �����մϴ�";
                }
                else
                    Instantiate(normaltower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground) && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Ÿ�� ��ġ �Ұ�");
                notice.SetActive(true);
                text.text = "Ÿ���� ��ġ�� �� ���� �����Դϴ�.";
            }

        }
    }
    public void PowerTowerCreate() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ĳ��Ʈ ���� 
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint) && EventSystem.current.IsPointerOverGameObject())
            {
                BasicSetting.instance.PlayerMoney -= 50;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("��� ����");
                    BasicSetting.instance.PlayerMoney += 50;
                    notice.SetActive(true);
                    text.text = "��尡 �����մϴ�";
                }
                else
                    Instantiate(Powertower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground) && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Ÿ�� ��ġ �Ұ�");
                notice.SetActive(true);
                text.text = "Ÿ���� ��ġ�� �� ���� �����Դϴ�..";
            }

        }
    }
    public void SpearTowerCreate() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ĳ��Ʈ ����
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint) && EventSystem.current.IsPointerOverGameObject())
            {
                BasicSetting.instance.PlayerMoney -= 30;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("��� ����");
                    BasicSetting.instance.PlayerMoney += 30;
                    notice.SetActive(true);
                    text.text = "��尡 �����մϴ�";
                }
                else
                    Instantiate(Speartower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground) && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Ÿ�� ��ġ �Ұ�");
                notice.SetActive(true);
                text.text = "Ÿ���� ��ġ�� �� ���� �����Դϴ�..";
            }

        }
    }


    public void NormalTowerCreateTouch() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //����ĳ��Ʈ ����   
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.touchCount == 1)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint))
            {
                BasicSetting.instance.PlayerMoney -= 10;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("��� ����");
                    BasicSetting.instance.PlayerMoney += 10;
                    notice.SetActive(true);
                    text.text = "��尡 �����մϴ�";
                }
                else
                    Instantiate(normaltower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                Debug.Log("Ÿ�� ��ġ �Ұ�");
                notice.SetActive(true);
                text.text = "Ÿ���� ��ġ�� �� ���� �����Դϴ�.";
            }
        }
    }
    public void PowerTowerCreateTouch() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //����ĳ��Ʈ ���� 
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.touchCount == 1)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint))
            {
                BasicSetting.instance.PlayerMoney -= 50;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("��� ����");
                    BasicSetting.instance.PlayerMoney += 50;
                    notice.SetActive(true);
                    text.text = "��尡 �����մϴ�";
                }
                else
                    Instantiate(Powertower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                Debug.Log("Ÿ�� ��ġ �Ұ�");
                notice.SetActive(true);
                text.text = "Ÿ���� ��ġ�� �� ���� �����Դϴ�..";
            }

        }
    }
    public void SpearTowerCreateTouch() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //����ĳ��Ʈ ����
        turretPoint = LayerMask.GetMask("TurretPoint");
        ground = LayerMask.GetMask("Ground");
        if (Input.touchCount == 1)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint))
            {
                BasicSetting.instance.PlayerMoney -= 30;
                if (BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("��� ����");
                    BasicSetting.instance.PlayerMoney += 30;
                    notice.SetActive(true);
                    text.text = "��尡 �����մϴ�";
                }
                else
                    Instantiate(Speartower, hit.transform.position, Quaternion.identity);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                Debug.Log("Ÿ�� ��ġ �Ұ�");
                notice.SetActive(true);
                text.text = "Ÿ���� ��ġ�� �� ���� �����Դϴ�..";
            }

        }
    }
}
