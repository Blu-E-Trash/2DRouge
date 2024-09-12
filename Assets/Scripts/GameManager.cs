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

    //저장될 데이터
    public bool isUpgrade;      //승급
    public int playerGold;      //골드
    public int playerHp;        //채력
    public Item[] inventory;     //인벤은 바뀔수도 있음;

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
        //시메 온하는거 띄우기
        SystemMassage.text = "인벤토리가 꽉 찼습니다.";
    }
    public void RemoveItem(Item item)
    {
        inventory[1] = null;//임시로 1 넣어놨음
    }
}