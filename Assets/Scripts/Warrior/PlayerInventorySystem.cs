using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySystem : MonoBehaviour
{
    private PlayerController playerControl;
    
    public List<Item> itemList;
    public List<int> amountList;
    public List<int> typeItemList;
    [SerializeField]private GameObject slot;
    [SerializeField]private Transform panel;
    [SerializeField]private Transform dropPos;
    
    private void Awake()
    {
        itemList=new List<Item>();
        AddItemToList(new Item{itemType=Item.ItemType.Gold, amount=10, typeInt=0});
        AddItemToList(new Item{itemType=Item.ItemType.HealthPotion, amount=1, typeInt=1});
        
    }
    private void Start()
    {
        playerControl=GetComponent<PlayerController>();
        LoadListItem();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            ItemAsset.Instance.SpawnItem(transform.position+Vector3.right*2,new Item{itemType=Item.ItemType.LeatherArmor, amount=1, typeInt=4});
            ItemAsset.Instance.SpawnItem(transform.position+Vector3.right*2,new Item{itemType=Item.ItemType.IronArmor, amount=1, typeInt=7});
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Item")
        {
            AddItemToList(other.GetComponent<ItemWorld>().item);
            Destroy(other.gameObject);
        }
    }
    public void SaveList()
    {
        amountList=new List<int>();
        typeItemList=new List<int>();
        foreach(Item item in GetItemList())
        {
            amountList.Add(item.amount);
            typeItemList.Add((int)item.itemType);
        }
    }
    public void LoadListItem()
    {
        itemList=new List<Item>();
        for(int i=0;i<amountList.Count;i++)
        {
            AddItemToList(new Item{typeInt=typeItemList[i], amount=amountList[i]});
        }
        foreach(Item item in GetItemList())
        {
            item.SetItemType();
        }
    }
    public void AddItemToList(Item item)
    {
        if(item.CanStackable())
        {
            bool inBag=false;
            foreach(Item itemInven in itemList)
            {
                if(itemInven.typeInt==item.typeInt)
                {
                    itemInven.amount+=item.amount;
                    inBag=true;
                }
            }
            if(!inBag)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
    }
    public void RemoveItem(Item item)
    {
        item.amount-=1;
        if(item.amount<=0)
        {
            itemList.Remove(item);
            playerControl.playerUI.IsShowItemInfor(false);
        }
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
    public void RefreshSlot()
    {
        foreach(Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        int x=0;
        int y=0;
        float sizeX=65f;
        float sizeY=65f;
        foreach(Item item in GetItemList())
        {
            RectTransform slots=Instantiate(slot as GameObject).GetComponent<RectTransform>();
            slots.gameObject.transform.SetParent(panel);
            slots.localScale=new Vector3(1,1,1);
            slots.anchoredPosition=new Vector3(-165+x*sizeX,152-y*sizeY,0);
            slots.gameObject.GetComponent<SlotCell>().SetItem(item);
            slots.gameObject.GetComponent<SlotCell>().playerObj=this.gameObject;

            slots.Find("Image").GetComponent<Image>().sprite=item.GetSprite();
            if(item.amount>1)
            {
                slots.Find("amount").GetComponent<Text>().text=item.amount.ToString();
            }
            else
            {
                slots.Find("amount").GetComponent<Text>().text="";
            }
            x++;
            if(x>5)
            {
                x=0;
                y++;
            }
        }
    }

    public void RemoveOneItem(Item _item)
    {
        RemoveItem(_item);
        RefreshSlot();
    }
    public void DropItem(Item _item)
    {
        ItemAsset.Instance.SpawnItem(dropPos.position,new Item{itemType=_item.itemType, amount=1, typeInt=_item.typeInt});
    }
    public void EquipItem(Item _item , int _visit)
    {
        if(playerControl.playerEquip.equipItem[_visit]!=null)
        {
            playerControl.playerEquip.equipItem[_visit].wasEquiped=false;
            AddItemToList(playerControl.playerEquip.equipItem[_visit]);
        }
        playerControl.playerEquip.equipItem[_visit]=_item;
        playerControl.playerEquip.equipItem[_visit].wasEquiped=true;
        RemoveOneItem(_item);
    }
}
