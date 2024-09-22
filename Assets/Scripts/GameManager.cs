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
    private GameObject systemMassage;
    [SerializeField]
    private PlayerMove playerMove;
    [SerializeField]
    private PlayerStatus playerStatus;
    [SerializeField]
    private Shop shop;
    [SerializeField]
    private StatusUI statusUI;
    [SerializeField]
    private GameObject gameOverUI;
    public bool isGameOver;


    [SerializeField]
    private Transform playerpos;
    //저장될 데이터
    public bool isUpgrade;      //승급
    public int playerGold;      //골드
    public int playerMaxHp;     //최대채력
    public int playerHp;        //채력
    public Item[] inventory = new Item[6];     //인벤은 바뀔수도 있음;
    private float Setfalse;
    [SerializeField]
    private InventoryUI inventoryUI;


    private void Awake()
    {
        systemMassage.SetActive(false);
        gameOverUI.SetActive(false);
        isGameOver = false;
        if (Instance == null) { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
           Destroy(gameObject);
    }
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
        statusUI.BasicUIUpdate();
    }
    public void AddItemtoInventory()
    {
        for (int i = 0; i < 6; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = shop.selectedItem;
                if (inventory[i].itemName == "Beer" || inventory[i].itemName == "Bread" || inventory[i].itemName == "Fish Steak" || inventory[i].itemName == "Monster Meat")
                {
                    ApplyEffect(inventory[i]);
                    inventoryUI.IselectedItem = inventory[i];
                    inventoryUI.RemoveItem();
                    return;
                }
                inventoryUI.UpdateInventoryUI(inventory[i],i);

                ApplyEffect(inventory[i]);
                inventoryUI.slotButton[i].onClick.AddListener(() => inventoryUI.SelecteItem(inventory[i]));

                return;
            }
        }
        systemMassage.SetActive(true);
        Setfalse += Time.deltaTime;
        SystemMassage.text = "인벤토리가 꽉 찼습니다.";
        if (Setfalse == 2.0)
        {
            systemMassage.SetActive(false);
            Setfalse = 0f;
        }
    }

    public void ApplyEffect(Item item)
    {

        playerStatus.Damage += item.attackBonus;
        playerStatus.maxHp += item.maxHpBonus;
        playerStatus.Hp += item.hpHeal;
        if (playerStatus.Hp > playerStatus.maxHp)
        {
            playerStatus.Hp = playerStatus.maxHp;
        }
        playerStatus.CritDam += item.critDamBonus;
        playerStatus.CritPer += item.critperBonus;
        playerStatus.goldBonus += item.getGoldBonus;
        playerMove.jumpPower += item.jumpBonus;
        playerMove.movePower += item.speedBonus;
    }

    public void RemoveEffect(Item item)
    {
        playerStatus.Damage -= item.attackBonus;
        playerStatus.maxHp -= item.maxHpBonus;
        playerStatus.CritDam -= item.critDamBonus;
        playerStatus.CritPer -= item.critperBonus;
        playerStatus.goldBonus -= item.getGoldBonus;
        playerMove.jumpPower -= item.jumpBonus;
        playerMove.movePower -= item.speedBonus;
    }
}