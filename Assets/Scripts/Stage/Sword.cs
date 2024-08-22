using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : PlayerStatus
{
    PlayerMove playerMove;
    Text CharacterEx;
    private void Start()
    {
        maxHp = 6;
        Hp = maxHp;
        Damage = 100;
        playerMove.movePower = 5;
        CritPer = 20;
        CritDam = 150;
    }
    private void Update()
    {
        if (UpgradCount != 0)
        {
            CharacterEx.text = "정식 기사";
        }
    }
}
