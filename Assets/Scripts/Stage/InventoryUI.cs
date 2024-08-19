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
    public Image ExItemImage; // �������� �̹���
    [SerializeField]
    public Text ExItemNameText; //�������� �̸� �ؽ�Ʈ
    [SerializeField]
    public Text ExItemDescriptionText; //���Ӽ� �ý�Ʈ
    [SerializeField]
    public Text ExItemText; // �������� ȿ�� �ؽ�Ʈ

    private Image ItemImage;            //���� �ι��丮�� ������ �̹���

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
            case "Chest":
                ExItemNameText.text = "�ǵ����� ����";
                ExItemDescriptionText.text = "�̹����߸��� ���ð̴ϴ�! �Ƹ���..?";
                ExItemText.text = "���� ������ ������ ȹ��";
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
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Iron Armor":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Iron Boot":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Iron Helmet":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Leather Armor":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Leather Boot":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Leather Helmet":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Skull":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Wizard Hat":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Beer":
                ExItemNameText.text = "����";
                ExItemDescriptionText.text = "�ÿ��� ��������! ����� ������ �ణ ���մϴ�!";
                ExItemText.text = "ü��3 ȸ��, 1���������� �̵��ӵ� -2, ���ݼӵ� 20%����";
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
                ExItemText.text = "ĳ���� �ӵ� +10%";
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
                ExItemText.text = "����+50%, ĳ���� �ӵ� +30%";
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
                ExItemText.text = "���� +15%,ĳ���� �ӵ� +15%";
                break;
            case "Wooden Sword":
                ExItemNameText.text = "������";
                ExItemDescriptionText.text = "������ ���� ����� ������. �������� �ܴ�������..?\r\n";
                ExItemText.text = "���ݷ� +5%";
                break;
        }
    }
}
