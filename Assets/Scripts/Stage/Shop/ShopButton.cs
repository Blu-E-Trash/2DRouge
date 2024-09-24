using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    private Shop shop;

    [SerializeField]
    public Image sellItemImage;
    
    public void ChangeImage(Item item)
    {
        if(item == null)
        {
            sellItemImage.sprite = null;
            return;
        }
        sellItemImage.sprite = item.itemImage;
    }
}
