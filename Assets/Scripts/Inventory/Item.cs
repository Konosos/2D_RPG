using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public enum ItemType{Gold,HealthPotion,ManaPotion,ExpBook,
    LeatherArmor,LeatherBoot,LeatherHelmet,
    IronArmor,IronBoot,IronHelmet,
    WoodenSword,IronSword,SilverSword,GoldenSword,
    Cherry,ChickenHam,GreenApple,Apple};
    public ItemType itemType;
    public int amount;
    public int typeInt;
    public int price;
    
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
            case (int)ItemType.Cherry:          itemType=ItemType.Cherry;break;
            case (int)ItemType.ChickenHam:      itemType=ItemType.ChickenHam;break;
            case (int)ItemType.GreenApple:      itemType=ItemType.GreenApple;break;
            case (int)ItemType.Apple:           itemType=ItemType.Apple;break;
        }
    }
    public int GetPrice()
    {
        switch(typeInt)
        {
            default:
            case (int)ItemType.Gold:            return 10;
            case (int)ItemType.HealthPotion:    return 20;
            case (int)ItemType.ManaPotion:      return 20;
            case (int)ItemType.ExpBook:         return 30;
            case (int)ItemType.LeatherArmor:    return 300;
            case (int)ItemType.LeatherBoot:     return 300;
            case (int)ItemType.LeatherHelmet:   return 300;
            case (int)ItemType.IronArmor:       return 600;
            case (int)ItemType.IronBoot:        return 600;
            case (int)ItemType.IronHelmet:      return 600;
            case (int)ItemType.WoodenSword:     return 200;
            case (int)ItemType.IronSword:       return 400;
            case (int)ItemType.SilverSword:     return 800;
            case (int)ItemType.GoldenSword:     return 1600;
            case (int)ItemType.Cherry:          return 1;
            case (int)ItemType.ChickenHam:      return 1;    
            case (int)ItemType.GreenApple:      return 1;    
            case (int)ItemType.Apple:           return 1;
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
            case (int)ItemType.Cherry:
            case (int)ItemType.ChickenHam:
            case (int)ItemType.GreenApple:
            case (int)ItemType.Apple:
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
            case (int)ItemType.Cherry:
            case (int)ItemType.ChickenHam:
            case (int)ItemType.GreenApple:
            case (int)ItemType.Apple:
            return false;
        }
    }
}
