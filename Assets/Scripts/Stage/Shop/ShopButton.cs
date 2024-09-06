using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    Shop shop;
    [SerializeField]
    int index;

    Button button;
    Image image;
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }
    private void foo()
    {
        button.onClick.AddListener(() => { shop.SelectItem(shop.sellSlots[index]); });
        image.sprite = shop.sellSlots[index].itemImage;
    }
}
