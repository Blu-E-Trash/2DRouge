using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;

    PlayerMove move;
    Jump jump;

    public int attackBonus;
    public int maxHpBonus;
    public int hpHeal;
    public int speedBonus;
    public int jumpBonus;
    public int critDamBonus;
    public int critperBonus;
    public int goldBonus;       //�߰����
    public int getGoldBonus;    //��ȹ ����

    public bool inInventory;

    public void ApplyEffect(PlayerStatus playerStatus)
    {
        inInventory = true;

        playerStatus.Damage += attackBonus;
        playerStatus.maxHp += maxHpBonus;
        playerStatus.Hp += hpHeal;
        playerStatus.CritDam += critDamBonus;
        playerStatus.CritPer += critperBonus;
        playerStatus.gold += goldBonus;
        //��ȹ���� +
        jump.jumpPower += jumpBonus;
        move.movePower += speedBonus;
    }

    public void RemoveEffect(PlayerStatus playerStatus)
    {
        inInventory = false;

        playerStatus.Damage -= attackBonus;
        playerStatus.maxHp -= maxHpBonus;
        playerStatus.Hp -= hpHeal;
        playerStatus.CritDam -= critDamBonus;
        playerStatus.CritPer -= critperBonus;
        //��ȹ���� -
        jump.jumpPower -= jumpBonus;
        move.movePower -= speedBonus;
    }
}
