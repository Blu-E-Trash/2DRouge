using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] inventory = new Item[6];
    [SerializeField]
    private Shop shop;
    [SerializeField]
    private InventoryUI inventoryUI;
    [SerializeField]
    private Text SystemMassage;
    [SerializeField]
    private GameObject systemMassage;

    public GameManager gameManager;
    private PlayerStatus playerStatus;
    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void AddItemtoInventory()
    {
        for (int i = 0; i < 6; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = shop.selectedItem;
                inventoryUI.UpdateInventoryUI(inventory[i], i);
                inventoryUI.slotButton[i].onClick.AddListener(() => inventoryUI.SelecteItem(inventory[i]));
                playerStatus.ApplyEffect(inventory[i]);
                gameManager.InventorySyncronization();
                return;
            }
        }
        systemMassage.SetActive(true);
        Invoke("TurnOffMassage",1f);
        SystemMassage.text = "¿Œ∫•≈‰∏Æ∞° ≤À √°Ω¿¥œ¥Ÿ.";
    }
    private void TurnOffMassage()
    {
        systemMassage.SetActive(false);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        gameManager = FindAnyObjectByType<GameManager>();
        
        for (int i = 0; i < 6; i++)
        {
            int temp = i;
            if (inventory[temp] != null)
            {
                inventoryUI.slotButton[i].onClick.AddListener(() => inventoryUI.SelecteItem(inventory[temp]));
            }
            else if (inventory[temp] == null)
            {
                continue;
            }
        }
    }
}
