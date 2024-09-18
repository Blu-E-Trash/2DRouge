using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private Text SystemMassage;
    [SerializeField]
    private Sword sword;
    [SerializeField]
    private PlayerMove playerMove;

    public bool isGameOver;

    [SerializeField]
    private Transform playerpos;
    //����� ������
    public bool isUpgrade;      //�±�
    public int playerGold;      //���
    public int playerHp;        //ä��
    public Item[] inventory;     //�κ��� �ٲ���� ����;
    private InventoryUI inventoryUI;

    private void Awake()
    {
        isGameOver = false;
        if (Instance == null) { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
           Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("FirstSceen");
            isGameOver=false;
        }
        if (playerpos.position.y < -15)
        {
            fallDamage();
        }
    }
    public void getAttacked()
    {
        if(playerMove.immortal) {
            return;
        }
        if (playerMove.isDash){
            return;
        }

        playerMove.immortal = true;
        StartCoroutine(ImmotalCorutine());
        sword.Hp -= 1;
        Debug.Log("���Ŀ�");
        playerMove.animator.SetTrigger("doHit");
        if (sword.Hp <= 0)
        {
            playerMove.animator.SetTrigger("doDie");
            isGameOver = true;
        }
    }

    IEnumerator ImmotalCorutine()
    {
        yield return new WaitForSeconds(1);
        playerMove.immortal=false;
    }
    public void fallDamage()
    {
        sword.Hp -= 1;
        playerpos.position = new Vector3(-10, -3, -1);  
    }
    public void AddItemtoInventory(Item item)
    {
        for (int i = 0; i < 6; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                inventoryUI.UpdateInventoryUI();
                return;
            }
        }
        //�ø� ���ϴ°� ����
        SystemMassage.text = "�κ��丮�� �� á���ϴ�.";
    }
    public void RemoveItem(Item item)
    {
        inventory[0] = null;
        inventoryUI.ClearSlot();
    }
    private void getStat()
    {
        playerHp = sword.Hp;
        playerGold = sword.gold;
        isUpgrade = false;          //�ӽ�
    }
}