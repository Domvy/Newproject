using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int playerLife = 3; // 敲饭捞绢 格见

    void Update()
    {
        if(playerLife == 0)
        {
            Debug.Log("Game Over");
        }
    }
    
    private void OnTriggerEnter(Collider other) //面倒矫 利 昏力,格见皑家
    {        
        playerLife--;
    }
}
