using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    private Shop shop;

    [SerializeField]
    private Image sellItemImage;
    
    public void ChangeImage(Item item)
    {
        sellItemImage.sprite = item.itemImage;
    }


}
