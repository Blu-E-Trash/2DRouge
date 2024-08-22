using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    [SerializeField]
    public Image ItemImage;  // ���Կ� ǥ�õ� �������� �̹���
    
    public Button removeButton;  // ���Կ��� �������� �����ϴ� ��ư

    public Item item;  // ���� ���Կ� �ִ� ������ ������

    // ���Կ� ������ �߰�
    public void AddItem(Item newItem)
    {
        item = newItem;

        ItemImage.sprite = item.itemImage;  // �������� �������� ���Կ� ǥ��
        ItemImage.enabled = true;  // ������ �̹����� Ȱ��ȭ
        removeButton.interactable = true;  // ���� ��ư�� Ȱ��ȭ
    }

    // ������ ����
    public void ClearSlot()
    {
        item = null;

        ItemImage.sprite = null;  // �������� ����
        ItemImage.enabled = false;  // ������ �̹����� ��Ȱ��ȭ
        removeButton.interactable = false;  // ���� ��ư�� ��Ȱ��ȭ
    }

    // ���� ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(item);  // �κ��丮���� ���� �������� ����
    }

    // ���Կ� �ִ� �������� ����ϴ� �޼���
    public void UseItem()
    {
        if (item != null)
        {
            //item.Use();  // �������� ��� (�������� ��� ����� �����Ǿ�� ��)
        }
    }
}
