using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;
    public bool isDead;

    Animator animator;
    PlayerStatus playerStatus;
    EnemyMove enemyMove;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        playerStatus = FindObjectOfType<PlayerStatus>();
        enemyMove = FindObjectOfType<EnemyMove>();
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
            playerStatus.gold += 15;
            enemyMove.nextMove = 0;
            Invoke("DestoryEnemy", 2);
            isDead = true;
        }
    }
    private void DestoryEnemy()
    {
        Destroy(this);
    }
    private void Stop()
    {
        enemyMove.nextMove = 0;
    }
}
