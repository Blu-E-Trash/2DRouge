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
    private StatusUI statusUI;

    [SerializeField]
    public GameObject inventoryPanel;  // �κ��丮 �г�

    [SerializeField]
    public Image ExItemImage; // �������� �̹���
    [SerializeField]
    public Text ExItemNameText; //�������� �̸� �ؽ�Ʈ
    [SerializeField]
    public Text ExItemDescriptionText; //���Ӽ� �ý�Ʈ
    [SerializeField]
    public Text ExItemText; // �������� ȿ�� �ؽ�Ʈ
    [SerializeField]
    public Button[] slotButton = new Button[6];
    [SerializeField]
    private GameManager gameManager;
    public Item IselectedItem;


    private bool maintrue;
    private bool itemExTrue;

    private void Start()
    {
        
        mainInventory.SetActive(false);
        itemExplain.SetActive(false);

        maintrue = false;
        itemExTrue = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (maintrue)
            {
                mainInventory.SetActive(false);
                itemExplain.SetActive(false);
                maintrue = false;
            }
            else if (!maintrue) 
            {
                statusUI.MainUIUpdate();
                mainInventory.SetActive(true);
                maintrue = true;
            } 
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (itemExTrue) 
            {
                itemExplain.SetActive(false);
                itemExTrue = false;
            }
            else if (!itemExTrue)
            {
                mainInventory.SetActive(false);
                itemExTrue = false;
            }
        }
    }
    public void UpdateInventoryUI(Item item,int i)
    {
        slotButton[i].image.sprite = item.itemImage;
    }
    public void ClearSlot(int i)
    {
        slotButton[i].image.sprite = null;
    }
    public void SelecteItem(Item item)
    {
        IselectedItem = item;
        Debug.Log(IselectedItem);
    }
    public void ItemExplainFunction(Image itemImage)
    {
        if (itemImage.sprite == null)
        {
            ExItemImage.sprite = null;
            ExItemNameText.text = "...";
            ExItemDescriptionText.text = "���� ������ ����ִ� ���� ��ô�̳� �ƽ���..";
            ExItemText.text = "���ɼ��� ���ĳ��� �����̴�";
            itemExplain.SetActive(true);
            itemExTrue = true;
        }
        else if (itemImage.sprite != null)
        {
            ChangeImageAndText(itemImage);   
            itemExplain.SetActive(true);
            itemExTrue = true;
        }
    }
    public void RemoveItem()
    {
        for (int i = 0; i < 6; i++)
        {
            if (gameManager.inventory[i] == IselectedItem)
            {
                ClearSlot(i);
                gameManager.RemoveEffect(IselectedItem);
                return;
            }
        }
    }
    public void ChangeImageAndText(Image ItemName)
    {
        ExItemImage.sprite = ItemName.sprite;

        switch (ExItemImage.sprite.name)
        {
            case "Rune Stone":
                ExItemNameText.text = "�齺��";
                ExItemDescriptionText.text = "��� ���� ������ ���ɰ���";
                ExItemText.text = "��/�� +10%";
                break;
            case "Feather":
                ExItemNameText.text = "õ���� ����";
                ExItemDescriptionText.text = "õ���� �������� ������ ����";
                ExItemText.text = "�̵��ӵ�+2, ������ +2";
                break;
            case "Monster Eye":
                ExItemNameText.text = "���� ��";
                ExItemDescriptionText.text = "���� �����ߴ� ������ ���̴�.";
                ExItemText.text = "��/��+20%";
                break;
            case "Helm":
                ExItemNameText.text = "����� �︧";
                ExItemDescriptionText.text = "�̸��� ��簡 ����ߴ� �︧�̴�.";
                ExItemText.text = "���ݷ� +10%,�ִ�ä�� +2";
                break;
            case "Iron Armor":
                ExItemNameText.text = "ö����";
                ExItemDescriptionText.text = "��������� ���� ���ſ�����.";
                ExItemText.text = "�ִ�ä�� +2, �̵��ӵ� -1";
                break;
            case "Iron Boot":
                ExItemNameText.text = "ö��ȭ";
                ExItemDescriptionText.text = "���� ���� ������ ����������, �� ���̴�..";
                ExItemText.text = "�ִ�ä�� +1, �̵��ӵ� -1";
                break;
            case "Iron Helmet":
                ExItemNameText.text = "ö��";
                ExItemDescriptionText.text = "�Ӹ��� �������� ���� ����ϴ�.";
                ExItemText.text = "�ִ�ä�� +2";
                break;
            case "Leather Armor":
                ExItemNameText.text = "���װ���";
                ExItemDescriptionText.text = "���� �������� ����� ������.";
                ExItemText.text = "�ִ�ä�� +1, ġ��ŸȮ�� +10%";
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
                ExItemText.text = "���ݷ�+50%,�ִ�ä�� -3";
                break;
            case "Wizard Hat":
                ExItemNameText.text = "������ ����";
                ExItemDescriptionText.text = "���� ���డ ����ϴ� ����";
                ExItemText.text = "���ݷ�+30%";
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
                ExItemText.text = "���ݷ� +10%";
                break;
            case "Bow":
                ExItemNameText.text = "Ȱ";
                ExItemDescriptionText.text = "�״��� ���� Ȱ���� �׷��� �������ٴ� �����ϴ�!\r\n";
                ExItemText.text = "���ݷ� +10%";
                break;
            case "Emerald Staff":
                ExItemNameText.text = "���޶��� ������";
                ExItemDescriptionText.text = "���޶���� ���ϱ��? ���¹����� �������ϴ�!";
                ExItemText.text = "���ݷ�+15%";
                break;
            case "Golden Sword":
                ExItemNameText.text = "ȭ���� ��";
                ExItemDescriptionText.text = "������ �������� �ǿ뼺�� ��������. ������?";
                ExItemText.text = "���ݷ� +5%, ġ��Ÿ ������ +30%";
                break;
            case "Iron Shield":
                ExItemNameText.text = "��ö����";
                ExItemDescriptionText.text = "�� ����������!";
                ExItemText.text = "�ִ�ü�� +3, �̵��ӵ� -1"; ;
                break;
            case "Iron Sword":
                ExItemNameText.text = "ö��";
                ExItemDescriptionText.text = "����� ö��. ��̾��� ���̴�\r\n";
                ExItemText.text = "���ݷ� +10%";
                break;
            case "Knife":
                ExItemNameText.text = "�ϻ����� �ܰ�";
                ExItemDescriptionText.text = "�ϻ��ڵ��� ����ϴ� �ܰ��Դϴ�.";
                ExItemText.text = "ġ��Ÿ Ȯ�� +20%";
                break;
            case "Magic Wand":
                ExItemNameText.text = "���ѳ��� ������";
                ExItemDescriptionText.text = "Avada Kedavra!";
                ExItemText.text = "����+50%";
                break;
            case "Sapphire Staff":
                ExItemNameText.text = "�����̾� ������";
                ExItemDescriptionText.text = "�����ϳ׿�.. �������ݷ��� ����մϴ�!";
                ExItemText.text = "���� +10%";
                break;
            case "Silver Sword":
                ExItemNameText.text = "��ö��";
                ExItemDescriptionText.text = "�ǿ����̰� �ܴ��� ��.";
                ExItemText.text = "���ݷ� +20%";
                break;
            case "Wooden Shield":
                ExItemNameText.text = "��������";
                ExItemDescriptionText.text = "Ȳ�ܸ����� ���� �ܴ��� ��������!";
                ExItemText.text = "�ִ�ü��+2";
                break;
            case "Wooden Staff":
                ExItemNameText.text = "��񳪹� ������";
                ExItemDescriptionText.text = "������ ������..�Ⱥη�����,,?";
                ExItemText.text = "���� +15%";
                break;
            case "Wooden Sword":
                ExItemNameText.text = "������";
                ExItemDescriptionText.text = "������ ���� ����� ������. �������� �ܴ�������..?\r\n";
                ExItemText.text = "���ݷ� +5%";
                break;
        }
    }
}
