using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;
    public bool isDead;
    private int CritrcalPer;
    private int HMGold;
    [SerializeField]
    private GameObject critEffect;

    [SerializeField]
    private StatusUI statusUI;

    private GameManager gameManager;
    private Animator animator;
    private PlayerStatus playerStatus;
    private EnemyMove enemyMove;
    public bool isBossDead;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        critEffect.SetActive(false);
        currentHP = maxHP;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerStatus = FindObjectOfType<PlayerStatus>();
        enemyMove = GetComponent<EnemyMove>();
    }
    private void Update()
    {
        if (this.transform.localScale.x == -1)
        {
            critEffect.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(this.transform.localScale.x == 1)
        {
            critEffect.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void CriticalDamaged()
    {
        critEffect.SetActive(true);
        currentHP -= Mathf.FloorToInt(playerStatus.Damage * playerStatus.CritDam);
    }
    public void mobDamaged()
    {
        CritrcalPer = Random.Range(0, 100);
        if (CritrcalPer <= playerStatus.CritPer)
        {
            CriticalDamaged();
            Invoke("TurnOffEffect", 1f);
        }
        else
        {
            currentHP -= playerStatus.Damage;
        }
        if (currentHP > 0)
        {
            animator.SetTrigger("Hit");
            Invoke("Stop",1);
        }
        else if (currentHP <= 0)
        {
            animator.SetTrigger("Hit");
            animator.SetBool("Dead", true);
            HowManyGold();
            playerStatus.gold += Mathf.FloorToInt(playerStatus.goldBonus*HMGold);
            gameManager.GoldSyncronization();
            statusUI.BasicUIUpdate();
            
            isDead = true;
            if(this.tag == "Boss")
            {
                isBossDead = true;
            }
        }
    }
    private void TurnOffEffect()
    {
        critEffect.SetActive(false);
    }
    private void HowManyGold()
    {
        if (this.tag == "Zombie") {
            HMGold = Random.Range(25, 35); 
        }
        else if(this.tag == "Goul")
        {
            HMGold = Random.Range(30, 40);
        }
        else if (this.tag == "Skeleton")
        {
            HMGold = Random.Range(35, 45);
        }
        else if (this.tag == "General Skeleton")
        {
            HMGold = Random.Range(40, 50);
        }
        else if (this.tag == "Boss")
        {
            HMGold = Random.Range(100,120);
        }
    }
    private void Stop()
    {
        enemyMove.nextMove = 0;
        critEffect.SetActive(false);
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
        gameManager = FindAnyObjectByType<GameManager>();
    }
}