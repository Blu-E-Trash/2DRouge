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
    public Image ItemImage;            //���� �ι��丮�� ������ �̹���

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
            Debug.Log("�ι� ������ ��");
            if (maintrue)
            {
                Debug.Log("�ι� ����");
                //�� ��������
                mainInventory.SetActive(false);
                itemExplain.SetActive(false);
                maintrue = false;
            }
            else if (!maintrue) 
            {
                Debug.Log("�ι� �ݱ�");
                //Ű��
                mainInventory.SetActive(true);
                maintrue = true;
            } 
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //����
            if (itemExTrue) 
            {
                //������ ������ ���������� ������ ���� ����.
                itemExplain.SetActive(false);
                itemExTrue = false;
            }
            else if (!itemExTrue)
            {
                //������ ������ ���������� ���� �κ��丮�� ����.
                mainInventory.SetActive(false);
                itemExTrue = false;
            }
        }
    }
    public void ItemExplainFunction(string ItemName)
    {
        if (ItemName == null)
        {
            Debug.Log("�̹��� ����");
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
