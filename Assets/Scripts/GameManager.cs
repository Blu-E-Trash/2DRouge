using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using System.Net;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerStatus playerStatus;
    public StatusUI statusUI;
    public GameObject gameOverUI;
    public Inventory inventoryScript;
    public InventoryUI inventoryUI;
    public bool isGameOver;
    public bool isVictory;
    private GameObject player;
    private Text StageNum;

    //저장될 데이터
    public bool isUpgrade;      //승급
    public int playerGold;      //골드
    public int playerMaxHp;     //최대채력
    public int playerHp;        //채력
    public Item[] inventory = new Item[6];     //인벤은 바뀔수도 있음;



    
    private void Awake()
    {
        if (Instance == null) { 
            Instance = this;
        }
        else if(Instance != this)
           Destroy(gameObject);
        
        DontDestroyOnLoad(this.gameObject);
        isGameOver = false;
        isVictory=false;
    }
    void Update()
    {
        if(playerStatus.Hp <= 0)
        {
            isGameOver = true;
        }
        if (isGameOver)
        {
            gameOverUI.SetActive(true);
        }
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            isGameOver = false;
            Destroy(gameObject);
            SceneManager.LoadScene("FirstSceen");
        }
    }
    public void SetPlayerStatus(PlayerStatus playerStatus)
    {
        this.playerStatus= playerStatus;
    }
    public void DataSynchronization()
    {
        HpSyncronization();
        GoldSyncronization();
        InventorySyncronization();
    }
    public void HpSyncronization()
    {
        playerHp = playerStatus.Hp;
        playerMaxHp = playerStatus.maxHp;
    }
    public void UpgradeSyncronization()
    {
        isUpgrade = true;
    }
    public void GoldSyncronization()
    {
        playerGold = playerStatus.gold;
    }
    public void InventorySyncronization()
    {
        for (int i = 0; i < 6; i++)
        {
            if(inventoryScript.inventory[i]!=null)
            {
                inventory[i] = inventoryScript.inventory[i];
            }
            else if (inventoryScript.inventory[i] == null)
            {
                inventory[i] = null;
            }
        }
    }
    public void PlayerDataSyncronization()
    {
        playerStatus.Hp= playerHp;
        Debug.Log("HP");
        playerStatus.maxHp= playerMaxHp;
        Debug.Log("maxHp");
        playerStatus.gold = playerGold;
        Debug.Log("gold");
        if (isUpgrade)
        {
            playerStatus.ClassUpgrade();

        }
        Debug.Log("Upgrade");
        for (int i = 0; i < 6; i++)
        {
            if (inventory[i] == null)
            {
                continue;
            }
            inventoryScript.inventory[i] = inventory[i];
            playerStatus.ApplyEffect(inventory[i]);
            inventoryUI.UpdateInventoryUI(inventory[i], i);
        }
        Debug.Log("inventory");
        statusUI.BasicUIUpdate();
        statusUI.MainUIUpdate();
        Debug.Log("UI");
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        DataSynchronization();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("BS");
        statusUI = GameObject.Find("Canvas").transform.Find("InventoryManager").transform.Find("CharacterStatus").transform.Find("StatusUI").GetComponent<StatusUI>();
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOverUI").gameObject;
        gameOverUI.SetActive(false);
        inventoryScript = player.GetComponent<Inventory>();
        inventoryUI = FindAnyObjectByType<InventoryUI>();
        playerStatus = player.GetComponent<PlayerStatus>();
        StageNum = GameObject.Find("Canvas").transform.Find("StageUI").transform.Find("StageBaseUI").transform.Find("StageText").GetComponent<Text>();
        if (scene.name == "Stage1")
        {
            DataSynchronization();
            StageNum.text = "Stage1 : 숲 초입";
        }
        else if(scene.name == "Stage2")
        {
            StageNum.text = "Stage2 : 죽은 숲";
        }
        else if(scene.name == "Stage3")
        {
            StageNum.text = "Kill the Boss!";
        }
        PlayerDataSyncronization();
    }
}