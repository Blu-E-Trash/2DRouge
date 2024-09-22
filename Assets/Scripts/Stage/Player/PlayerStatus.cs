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
    [SerializeField]
    private Text ExText;
    [SerializeField]
    private GameManager gm;
    public Sprite UpgradedClass; //���� ���� �ʻ�ȭ
    
    public int UpgradCount;

    public float Damage;       //���ݷ�
    public int maxHp;           //�ִ�ä��
    public int Hp;           //ü��
    public int CritPer;       //ũȮ
    public int CritDam;       //ũ�� 
    public float goldBonus;     //��ȹ
    public int gold;        
    
    private PlayerMove playerMove;

    public void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        SystemMassageGO.SetActive(false);

        Damage = 100;
        playerMove.movePower = 5;
        CritPer = 20;
        CritDam = 150;
        goldBonus = 1f;
        if (gm.playerMaxHp == 0)
            maxHp = 6;
        else
            maxHp = gm.playerMaxHp;
        
        if (gm.playerGold == 0)
            gold = 100;
        else
            gold = gm.playerGold;

        if (!gm.isUpgrade)
            UpgradCount = 0;
        else
            UpgradCount = 1;

        if (gm.playerHp == 0)
            Hp = maxHp;
        else
            Hp = gm.playerHp;
    }
    private void Update()
    {
        if (Hp <= 0)
        {
            playerMove.animator.SetTrigger("doDie");
            gm.isGameOver = true;
        }
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
            ExText.text = "����";
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



