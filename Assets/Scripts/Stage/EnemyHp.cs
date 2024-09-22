using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;
    public bool isDead;

    [SerializeField]
    private StatusUI statusUI;
    [SerializeField]
    private GameManager gameManager;

    private Animator animator;
    private PlayerStatus playerStatus;
    private EnemyMove enemyMove;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        playerStatus = FindObjectOfType<PlayerStatus>();
        enemyMove = GetComponent<EnemyMove>();
    }
    public void mobDamaged()
    {
        currentHP -= playerStatus.Damage;
        if (currentHP > 0)
        {
            animator.SetTrigger("Hit");
            Invoke("Stop",1);
        }
        else if (currentHP <= 0)
        {
            animator.SetBool("Dead", true);
            playerStatus.gold += Mathf.FloorToInt(playerStatus.goldBonus*Random.Range(25,35));
            gameManager.GoldSyncronization();
            statusUI.BasicUIUpdate();
            isDead = true;
        }
    }
    private void Stop()
    {
        enemyMove.nextMove = 0;
    }
}
