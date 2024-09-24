using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpen : MonoBehaviour
{
    [SerializeField]
    private Shop shop;
    public bool canOpen;
    public bool isOpening;

    private void Update()
    {
        if (canOpen)
        {
            if (!isOpening)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Open();
                }
            }
        }
        if (!canOpen)
        {
            Close();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canOpen = false;
            isOpening = false;
        }
    }
    public void Open()
    {
        shop.ShopUI.SetActive(true);
        shop.itemPrice.text = "구매하기";
        isOpening = true;
    }
    public void Close()
    {
        shop.ShopUI.SetActive(false);
        isOpening = false;
    }
}
