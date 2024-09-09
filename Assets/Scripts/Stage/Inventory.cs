using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public List<Item> inventoryItems = new List<Item>(); //�κ��丮�� ����ִ� ������
    public int maxSlots = 6; // �ִ� ���� ����

    private InventorySlots inventorySlots;

    private PlayerStatus playerStatus;

    private void Awake()
    {
        // �̱��� ���� ����: �̹� �ν��Ͻ��� �����Ѵٸ� �ı�, �ƴϸ� �ν��Ͻ� ����
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
            item.ApplyEffect(playerStatus); // ������ ȿ�� ����
        }
    }
    //������ �߰�
    public void Add(Item item)
    {
        inventoryItems.Add(item);
        inventorySlots.AddItem(item);
        item.ApplyEffect(playerStatus);
        Debug.Log(item.itemName + " added to inventory.");
        
    }
    //������ ����
    public void Remove(Item item)
    {
        inventoryItems.Remove(item);
        inventorySlots.ClearSlot();
        item.RemoveEffect(playerStatus);
        
    }
}
