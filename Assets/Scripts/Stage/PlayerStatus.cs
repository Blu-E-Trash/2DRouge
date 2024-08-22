using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{ 
    public Text goldText;           //�� �ִ��� Ȯ��
    public Text systemMassage;
    public GameObject SystemMassageGO;
    [SerializeField]
    public Image characterImage; //ĳ���� �ʻ�ȭ
    private Image UpgradedClass; //���� ���� �ʻ�ȭ

    private bool Upgraded;

    public float Damage;       //���ݷ�
    public int maxHp;           //�ִ�ä��
    public int Hp;           //ü��
    public int CritPer;       //ũȮ
    public int CritDam;       //ũ��
    
    public int gold;       
    PlayerMove playerMove;

    public void Start()
    {
        SystemMassageGO.SetActive(false);
        gold = 100;
        goldText.text = gold.ToString();
    }
    private void Update()
    {
        goldText.text = gold.ToString();
    }
    public void UpgradeClass()
    {
        if (gold>=1000 && !Upgraded)
        {
            gold -= 1000;
            characterImage.sprite = UpgradedClass.sprite;
            Damage = Damage + 20;
            Hp += 2;
            playerMove.dashCooldown -= 1;
            Upgraded = true;
        }
        else if (gold < 1000)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "���� �����մϴ�.";
            Invoke("Out", 2f);

        }
        else if (Upgraded)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "�̹� �±��߽��ϴ�.";
            Invoke("Out", 2f);
        }
    }
    private void Out()
    {
        SystemMassageGO.SetActive(false);
    }
}
