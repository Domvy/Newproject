using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSetting : MonoBehaviour
{
    // ���� Ŭ����(GameManager)�� ����
    public static BasicSetting instance;
    public int PlayerMoney;

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

    public float timer = 0.0f; // �÷��� �ð� ���
    public int playerLife;
    public float playerdietime;
    public Text money;

    private void Start()
    {
        PlayerMoney = 100;
    }
    private void Update()
    {
        playerLife = GameObject.Find("LifeTower").GetComponent<PlayerLife>().playerLife;        
        timer += Time.deltaTime;
        if (playerLife == 0) // �������� �ð� ���
        {            
            playerdietime = timer;
            GameObject.Find("PlayTime").GetComponent<Text>().text = "Playtime : " + playerdietime;
        }

        money.text = "Money : " + PlayerMoney;
    }
}
