using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public List<Item> inventoryItems = new List<Item>(); //�κ��丮�� ����ִ� ������
    public int maxSlots = 6; // �ִ� ���� ����

    public InventorySlots inventorySlots;

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
            item.ApplyEffect(item); // ������ ȿ�� ����
        }
    }
    //������ �߰�
    public void Add(Item item)
    {
        for (int i = 0; i < maxSlots; i++)
        {
            if (inventoryItems[i]==null)
            {
                inventoryItems.Add(item);
                inventorySlots.AddItem(item);
                item.ApplyEffect(item);
                Debug.Log(item.itemName + " added to inventory.");
            }
        }
    }
    //������ ����
    public void Remove(Item item)
    {
        inventoryItems.Remove(item);
        inventorySlots.ClearSlot();
        item.RemoveEffect(item);
        
    }
}
