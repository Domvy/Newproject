using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreate : MonoBehaviour
{
    public GameObject normaltower; // Ÿ�� ������
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
}
