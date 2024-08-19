using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    GameObject mainInventory;
    [SerializeField]
    GameObject itemExplain;
    [SerializeField]
    public Image ItemImage;            //메인 인밴토리의 아이템 이미지

    private bool maintrue;
    private bool itemExTrue;

    ItemExplain ItemExplain;
    private void Start()
    {
        mainInventory.SetActive(false);
        itemExplain.SetActive(false);

        maintrue = false;
        itemExTrue = false;

        string ItemName = ItemImage.sprite.name;

    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("인밴 열려고 함");
            if (maintrue)
            {
                Debug.Log("인밴 열기");
                //다 꺼버리기
                mainInventory.SetActive(false);
                itemExplain.SetActive(false);
                maintrue = false;
            }
            else if (!maintrue) 
            {
                Debug.Log("인밴 닫기");
                //키기
                mainInventory.SetActive(true);
                maintrue = true;
            } 
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //끄기
            if (itemExTrue) 
            {
                //아이템 설명이 켜져있으면 아이템 설명만 끈다.
                itemExplain.SetActive(false);
                itemExTrue = false;
            }
            else if (!itemExTrue)
            {
                //아이템 설명이 꺼져있으면 메인 인벤토리를 끈다.
                mainInventory.SetActive(false);
                itemExTrue = false;
            }
        }
    }
    public void ItemExplainFunction(string ItemName)
    {
        if (ItemName == null)
        {
            Debug.Log("이미지 없음");
            itemExplain.SetActive(true);
            itemExTrue = true;
        }
        else if (ItemName != null)
        {
            Debug.Log(ItemImage.name);
            ItemExplain.ChangeImageAndText(ItemName);   
            itemExplain.SetActive(true);
            itemExTrue = true;
        }
    }
}
