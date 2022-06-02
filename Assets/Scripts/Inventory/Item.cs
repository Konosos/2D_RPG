using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType{Gold,HealthPotion,ManaPotion,ExpBook,
    LeatherArmor,LeatherBoot,LeatherHelmet,
    IronArmor,IronBoot,IronHelmet,WoodenSword,IronSword,SilverSword,GoldenSword};
    public ItemType itemType;
    public int amount;
    public int typeInt;
    public bool wasEquiped=false;
    
    public void SetItemType()
    {
        switch(typeInt)
        {
            
            case (int)ItemType.Gold:            itemType=ItemType.Gold;break;
            case (int)ItemType.HealthPotion:    itemType=ItemType.HealthPotion;break;
            case (int)ItemType.ManaPotion:      itemType=ItemType.ManaPotion;break;
            case (int)ItemType.ExpBook:         itemType=ItemType.ExpBook;break;
            case (int)ItemType.LeatherArmor:    itemType=ItemType.LeatherArmor;break;
            case (int)ItemType.LeatherBoot:     itemType=ItemType.LeatherBoot;break;
            case (int)ItemType.LeatherHelmet:   itemType=ItemType.LeatherHelmet;break;
            case (int)ItemType.IronArmor:       itemType=ItemType.IronArmor;break;
            case (int)ItemType.IronBoot:        itemType=ItemType.IronBoot;break;
            case (int)ItemType.IronHelmet:      itemType=ItemType.IronHelmet;break;
            case (int)ItemType.WoodenSword:     itemType=ItemType.WoodenSword;break;
            case (int)ItemType.IronSword:       itemType=ItemType.IronSword;break;
            case (int)ItemType.SilverSword:     itemType=ItemType.SilverSword;break;
            case (int)ItemType.GoldenSword:     itemType=ItemType.GoldenSword;break;
        }
    }
    public Sprite GetSprite()
    {
        return ItemAsset.Instance.sprItems[typeInt];
    }
    public GameObject GetItemObject()
    {
        return ItemAsset.Instance.objItems[typeInt];
    }
    public bool CanStackable()
    {
        switch(typeInt)
        {
            default:
            case (int)ItemType.LeatherArmor: 
            case (int)ItemType.LeatherBoot:
            case (int)ItemType.LeatherHelmet:
            case (int)ItemType.IronArmor:
            case (int)ItemType.IronBoot:
            case (int)ItemType.IronHelmet: 
            case (int)ItemType.WoodenSword:
            case (int)ItemType.IronSword:
            case (int)ItemType.SilverSword:
            case (int)ItemType.GoldenSword: 
            return false;
            case (int)ItemType.HealthPotion:
            case (int)ItemType.ManaPotion:
            case (int)ItemType.Gold:
            case (int)ItemType.ExpBook:
            return true;
        }
    }
    public bool IsEquipment()
    {
        switch(typeInt)
        {
            default:
            case (int)ItemType.LeatherArmor: 
            case (int)ItemType.LeatherBoot:
            case (int)ItemType.LeatherHelmet:
            case (int)ItemType.IronArmor:
            case (int)ItemType.IronBoot:
            case (int)ItemType.IronHelmet: 
            case (int)ItemType.WoodenSword:
            case (int)ItemType.IronSword:
            case (int)ItemType.SilverSword:
            case (int)ItemType.GoldenSword: 
            return true;
            case (int)ItemType.HealthPotion:
            case (int)ItemType.ManaPotion:
            case (int)ItemType.Gold:
            case (int)ItemType.ExpBook:
            return false;
        }
    }
}
