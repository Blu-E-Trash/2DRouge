using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject Wall;
    [SerializeField]
    private EnemyHp BossHp;
    private void Start()
    {
        Wall.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("player");
            Wall.SetActive(true);
        }
    }
    private void Update()
    {
        if (BossHp.isBossDead)
        {
            Wall.SetActive(false);
        }
    }
}
