using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSetting : MonoBehaviour
{
    // 싱글톤
    // 현재 클래스(GameManager)를 선언
    public static BasicSetting instance;
    public int PlayerMoney; // 플레이어 돈
    public int playerLife; // 플레이어 목숨
    public float timer = 0.0f; // 플레이 시간 기록
    public int timerSet = 0;


    // GameObject의 생명 주기 중 Awake는 생성 시 단 한번만 작동한다.
    // GameManager 클래스를 포함한 GameObject를 단 하나만 존재하도록 처리
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); // gameObject는 현재 Script가 포함된 GameObject를 의미한다.
                                 // 중복 될 경우 Destroy()를 사용하여 오브젝트를 제거
                                 

        DontDestroyOnLoad(gameObject); // 화면(Sceen) 전환이 일어나도 오브젝트가 삭제되지 않도록 해준다.
                                       // DonDestroyOnLoad 처리를 하지 않은 오브젝트는 화면 전환 시 삭제 됨
    }
    public void Call()
    {
        // 코드

    }



    private void Start()
    {
        PlayerMoney = 100;
        playerLife = 3;
    }
    private void Update()
    {       
        if(timerSet == 1)
        timer += Time.deltaTime;
        
        if (playerLife == 0) // 게임종료 시간 출력
        {            
            GameObject.Find("PlayTime").GetComponent<Text>().text = "Playtime : " + timer;
            playerLife = -1;
        }
    }
}
