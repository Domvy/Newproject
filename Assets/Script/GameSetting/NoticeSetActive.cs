using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeSetActive : MonoBehaviour
{
    public float timer;
    public int waitingtime = 3;

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingtime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        timer = 0.0f;
    }
}
