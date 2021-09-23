using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingPos : MonoBehaviour
{
    public Material defaultcolor;
    public Material canbuildcolor;

    private void OnMouseOver()
    {
        gameObject.GetComponent<MeshRenderer>().material = canbuildcolor;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = defaultcolor;
    }
}
