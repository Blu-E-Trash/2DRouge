using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archor : PlayerStatus
{
    PlayerMove playerMove;
    private void Start()
    {
        Hp = 3;
        Damage = 150;
        playerMove.movePower = 7;
        CritPer = 40;
        CritDam = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
