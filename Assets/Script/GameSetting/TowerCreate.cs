using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreate : MonoBehaviour
{
    public GameObject normaltower; // 타워 프리팹
    public GameObject Powertower;
    public GameObject Speartower;
    Ray ray;
    RaycastHit hit;
    LayerMask layermask;


    public void NormalTowerCreate() // 타워 생성 설정
    {        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이캐스트 설정                
        layermask = LayerMask.GetMask("TurretPoint");
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                Instantiate(normaltower, hit.transform.position, Quaternion.identity);
            }
        }        
    }
    public void PowerTowerCreate() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이캐스트 설정                
        layermask = LayerMask.GetMask("TurretPoint");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                Instantiate(Powertower, hit.transform.position, Quaternion.identity);
            }
        }
    }
    public void SpearTowerCreate() // 타워 생성 설정
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이캐스트 설정                
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
