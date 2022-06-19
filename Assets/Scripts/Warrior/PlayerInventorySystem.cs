using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySystem : MonoBehaviour
{
    [SerializeField]private PlayerController playerControl;
    
    public List<Item> itemList;
    public List<int> amountList;
    public List<int> typeItemList;
    public GameObject slot;
    public Transform panel;

    public int coins=1000;
    [SerializeField]private Transform dropPos;
    

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
    /*public void SaveList()
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
    }*/
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
        playerControl.npc_Dialogue.UpdateGatheringAmount();
    }
    public void RemoveItem(Item item)
    {
        item.amount-=1;
        playerControl.npc_Dialogue.UpdateGatheringAmount();
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
    public void RefreshSlot(List<Item> _listItem,Transform _panel)
    {
        foreach(Transform child in _panel)
        {
            Destroy(child.gameObject);
        }

        int x=0;
        int y=0;
        float sizeX=65f;
        float sizeY=65f;
        foreach(Item item in _listItem)
        {
            RectTransform slots=Instantiate(slot as GameObject).GetComponent<RectTransform>();
            slots.gameObject.transform.SetParent(_panel);
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
        RefreshSlot(GetItemList(),panel);
    }
    public void DropItem(Item _item)
    {
        ItemAsset.Instance.SpawnItem(dropPos.position,new Item{itemType=_item.itemType, amount=1, typeInt=_item.typeInt});
    }
    public void EquipItem(Item _item , int _visit)
    {
        if(playerControl.playerEquip.equipItem[_visit]!=null)
        {
            AddItemToList(playerControl.playerEquip.equipItem[_visit]);
        }
        playerControl.playerEquip.equipItem[_visit]=_item;
        RemoveOneItem(_item);
    }
}
