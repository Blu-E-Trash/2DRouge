using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;

    PlayerStatus playerStatus;
    PlayerMove move;

    public int attackBonus;
    public int maxHpBonus;
    public int hpHeal;
    public int speedBonus;
    public int jumpBonus;
    public int critDamBonus;
    public int critperBonus;
    public int goldBonus;       //Ãß°¡°ñµå
    public int getGoldBonus;    //°ñÈ¹ Áõ°¡
    public int itemPrice;       //»ç´Â °¡°Ý
    public int sellPrice;       //ÆÄ´Â °¡°Ý

    public bool inInventory;

    public void ApplyEffect(Item item)
    {
        inInventory = true;

        playerStatus.Damage += item.attackBonus;
        playerStatus.maxHp += item.maxHpBonus;
        playerStatus.Hp += item.hpHeal;
        playerStatus.CritDam += item.critDamBonus;
        playerStatus.CritPer += item.critperBonus;
        playerStatus.gold += item.goldBonus;
        //°ñÈ¹Áõ°¡ +
        move.jumpPower += item.jumpBonus;
        move.movePower += item.speedBonus;
    }

    public void RemoveEffect(Item item)
    {
        inInventory = false;

        playerStatus.Damage -= item.attackBonus;
        playerStatus.maxHp -= item.maxHpBonus;
        playerStatus.Hp -= item.hpHeal;
        playerStatus.CritDam -= item.critDamBonus;
        playerStatus.CritPer -= item.critperBonus;
        //°ñÈ¹Áõ°¡ -
        move.jumpPower -= item.jumpBonus;
        move.movePower -= item.speedBonus;
    }
}
