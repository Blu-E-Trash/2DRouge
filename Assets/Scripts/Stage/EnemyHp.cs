using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;
    public int mobCount;

    Animator animator;
    PlayerStatus playerStatus;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        mobCount++;
        animator = GetComponent<Animator>();
    }
    public void mobDamaged()
    {
        if (currentHP > 0)
        {
            currentHP -= playerStatus.Damage;
            animator.SetTrigger("Hit");
            if (currentHP <= 0)
            {
                animator.SetBool("Dead", true);
                mobCount--;
                playerStatus.gold += 15;
            }
        }
        
    }
}
