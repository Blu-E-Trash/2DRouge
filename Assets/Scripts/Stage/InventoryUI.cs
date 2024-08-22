using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    GameObject mainInventory;
    [SerializeField]
    GameObject itemExplain;

    [SerializeField]
    public GameObject inventoryPanel;  // 인벤토리 패널
    [SerializeField]
    public Transform itemsParent;      // 슬롯들을 담는 부모 객체

    private List<InventorySlots> slots = new List<InventorySlots>();  // 현재 UI에 생성된 슬롯 리스트

    [SerializeField]
    public Image ExItemImage; // 아이템의 이미지
    [SerializeField]
    public Text ExItemNameText; //아이템의 이름 텍스트
    [SerializeField]
    public Text ExItemDescriptionText; //추임세 택스트
    [SerializeField]
    public Text ExItemText; // 아이템의 효과 텍스트

    private Image ItemImage;            //메인 인밴토리의 아이템 이미지

    private bool maintrue;
    private bool itemExTrue;

    private void Start()
    {
        mainInventory.SetActive(false);
        itemExplain.SetActive(false);

        maintrue = false;
        itemExTrue = false;

        string ItemName = ItemImage.sprite.name;

        UpdateInventoryUI();

    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("인밴 열려고 함");
            if (maintrue)
            {
                Debug.Log("인밴 열기");
                //다 꺼버리기
                mainInventory.SetActive(false);
                itemExplain.SetActive(false);
                maintrue = false;
            }
            else if (!maintrue) 
            {
                Debug.Log("인밴 닫기");
                //키기
                mainInventory.SetActive(true);
                maintrue = true;
            } 
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //끄기
            if (itemExTrue) 
            {
                //아이템 설명이 켜져있으면 아이템 설명만 끈다.
                itemExplain.SetActive(false);
                itemExTrue = false;
            }
            else if (!itemExTrue)
            {
                //아이템 설명이 꺼져있으면 메인 인벤토리를 끈다.
                mainInventory.SetActive(false);
                itemExTrue = false;
            }
        }
    }
    public void UpdateInventoryUI()
    {
        // 모든 슬롯을 비우고 인벤토리 아이템으로 채우기
        foreach (InventorySlots slot in slots)
        {
            slot.ClearSlot();  // 슬롯 초기화
        }

        for (int i = 0; i < Inventory.Instance.inventoryItems.Count; i++)
        {
            if (i < slots.Count)
            {
                slots[i].AddItem(Inventory.Instance.inventoryItems[i]);
            }
        }
    }

    public void ItemExplainFunction(Image ItemName)
    {
        if (ItemName.sprite == null)
        {
            ExItemImage.sprite = null;
            ExItemNameText.text = "...";
            ExItemDescriptionText.text = "가방 한켠이 비어있는 것이 무척이나 아쉽다..";
            ExItemText.text = "가능성이 넘쳐나는 공간이다";
            itemExplain.SetActive(true);
            itemExTrue = true;
        }
        else if (ItemName.sprite != null)
        {
            ChangeImageAndText(ItemName);   
            itemExplain.SetActive(true);
            itemExTrue = true;
        }
    }
    public void ChangeImageAndText(Image ItemName)
    {
        ExItemImage.sprite = ItemName.sprite;

        switch (ExItemImage.sprite.name)
        {
            case "Rune Stone":
                ExItemNameText.text = "룬스톤";
                ExItemDescriptionText.text = "고대 룬이 새겨진 돌쪼가리";
                ExItemText.text = "공/마 +10%";
                break;
            case "Feather":
                ExItemNameText.text = "천사의 깃털";
                ExItemDescriptionText.text = "천사의 날개에서 떨어진 깃털";
                ExItemText.text = "이동속도+2, 점프력 +2";
                break;
            case "Monster Eye":
                ExItemNameText.text = "용의 눈";
                ExItemDescriptionText.text = "생전 강력했던 몬스터의 눈이다.";
                ExItemText.text = "공/마+20%";
                break;
            case "Slime Gel":
                ExItemNameText.text = "슬라임 점액";
                ExItemDescriptionText.text = "생각보다 쫀쫀하다..?";
                ExItemText.text = "상점에 판매시 100G 획득";
                break;
            case "Helm":
                ExItemNameText.text = "기사의 헬름";
                ExItemDescriptionText.text = "이름모를 기사가 사용했던 헬름이다.";
                ExItemText.text = "공격력 +10%,최대채력 +2";
                break;
            case "Iron Armor":
                ExItemNameText.text = "철갑옷";
                ExItemDescriptionText.text = "든든하지만 몸이 무거워진다.";
                ExItemText.text = "최대채력 +2, 이동속도 -1";
                break;
            case "Iron Boot":
                ExItemNameText.text = "철군화";
                ExItemDescriptionText.text = "발이 긁힐 위험은 없어졌지만, 좀 무겁다..";
                ExItemText.text = "최대채력 +1, 이동속도 -1";
                break;
            case "Iron Helmet":
                ExItemNameText.text = "철모";
                ExItemDescriptionText.text = "머리가 안전해진 것이 든든하다.";
                ExItemText.text = "최대채력 +2";
                break;
            case "Leather Armor":
                ExItemNameText.text = "가죽갑옷";
                ExItemDescriptionText.text = "질긴 가죽으로 만들어 가볍다.";
                ExItemText.text = "최대채력 +1, 치명타확률 +10%";
                break;
            case "Leather Boot":
                ExItemNameText.text = "가죽장화";
                ExItemDescriptionText.text = "레인저가 신던 장화다. 몸이 날래지는 기분이 든다.";
                ExItemText.text = "치명타확률 +10%, 이동속도 +1";
                break;
            case "Leather Helmet":
                ExItemNameText.text = "가죽모자";
                ExItemDescriptionText.text = "왠지 비행기를 타야할것 같은 기분이다..";
                ExItemText.text = "이동속도+1, 치명타데미지 +20%";
                break;
            case "Skull":
                ExItemNameText.text = "두개골";
                ExItemDescriptionText.text = "야만인이 된듯한 기분..글로리아!!";
                ExItemText.text = "공격력+50%,최대채력 -3";
                break;
            case "Wizard Hat":
                ExItemNameText.text = "마녀의 모자";
                ExItemDescriptionText.text = "숲의 마녀가 사용하던 모자";
                ExItemText.text = "공격력+30%";
                break;
            case "Beer":
                ExItemNameText.text = "맥주";
                ExItemDescriptionText.text = "더울땐 시원한 맥주한잔!";
                ExItemText.text = "체력3 회복";
                break;
            case "Bone":
                ExItemNameText.text = "뼈";
                ExItemDescriptionText.text = "칼륨 섭취! 뼈가 단단해졌습니다!";
                ExItemText.text = "최대체력 1증가";
                break;
            case "Bread":
                ExItemNameText.text = "빵";
                ExItemDescriptionText.text = "빵은 역시 식빵! 부드럽고 담백한 빵입니다!";
                ExItemText.text = "체력 1회복";
                break;
            case "Fish Steak":
                ExItemNameText.text = "물고기 스테이크";
                ExItemDescriptionText.text = "스테이크입니다! 비록 고기는 아니지만..";
                ExItemText.text = "체력 2 회복";
                break;
            case "Ham":
                ExItemNameText.text = "햄";
                ExItemDescriptionText.text = "판타지의 정석! 한입 크게 하고싶은 생김새!";
                ExItemText.text = "체력 3회복";
                break;
            case "Heart":
                ExItemNameText.text = "생명력";
                ExItemDescriptionText.text = "화이팅입니다! 응원을 받았습니다!";
                ExItemText.text = "최대체력 2증가";
                break;
            case "Monster Meat":
                ExItemNameText.text = "몬스터 고기";
                ExItemDescriptionText.text = "역하지만 어쩌겠습니까! 살아야죠!";
                ExItemText.text = "체력 2 회복, 최대체력 1 감소";
                break;
            case "Wine":
                ExItemNameText.text = "와인(용의 숨결)";
                ExItemDescriptionText.text = "강렬하고 강력한 맛! 용의 숨결처럼 뜨겁고 화려한 와인!";
                ExItemText.text = "상점에 판매시 500G획득";
                break;
            case "Copper Coin":
                ExItemNameText.text = "동화";
                ExItemDescriptionText.text = "흔한 동화입니다.";
                ExItemText.text = "골드 획득량 5% 증가";
                break;
            case "Golden Coin":
                ExItemNameText.text = "금화";
                ExItemDescriptionText.text = "당신도 이제 부자!";
                ExItemText.text = "골드 획득량 25% 증가";
                break;
            case "Golden Ingot":
                ExItemNameText.text = "골드바";
                ExItemDescriptionText.text = "진짜 골드바! 초콜릿은 아닐겁니다..";
                ExItemText.text = "300G 획득";
                break;
            case "Silver Coin":
                ExItemNameText.text = "은화";
                ExItemDescriptionText.text = "나름 귀한 동전입니다.";
                ExItemText.text = "골드 획득량 15% 증가";
                break;
            case "Arrow":
                ExItemNameText.text = "화살";
                ExItemDescriptionText.text = "그다지 좋은 화살은.. 그래도 기존보다는 좋습니다!";
                ExItemText.text = "공격력 +10%";
                break;
            case "Bow":
                ExItemNameText.text = "활";
                ExItemDescriptionText.text = "그다지 좋은 활은… 그래도 기존보다는 좋습니다!\r\n";
                ExItemText.text = "공격력 +10%";
                break;
            case "Emerald Staff":
                ExItemNameText.text = "에메랄드 스태프";
                ExItemDescriptionText.text = "에메랄드는 얼마일까요? 마력반응이 빨라집니다!";
                ExItemText.text = "공격력+15%";
                break;
            case "Golden Sword":
                ExItemNameText.text = "화려한 검";
                ExItemDescriptionText.text = "멋지고 예쁘지만 실용성은 떨어진다. 쓰쓰쓰?";
                ExItemText.text = "공격력 +5%, 치명타 데미지 +30%";
                break;
            case "Iron Shield":
                ExItemNameText.text = "강철방패";
                ExItemDescriptionText.text = "넌 못지나간다!";
                ExItemText.text = "최대체력 +3, 이동속도 -1"; ;
                break;
            case "Iron Sword":
                ExItemNameText.text = "철검";
                ExItemDescriptionText.text = "평범한 철검. 재미없는 검이다\r\n";
                ExItemText.text = "공격력 +10%";
                break;
            case "Knife":
                ExItemNameText.text = "암살자의 단검";
                ExItemDescriptionText.text = "암살자들이 사용하던 단검입니다.";
                ExItemText.text = "치명타 확률 +20%";
                break;
            case "Magic Wand":
                ExItemNameText.text = "딱총나무 지팡이";
                ExItemDescriptionText.text = "Avada Kedavra!";
                ExItemText.text = "마력+50%";
                break;
            case "Sapphire Staff":
                ExItemNameText.text = "사파이어 스태프";
                ExItemDescriptionText.text = "영롱하네요.. 마법공격력이 상승합니다!";
                ExItemText.text = "마력 +10%";
                break;
            case "Silver Sword":
                ExItemNameText.text = "강철검";
                ExItemDescriptionText.text = "실용적이고 단단한 검.";
                ExItemText.text = "공격력 +20%";
                break;
            case "Wooden Shield":
                ExItemNameText.text = "나무방패";
                ExItemDescriptionText.text = "황단목으로 만든 단단한 나무방패!";
                ExItemText.text = "최대체력+2";
                break;
            case "Wooden Staff":
                ExItemNameText.text = "고목나무 스태프";
                ExItemDescriptionText.text = "오래된 나무면..안부러지나,,?";
                ExItemText.text = "마력 +15%";
                break;
            case "Wooden Sword":
                ExItemNameText.text = "나무검";
                ExItemDescriptionText.text = "꼬꼬마 시절 들고놀던 나무검. 생각보다 단단할지도..?\r\n";
                ExItemText.text = "공격력 +5%";
                break;
        }
    }
}
