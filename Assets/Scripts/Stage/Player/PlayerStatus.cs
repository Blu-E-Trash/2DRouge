using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public Text systemMassage;
    [SerializeField]
    public GameObject SystemMassageGO;
    [SerializeField]
    public Image characterImage; //ĳ���� �ʻ�ȭ
    [SerializeField]
    public Image UIcharacterImage;
    public Sprite UpgradedClass; //���� ���� �ʻ�ȭ

    protected int UpgradCount;

    public float Damage;       //���ݷ�
    public int maxHp;           //�ִ�ä��
    public int Hp;           //ü��
    public int CritPer;       //ũȮ
    public int CritDam;       //ũ��
    public int gold;       
    PlayerMove playerMove;
    [SerializeField]
    StatusUI statusUI;
    public void Awake()
    {
        SystemMassageGO.SetActive(false);
        gold = 100;
        UpgradCount = 0;
        statusUI.HpText.text = "Hp:" + maxHp.ToString() + "/" + Hp.ToString();
    }
    public void UpgradeClass()
    {
        if (UpgradCount<1 && gold >= 1000)
        {
            gold -= 1000;
            UpgradCount += 1;
            characterImage.sprite = UpgradedClass;
            UIcharacterImage.sprite = UpgradedClass;
            Damage = Damage + 20;
            maxHp += 2;
            Hp += 2;
            CritDam += 30;
            CritPer += 20;
            playerMove.dashCooldown -= 1;
        }
        else if (UpgradCount != 0)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "�̹� �±��߽��ϴ�.";
            Invoke("Out", 2f);
        }
        else if (gold < 1000)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "���� �����մϴ�.";
            Invoke("Out", 2f);

        }
        
    }
    private void Out()
    {
        SystemMassageGO.SetActive(false);
    }
}
