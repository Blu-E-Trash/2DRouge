using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private bool itemExTrue;

    [SerializeField]
    public Image ExItemImage; // �������� �̹���
    [SerializeField]
    public Text ExItemNameText; //�������� �̸� �ؽ�Ʈ
    [SerializeField]
    public Text ExItemDescriptionText; //���Ӽ� �ý�Ʈ
    [SerializeField]
    public Text ExItemText; // �������� ȿ�� �ؽ�Ʈ
    [SerializeField]
    GameObject SellingItemExplain;
    [SerializeField]
    public GameObject ShopUI;
    [SerializeField]
    public GameObject SystemMassageGO;
    [SerializeField]
    public Text systemMassage;
    [SerializeField]
    public Text itemPrice;
    [SerializeField]
    private Inventory inventory;
    public List<Item> availableItems;  // �������� �Ǹ� ������ ������ ���
    public Item[] sellSlots;           // �Ǹ� ���� ����ϴ� UI ���Ե�
    [SerializeField]
    private ShopButton[] shopbt;
    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private PlayerStatus playerStatus;
    [SerializeField]
    private InventoryUI inventoryUI;
    [SerializeField]
    private ShopOpen shopOpen;
    [SerializeField]
    private StatusUI statusUI;
    public Item selectedItem;         // �÷��̾ ������ ������
    private int SelectNum;


    private GameManager gameManager;

    private void Awake()
    { 
        SellingItemExplain.SetActive(false);
        ShopUI.SetActive(false);
        playerStatus = FindObjectOfType<PlayerStatus>();
        PopulateSellSlots();
    }
    private void Update()
    {
        if (!inventoryUI.maintrue)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!itemExTrue)
                {
                    ShopUI.SetActive(false);
                    shopOpen.isOpening = false;
                }
                else if (itemExTrue)
                {
                    SellingItemExplain.SetActive(false);
                    itemExTrue = false;
                }
            }
        }
    }
    private void PopulateSellSlots()
    {
        for (int i = 0; i < sellSlots.Length; i++)
        {
            int temp = i;
            int randomItem = UnityEngine.Random.Range(0, availableItems.Count);
            sellSlots[i] = availableItems[randomItem];
            shopbt[i].ChangeImage(sellSlots[i]);
            buttons[i].onClick.AddListener(()=>SelectItem(sellSlots[temp],temp));
        }
    }

    public void SelectItem(Item item,int i)
    {
        if (item != null)
        {
            selectedItem = item;                             
            itemPrice.text = "$" + selectedItem.itemPrice.ToString(); 
            
            ChangeText(selectedItem.itemName);                  
            ExItemImage.sprite = selectedItem.itemImage;
            SellingItemExplain.SetActive(true);
            itemExTrue = true;
            SelectNum = i;
        }
    }
    public void PurchaseSelectedItem()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        if (playerStatus.gold >= selectedItem.itemPrice)
        {
            if (inventory.inventoryCount >= 6)
            {
                inventory.InventoryIsFull();
                return;
            }
            if (selectedItem.itemName == "Beer" || selectedItem.itemName == "Bread" || selectedItem.itemName == "Fish Steak" || selectedItem.itemName == "Monster Meat")
            {
                playerStatus.ApplyEffect(selectedItem);
                playerStatus.gold -= selectedItem.itemPrice;
                statusUI.BasicUIUpdate();
                statusUI.MainUIUpdate();
                gameManager.GoldSyncronization();
                gameManager.HpSyncronization();

                sellSlots[SelectNum]= null;
                selectedItem = null;
                shopbt[SelectNum].ChangeImage(sellSlots[SelectNum]);
                SellingItemExplain.SetActive(false);
            }
            else
            {
                inventory.AddItemtoInventory();
                playerStatus.gold -= selectedItem.itemPrice;
                statusUI.BasicUIUpdate();
                gameManager.InventorySyncronization();
                gameManager.GoldSyncronization();

                shopbt[SelectNum].sellItemImage.sprite = null;
                sellSlots[SelectNum] = null;
                selectedItem = null;
                SellingItemExplain.SetActive(false);
            }
        }
        else
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "��尡 �����մϴ�.";
            Invoke("Out", 2f);
        }
    }

    public void closeShop()
    {
        SellingItemExplain.SetActive(false);
        ShopUI.SetActive(false);
    }
    private void Out()
    {
        SystemMassageGO.SetActive(false);
    }
    private void ChangeText(string ItemName)
    {
        switch (ItemName)
        {
            case "Rune Stone":
                ExItemNameText.text = "�齺��";
                ExItemDescriptionText.text = "��� ���� ������ ���ɰ���";
                ExItemText.text = "���ݷ� +10";
                break;
            case "Feather":
                ExItemNameText.text = "õ���� ����";
                ExItemDescriptionText.text = "õ���� �������� ������ ����";
                ExItemText.text = "�̵��ӵ�+2, ������ +2";
                break;
            case "Monster Eye":
                ExItemNameText.text = "���� ��";
                ExItemDescriptionText.text = "���� �����ߴ� ������ ���̴�.";
                ExItemText.text = "���ݷ� +20";
                break;;
            case "Helm":
                ExItemNameText.text = "����� �︧";
                ExItemDescriptionText.text = "�̸��� ��簡 ����ߴ� �︧�̴�.";
                ExItemText.text = "���ݷ� +10,�ִ�ü�� +2";
                break;
            case "Iron Armor":
                ExItemNameText.text = "ö����";
                ExItemDescriptionText.text = "��������� ���� ���ſ�����.";
                ExItemText.text = "�ִ�ü�� +2, �̵��ӵ� -1";
                break;
            case "Iron Boot":
                ExItemNameText.text = "ö��ȭ";
                ExItemDescriptionText.text = "���� ���� ������ ����������, �� ���̴�..";
                ExItemText.text = "�ִ�ü�� +1, �̵��ӵ� -1";
                break;
            case "Iron Helmet":
                ExItemNameText.text = "ö��";
                ExItemDescriptionText.text = "�Ӹ��� �������� ���� ����ϴ�.";
                ExItemText.text = "�ִ�ü�� +2";
                break;
            case "Leather Armor":
                ExItemNameText.text = "���װ���";
                ExItemDescriptionText.text = "���� �������� ����� ������.";
                ExItemText.text = "�ִ�ü�� +1, ġ��ŸȮ�� +10%";
                break;
            case "Leather Boot":
                ExItemNameText.text = "������ȭ";
                ExItemDescriptionText.text = "�������� �Ŵ� ��ȭ��. ���� �������� ����� ���.";
                ExItemText.text = "ġ��ŸȮ�� +10%, �̵��ӵ� +1";
                break;
            case "Leather Helmet":
                ExItemNameText.text = "���׸���";
                ExItemDescriptionText.text = "���� ����⸦ Ÿ���Ұ� ���� ����̴�..";
                ExItemText.text = "�̵��ӵ�+1, ġ��Ÿ������ +20%";
                break;
            case "Skull":
                ExItemNameText.text = "�ΰ���";
                ExItemDescriptionText.text = "�߸����� �ȵ��� ���..�۷θ���!!";
                ExItemText.text = "���ݷ� +50,�ִ�ü�� -3";
                break;
            case "Wizard Hat":
                ExItemNameText.text = "������ ����";
                ExItemDescriptionText.text = "���� ���డ ����ϴ� ����";
                ExItemText.text = "���ݷ� +30";
                break;
            case "Beer":
                ExItemNameText.text = "����";
                ExItemDescriptionText.text = "���ﶩ �ÿ��� ��������!";
                ExItemText.text = "ü��3 ȸ��";
                break;
            case "Bone":
                ExItemNameText.text = "��";
                ExItemDescriptionText.text = "Į�� ����! ���� �ܴ��������ϴ�!";
                ExItemText.text = "�ִ�ü�� 1����";
                break;
            case "Bread":
                ExItemNameText.text = "��";
                ExItemDescriptionText.text = "���� ���� �Ļ�! �ε巴�� ����� ���Դϴ�!";
                ExItemText.text = "ü�� 1ȸ��";
                break;
            case "Fish Steak":
                ExItemNameText.text = "����� ������ũ";
                ExItemDescriptionText.text = "������ũ�Դϴ�! ��� ���� �ƴ�����..";
                ExItemText.text = "ü�� 2 ȸ��";
                break;
            case "Heart":
                ExItemNameText.text = "�����";
                ExItemDescriptionText.text = "ȭ�����Դϴ�! ������ �޾ҽ��ϴ�!";
                ExItemText.text = "�ִ�ü�� 2����";
                break;
            case "Monster Meat":
                ExItemNameText.text = "���� ���";
                ExItemDescriptionText.text = "�������� ��¼�ڽ��ϱ�! ��ƾ���!";
                ExItemText.text = "ü�� 2 ȸ��, �ִ�ü�� 1 ����";
                break;
            case "Copper Coin":
                ExItemNameText.text = "��ȭ";
                ExItemDescriptionText.text = "���� ��ȭ�Դϴ�.";
                ExItemText.text = "��� ȹ�淮 5% ����";
                break;
            case "Golden Coin":
                ExItemNameText.text = "��ȭ";
                ExItemDescriptionText.text = "��ŵ� ���� ����!";
                ExItemText.text = "��� ȹ�淮 25% ����";
                break;
            case "Silver Coin":
                ExItemNameText.text = "��ȭ";
                ExItemDescriptionText.text = "���� ���� �����Դϴ�.";
                ExItemText.text = "��� ȹ�淮 15% ����";
                break;
            case "Arrow":
                ExItemNameText.text = "ȭ��";
                ExItemDescriptionText.text = "�״��� ���� ȭ����.. �׷��� �������ٴ� �����ϴ�!";
                ExItemText.text = "���ݷ� +10";
                break;
            case "Bow":
                ExItemNameText.text = "Ȱ";
                ExItemDescriptionText.text = "�״��� ���� Ȱ���� �׷��� �������ٴ� �����ϴ�!\r\n";
                ExItemText.text = "���ݷ� +10";
                break;
            case "Emerald Staff":
                ExItemNameText.text = "���޶��� ������";
                ExItemDescriptionText.text = "���޶���� ���ϱ��? ���¹����� �������ϴ�!";
                ExItemText.text = "���ݷ�+15";
                break;
            case "Golden Sword":
                ExItemNameText.text = "ȭ���� ��";
                ExItemDescriptionText.text = "������ �������� �ǿ뼺�� ��������. ������?";
                ExItemText.text = "���ݷ� +5, ġ��Ÿ ������ +30%";
                break;
            case "Iron Shield":
                ExItemNameText.text = "��ö����";
                ExItemDescriptionText.text = "�� ����������!";
                ExItemText.text = "�ִ�ü�� +3, �̵��ӵ� -1"; ;
                break;
            case "Iron Sword":
                ExItemNameText.text = "ö��";
                ExItemDescriptionText.text = "����� ö��. ��̾��� ���̴�\r\n";
                ExItemText.text = "���ݷ� +10";
                break;
            case "Knife":
                ExItemNameText.text = "�ϻ����� �ܰ�";
                ExItemDescriptionText.text = "�ϻ��ڵ��� ����ϴ� �ܰ��Դϴ�.";
                ExItemText.text = "ġ��Ÿ Ȯ�� +20%";
                break;
            case "Magic Wand":
                ExItemNameText.text = "���ѳ��� ������";
                ExItemDescriptionText.text = "Avada Kedavra!";
                ExItemText.text = "���ݷ� +50";
                break;
            case "Sapphire Staff":
                ExItemNameText.text = "�����̾� ������";
                ExItemDescriptionText.text = "�����ϳ׿�.. �ÿ��� ����� ��ϴ�!";
                ExItemText.text = "���ݷ� +10";
                break;
            case "Silver Sword":
                ExItemNameText.text = "��ö��";
                ExItemDescriptionText.text = "�ǿ����̰� �ܴ��� ��.";
                ExItemText.text = "���ݷ� +20";
                break;
            case "Wooden Shield":
                ExItemNameText.text = "��������";
                ExItemDescriptionText.text = "Ȳ�ܸ����� ���� �ܴ��� ��������!";
                ExItemText.text = "�ִ�ü��+2";
                break;
            case "Wooden Staff":
                ExItemNameText.text = "��񳪹� ������";
                ExItemDescriptionText.text = "������ ������..�Ⱥη�����,,?";
                ExItemText.text = "���ݷ� +15";
                break;
            case "Wooden Sword":
                ExItemNameText.text = "������";
                ExItemDescriptionText.text = "������ ���� ����� ������. �������� �ܴ�������..?\r\n";
                ExItemText.text = "���ݷ� +5";
                break;
        }
    }
}
