using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{ 
    public Text goldText;           //얼마 있는지 확인
    public Text systemMassage;
    public GameObject SystemMassageGO;
    [SerializeField]
    public Image characterImage; //캐릭터 초상화
    private Image UpgradedClass; //업글 후의 초상화

    private bool Upgraded;

    public float Damage;       //공격력
    public int maxHp;           //최대채력
    public int Hp;           //체력
    public int CritPer;       //크확
    public int CritDam;       //크뎀
    
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
            systemMassage.text = "돈이 부족합니다.";
            Invoke("Out", 2f);

        }
        else if (Upgraded)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "이미 승급했습니다.";
            Invoke("Out", 2f);
        }
    }
    private void Out()
    {
        SystemMassageGO.SetActive(false);
    }
}
