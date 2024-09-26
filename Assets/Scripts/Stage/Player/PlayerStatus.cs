using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private Text upgradeText;
    public Sprite UpgradedClass; //업글 후의 초상화
    public Sprite PlayingUpgraded;
    public bool isDamaged;
    
    public int UpgradCount;
    public int startMaxHp;
    public float jumpPower;     //점프력
    public float Damage;       //공격력
    public int maxHp;           //최대체력
    public int Hp;           //체력
    public int CritPer;       //크확
    public float CritDam;       //크뎀 
    public float goldBonus;     //골획
    public int gold;        
    
    public PlayerMove playerMove;
    public GameManager gameManager;
    [SerializeField]
    private StatusUI statusUI;
    [SerializeField]
    private Transform playerpos;
    public float movePower;     //이속

    public void Awake()
    {
        SystemMassageGO.SetActive(false);
        startMaxHp = 6;
        maxHp = startMaxHp;
        Damage = 100;
        CritPer = 20;
        CritDam = 1.5f;
        goldBonus = 1f;
        movePower = 5f;
        jumpPower = 5f;
    }
    private void Update()
    {
        if (Hp <= 0)
        {
            playerMove.nowAnimator.SetTrigger("doDie");
            gameManager.isGameOver = true;
        }
        if (playerpos.position.y < -15)
        {
            fallDamage();
        }
    }
    public void fallDamage()
    {
        Hp -= 1;
        playerpos.position = new Vector3(-10, -3, -1);
        gameManager.currentHpSyncronization();
        statusUI.BasicUIUpdate();
    }
    public void getAttacked()
    {
        if (!gameManager.isGameOver)
        {
            if (playerMove.immortal)
            {
                return;
            }
            if (playerMove.isDash)
            {
                return;
            }
            isDamaged = true;
            playerMove.immortal = true;
            StartCoroutine(ImmotalCorutine());
            Hp -= 1;
            playerMove.nowAnimator.SetTrigger("doHit");
            gameManager.currentHpSyncronization();
            statusUI.BasicUIUpdate();
            statusUI.MainUIUpdate();
            isDamaged = false;
        }
    }
    IEnumerator ImmotalCorutine()
    {
        yield return new WaitForSeconds(1);
        gameManager.currentHpSyncronization();
        playerMove.immortal = false;
    }
    public void ApplyEffect(Item item)
    {
        Damage += item.attackBonus;
        maxHp += item.maxHpBonus;
        Hp += item.maxHpBonus;
        startMaxHp += item.startMaxHpBonus;
        Hp += item.hpHeal;
        if (Hp >= maxHp)
        {
            Hp = maxHp;
        }
        CritDam += item.critDamBonus;
        CritPer += item.critperBonus;
        goldBonus += item.getGoldBonus;
        jumpPower += item.jumpBonus;
        movePower += item.speedBonus;
    }
    public void RemoveEffect(Item item)
    {
        Damage -= item.attackBonus;
        maxHp -= item.maxHpBonus;
        if (Hp >= maxHp)
        {
            Hp = maxHp;
        }
        CritDam -= item.critDamBonus;
        CritPer -= item.critperBonus;
        goldBonus -= item.getGoldBonus;
        jumpPower -= item.jumpBonus;
        movePower -= item.speedBonus;
    }
    public void UpgradeClass()
    {
        if (UpgradCount < 1 && gold >= 500)
        {
            gold -= 500;
            Hp += 2;
            ClassUpgrade();
            gameManager.GoldSyncronization();
            gameManager.HpSyncronization();
            gameManager.UpgradeSyncronization();
        }
        else if (UpgradCount != 0)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "이미 승급했습니다.";
            Invoke("Out", 2f);
        }
        else if (gold < 500)
        {
            SystemMassageGO.SetActive(true);
            systemMassage.text = "돈이 부족합니다.";
            Invoke("Out", 2f);
        }
    }
    public void ClassUpgrade()
    {
        UpgradCount += 1;
        maxHp += 2;
        Damage = Damage + 20;
        CritDam += 0.3f;
        CritPer += 20;
        playerMove.dashCooldown -= 1;
        characterImage.sprite = UpgradedClass;
        UIcharacterImage.sprite = UpgradedClass;
        playerMove.ChangeAnimation();
        statusUI.BasicUIUpdate();
        statusUI.MainUIUpdate();
        ExText.text = "정식 기사";
        upgradeText.text = "Upgraded";
    }
    private void Out()
    {
        SystemMassageGO.SetActive(false);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerMove = GetComponent<PlayerMove>();
    }
}



