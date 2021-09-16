using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavi : MonoBehaviour
{
    //네비게이션 스크립트
    NavMeshAgent agent;
    public Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        targetPosition = GameObject.FindWithTag("EndPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetPosition.position);
        if(gameObject.transform.position == targetPosition.position)
        {
            Debug.Log("EndPoint!");
            Destroy(gameObject);
        }
    }


    public void OnDestroy()
    {
        Debug.Log("Enemy Dead!");
    }
}
