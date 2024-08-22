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
    public GameObject inventoryPanel;  // �κ��丮 �г�
    [SerializeField]
    public Transform itemsParent;      // ���Ե��� ��� �θ� ��ü

    private List<InventorySlots> slots = new List<InventorySlots>();  // ���� UI�� ������ ���� ����Ʈ

    [SerializeField]
    public Image ExItemImage; // �������� �̹���
    [SerializeField]
    public Text ExItemNameText; //�������� �̸� �ؽ�Ʈ
    [SerializeField]
    public Text ExItemDescriptionText; //���Ӽ� �ý�Ʈ
    [SerializeField]
    public Text ExItemText; // �������� ȿ�� �ؽ�Ʈ

    private Image ItemImage;            //���� �ι��丮�� ������ �̹���
    public Inventory inventory;        // �κ��丮 ��ũ��Ʈ

    private bool maintrue;
    private bool itemExTrue;

    private void Start()
    {
        mainInventory.SetActive(false);
        itemExplain.SetActive(false);

        maintrue = false;
        itemExTrue = false;

        string ItemName = ItemImage.sprite.name;

        UpdateInventoryUI();

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
    public void UpdateInventoryUI()
    {
        // ��� ������ ���� �κ��丮 ���������� ä���
        foreach (InventorySlots slot in slots)
        {
            slot.ClearSlot();  // ���� �ʱ�ȭ
        }

        for (int i = 0; i < Inventory.Instance.inventoryItems.Count; i++)
        {
            if (i < slots.Count)
            {
                slots[i].AddItem(Inventory.Instance.inventoryItems[i]);
            }
        }
    }

    public void ItemExplainFunction(Image ItemName)
    {
        if (ItemName.sprite == null)
        {
            ExItemImage.sprite = null;
            ExItemNameText.text = "...";
            ExItemDescriptionText.text = "���� ������ ����ִ� ���� ��ô�̳� �ƽ���..";
            ExItemText.text = "���ɼ��� ���ĳ��� �����̴�";
            itemExplain.SetActive(true);
            itemExTrue = true;
        }
        else if (ItemName.sprite != null)
        {
            ChangeImageAndText(ItemName);   
            itemExplain.SetActive(true);
            itemExTrue = true;
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
            case "Slime Gel":
                ExItemNameText.text = "������ ����";
                ExItemDescriptionText.text = "�������� �����ϴ�..?";
                ExItemText.text = "������ �ǸŽ� 100G ȹ��";
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
            case "Ham":
                ExItemNameText.text = "��";
                ExItemDescriptionText.text = "��Ÿ���� ����! ���� ũ�� �ϰ���� �����!";
                ExItemText.text = "ü�� 3ȸ��";
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
            case "Wine":
                ExItemNameText.text = "����(���� ����)";
                ExItemDescriptionText.text = "�����ϰ� ������ ��! ���� ����ó�� �̰߰� ȭ���� ����!";
                ExItemText.text = "������ �ǸŽ� 500Gȹ��";
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
            case "Golden Ingot":
                ExItemNameText.text = "����";
                ExItemDescriptionText.text = "��¥ ����! ���ݸ��� �ƴҰ̴ϴ�..";
                ExItemText.text = "300G ȹ��";
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
