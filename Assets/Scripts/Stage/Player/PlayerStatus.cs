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
    public Image characterImage; //캐릭터 초상화
    [SerializeField]
    public Image UIcharacterImage;
    [SerializeField]
    private Text ExText;
    [SerializeField]
    private GameManager gm;
    public Sprite UpgradedClass; //업글 후의 초상화
    
    public int UpgradCount;

    public float Damage;       //공격력
    public int maxHp;           //최대채력
    public int Hp;           //체력
    public int CritPer;       //크확
    public int CritDam;       //크뎀 
    public float goldBonus;     //골획
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
            ExText.text = "정식";
        }
        else if (UpgradCount != 0)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "이미 승급했습니다.";
            Invoke("Out", 2f);
        }
        else if (gold < 1000)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "돈이 부족합니다.";
            Invoke("Out", 2f);

        }
    }
    private void Out()
    {
        SystemMassageGO.SetActive(false);
    }
}



