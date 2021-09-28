using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSetting : MonoBehaviour
{
    // �̱���
    // ���� Ŭ����(GameManager)�� ����
    public static BasicSetting instance;
    public int PlayerMoney; // �÷��̾� ��
    public int playerLife; // �÷��̾� ���
    public float timer = 0.0f; // �÷��� �ð� ���
    public int timerSet = 0;


    // GameObject�� ���� �ֱ� �� Awake�� ���� �� �� �ѹ��� �۵��Ѵ�.
    // GameManager Ŭ������ ������ GameObject�� �� �ϳ��� �����ϵ��� ó��
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); // gameObject�� ���� Script�� ���Ե� GameObject�� �ǹ��Ѵ�.
                                 // �ߺ� �� ��� Destroy()�� ����Ͽ� ������Ʈ�� ����
                                 

        DontDestroyOnLoad(gameObject); // ȭ��(Sceen) ��ȯ�� �Ͼ�� ������Ʈ�� �������� �ʵ��� ���ش�.
                                       // DonDestroyOnLoad ó���� ���� ���� ������Ʈ�� ȭ�� ��ȯ �� ���� ��
    }
    public void Call()
    {
        // �ڵ�

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
        
        if (playerLife == 0) // �������� �ð� ���
        {            
            GameObject.Find("PlayTime").GetComponent<Text>().text = "Playtime : " + timer;
            playerLife = -1;
        }
    }
}
