using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipSystem : MonoBehaviour
{
    public Item[] equipItem= new Item[4];
    //public int[] equipItemTypes=new int[4];

    [SerializeField]private GameObject slot;
    [SerializeField]private Transform panel;
    
    public int hpBonus=0;
    public int atkBonus=0;

    [SerializeField]private PlayerController playerControl;

    private void Start()
    {

        //LoadEquipList();
        UpdateEquipInfor();
    }
    /*public void SaveEquipList()
    {
        equipItemTypes=new int[4];
        for(int i=0;i<equipItem.Length;i++)
        {
            equipItemTypes[i]=equipItem[i].typeInt;
        }
    }
    public void LoadEquipList()
    {
        equipItem= new Item[4];
        for(int i=0;i<equipItemTypes.Length;i++)
        {
            equipItem[i]=new Item{typeInt=equipItemTypes[i],amount=1};
        }
        for(int i=0;i<equipItem.Length;i++)
        {
            equipItem[i].SetItemType();
        }
        
    }*/
    public void UpdateEquipInfor()
    {
        hpBonus=0;
        atkBonus=0;
        foreach(Item equip in equipItem)
        {
            EquipmentInfor equipScr=equip.GetItemObject().GetComponent<EquipmentInfor>();
            if(equipScr!=null)
            {
                hpBonus+= equipScr.hp;
                atkBonus+=equipScr.atk;
            }
        }
        playerControl.playerInfor.UpdateInfor();
    }
    public void RefreshEquip()
    {
        foreach(Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        int y=0;

        float sizeY=65f;
        foreach(Item item in equipItem)
        {
            if(item.typeInt!=0)
            {
                RectTransform slots=Instantiate(slot as GameObject).GetComponent<RectTransform>();
                slots.gameObject.transform.SetParent(panel);
                slots.localScale=new Vector3(1,1,1);
                slots.anchoredPosition=new Vector3(-165,152-y*sizeY,0);
                slots.gameObject.GetComponent<SlotCell>().SetItem(item);
                slots.gameObject.GetComponent<SlotCell>().playerObj=this.gameObject;

                slots.Find("Image").GetComponent<Image>().sprite=item.GetSprite();
                slots.Find("amount").GetComponent<Text>().text="";
            }

            y++;
        }
    }
    public void Remove(Item _item)
    {
        for(int i=0;i<equipItem.Length;i++)
        {
            if(equipItem[i]==_item)
            {
                playerControl.playerInventory.AddItemToList(equipItem[i]);
                equipItem[i]=null;
            }
        }
        
    }

    public void Drop(Item _item)
    {
        for(int i=0;i<equipItem.Length;i++)
        {
            if(equipItem[i]==_item)
            {
                playerControl.playerInventory.DropItem(equipItem[i]);
                equipItem[i]=null;
            }
        }
    }
}
