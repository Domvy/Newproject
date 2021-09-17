using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreate : MonoBehaviour
{
    public GameObject normaltower; // Ÿ�� ������
    public GameObject Powertower;
    public GameObject Speartower;
    Ray ray;
    RaycastHit hit;
    LayerMask layermask;


    public void NormalTowerCreate() // Ÿ�� ���� ����
    {        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ĳ��Ʈ ����                
        layermask = LayerMask.GetMask("TurretPoint");
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                Instantiate(normaltower, hit.transform.position, Quaternion.identity);
            }
        }        
    }
    public void PowerTowerCreate() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ĳ��Ʈ ����                
        layermask = LayerMask.GetMask("TurretPoint");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                Instantiate(Powertower, hit.transform.position, Quaternion.identity);
            }
        }
    }
    public void SpearTowerCreate() // Ÿ�� ���� ����
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ĳ��Ʈ ����                
        layermask = LayerMask.GetMask("TurretPoint");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                Instantiate(Speartower, hit.transform.position, Quaternion.identity);
            }
        }
    }
}
