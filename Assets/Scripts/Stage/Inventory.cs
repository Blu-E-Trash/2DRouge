using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public List<Item> inventoryItems = new List<Item>(); //인벤토리에 들어있는 아이템
    public int maxSlots = 6; // 최대 슬롯 개수

    private InventorySlots inventorySlots;

    private PlayerStatus playerStatus;

    private void Awake()
    {
        // 싱글톤 패턴 구현: 이미 인스턴스가 존재한다면 파괴, 아니면 인스턴스 설정
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        playerStatus = FindObjectOfType<PlayerStatus>();

        foreach (Item item in inventoryItems)
        {
            item.ApplyEffect(playerStatus); // 아이템 효과 적용
        }
    }
    //아이템 추가
    public void Add(Item item)
    {
        inventoryItems.Add(item);
        inventorySlots.AddItem(item);
        item.ApplyEffect(playerStatus);
        Debug.Log(item.itemName + " added to inventory.");
        
    }
    //아이템 제거
    public void Remove(Item item)
    {
        inventoryItems.Remove(item);
        inventorySlots.ClearSlot();
        item.RemoveEffect(playerStatus);
        
    }
}
