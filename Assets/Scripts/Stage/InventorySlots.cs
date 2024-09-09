using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Button removeButton;  // ���Կ��� �������� �����ϴ� ��ư

    public Item item;  // ���� ���Կ� �ִ� ������ ������

    // ���Կ� ������ �߰�
    public void AddItem(Item newItem)
    {
        item = newItem;

        item.itemImage = newItem.itemImage;  // �������� �������� ���Կ� ǥ��
    }

    // ������ ����
    public void ClearSlot()
    {
        item = null;
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
