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
    LayerMask layermask;
    LayerMask layermask2;

    public GameObject notice;
    public Text text;


    public void NormalTowerCreate() // Ÿ�� ���� ����
    {        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ĳ��Ʈ ����                
        layermask = LayerMask.GetMask("TurretPoint");
        layermask2 = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask) && EventSystem.current.IsPointerOverGameObject())
            {
                BasicSetting.instance.PlayerMoney -= 10;
                if(BasicSetting.instance.PlayerMoney < 0)
                {
                    Debug.Log("��� ����");
                    BasicSetting.instance.PlayerMoney += 10;
                    notice.SetActive(true);
                    text.text = "��尡 �����մϴ�";                    
                }
                else
                    Instantiate(normaltower, hit.transform.position, Quaternion.identity);                
            }
            else if(Physics.Raycast(ray, out hit, Mathf.Infinity, layermask2) && EventSystem.current.IsPointerOverGameObject())
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
        layermask = LayerMask.GetMask("TurretPoint");
        layermask2 = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask) && EventSystem.current.IsPointerOverGameObject())
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
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask2) && EventSystem.current.IsPointerOverGameObject())
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
        layermask = LayerMask.GetMask("TurretPoint");
        layermask2 = LayerMask.GetMask("Ground");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask) && EventSystem.current.IsPointerOverGameObject())
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
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask2) && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Ÿ�� ��ġ �Ұ�");
                notice.SetActive(true);
                text.text = "Ÿ���� ��ġ�� �� ���� �����Դϴ�..";
            }

        }
    }
}
