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
    public Sprite UpgradedClass; //업글 후의 초상화

    protected int UpgradCount;

    public float Damage;       //공격력
    public int maxHp;           //최대채력
    public int Hp;           //체력
    public int CritPer;       //크확
    public int CritDam;       //크뎀
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
