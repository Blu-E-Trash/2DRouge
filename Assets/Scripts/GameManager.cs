using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private Text SystemMassage;        

    public bool isGameOver;

    //����� ������
    public bool isUpgrade;      //�±�
    public int playerGold;      //���
    public int playerHp;        //ä��
    public Item[] inventory;     //�κ��� �ٲ���� ����;

    private void Awake()
    {
        isGameOver = false;
        if (Instance == null) { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
           Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
        
        if(isGameOver&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Lobby");
        }
    }
    public void getAttacked(int Damage)
    {
        playerHp -= Damage;
        if (playerHp <= 0)
        {
            isGameOver = true;
        }
    }
    public void AddItemtoInventory(Item item)
    {
        for (int i = 0; i < 6; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                return;
            }
        }
        //�ø� ���ϴ°� ����
        SystemMassage.text = "�κ��丮�� �� á���ϴ�.";
    }
    public void RemoveItem(Item item)
    {
        inventory[1] = null;//�ӽ÷� 1 �־����
    }
}