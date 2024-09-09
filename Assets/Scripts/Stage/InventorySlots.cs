using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Button removeButton;  // 슬롯에서 아이템을 제거하는 버튼

    public Item item;  // 현재 슬롯에 있는 아이템 데이터

    // 슬롯에 아이템 추가
    public void AddItem(Item newItem)
    {
        item = newItem;

        item.itemImage = newItem.itemImage;  // 아이템의 아이콘을 슬롯에 표시
    }

    // 슬롯을 비우기
    public void ClearSlot()
    {
        item = null;
    }

    // 제거 버튼을 눌렀을 때 호출되는 메서드
    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(item);  // 인벤토리에서 현재 아이템을 제거
    }

    // 슬롯에 있는 아이템을 사용하는 메서드
    public void UseItem()
    {
        if (item != null)
        {
            //item.Use();  // 아이템을 사용 (아이템의 사용 기능이 구현되어야 함)
        }
    }
}
