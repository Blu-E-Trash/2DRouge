using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ShopOpen : MonoBehaviour
{

    public Transform pos;
    public Vector2 boxSize;

    [SerializeField]
    Shop shop;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Shop"))
                {
                    Open();
                }
            }
        }
    }
    public void Open()
    {
        shop.ShopUI.SetActive(true);
    }
}
