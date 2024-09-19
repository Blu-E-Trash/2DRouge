using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private Text SystemMassage;
    [SerializeField]
    private PlayerMove playerMove;
    [SerializeField]
    private PlayerStatus playerStatus;
    [SerializeField]
    private StatusUI statusUI;
    [SerializeField]
    private GameObject gameOverUI;
    public bool isGameOver;

    [SerializeField]
    private Transform playerpos;
    //����� ������
    public bool isUpgrade;      //�±�
    public int playerGold;      //���
    public int playerMaxHp;     //�ִ�ä��
    public int playerHp;        //ä��
    public Item[] inventory;     //�κ��� �ٲ���� ����;
    private InventoryUI inventoryUI;


    private void Awake()
    {
        gameOverUI.SetActive(false);
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
            gameOverUI.SetActive(true);
        }
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            isGameOver = false;
            SceneManager.LoadScene("FirstSceen");
        }
        if (playerpos.position.y < -15)
        {
            fallDamage();
        }
    }
    public void getAttacked()
    {
        if (!isGameOver)
        {
            if (playerMove.immortal)
            {
                return;
            }
            if (playerMove.isDash)
            {
                return;
            }

            playerMove.immortal = true;
            StartCoroutine(ImmotalCorutine());
            playerStatus.Hp -= 1;
            playerMove.animator.SetTrigger("doHit");
            HpSyncronization();
            statusUI.BasicUIUpdate();
            statusUI.MainUIUpdate();
        }
    }
    public void DataSynchronization()
    {
        HpSyncronization();
        UpgradeSyncronization();
        GoldSyncronization();
    }
    public void HpSyncronization()
    {
        playerHp = playerStatus.Hp;
        playerMaxHp = playerStatus.maxHp;
    }
    public void UpgradeSyncronization()
    {
        if (playerStatus.UpgradCount != 0)
        {
            isUpgrade = true;
        }
        else
            isUpgrade = false;
    }
    public void GoldSyncronization()
    {
        playerGold = playerStatus.gold;
    }
    IEnumerator ImmotalCorutine()
    {
        yield return new WaitForSeconds(1);
        HpSyncronization();
        playerMove.immortal=false;
    }
    public void fallDamage()
    {
        playerStatus.Hp -= 1;
        playerpos.position = new Vector3(-10, -3, -1);
        HpSyncronization();
    }
    public void AddItemtoInventory(Item item)
    {
        for (int i = 0; i < 6; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                inventoryUI.UpdateInventoryUI();
                return;
            }
        }
        //�ø� ���ϴ°� ����
        SystemMassage.text = "�κ��丮�� �� á���ϴ�.";
    }
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < 6; i++)
        {
            if (item.itemName == inventory[i].itemName)
            {
                inventory[i] = null;
            }
        }
        inventoryUI.ClearSlot(item);
    }
}