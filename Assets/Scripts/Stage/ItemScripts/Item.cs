using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;

    public int attackBonus;
    public int maxHpBonus;
    public int startMaxHpBonus;
    public int hpHeal;
    public int speedBonus;
    public int jumpBonus;
    public float critDamBonus;
    public int critperBonus;
    public float getGoldBonus;    //°ñÈ¹ Áõ°¡
    public int itemPrice;       //»ç´Â °¡°Ý
}
