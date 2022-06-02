using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private PlayerController playerControl;
    private Item item;
    private bool bagOpen=false;


    [SerializeField]private TMP_Text levelText;
    [SerializeField]private GameObject itemInforPanel;
    [SerializeField]private GameObject equipStatPanel;
    [SerializeField]private GameObject inventoryUI;
    [SerializeField]private GameObject invenPanel;
    [SerializeField]private GameObject equipPanel;
    [SerializeField]private Image itemImage;
    [SerializeField]private Text itemName;
    [SerializeField]private Text capText;
    [SerializeField]private Text hpBonus;
    [SerializeField]private Text atkBonus;
    [SerializeField]private Text lvCharInfor;
    [SerializeField]private Text hpCharInfor;
    [SerializeField]private Text atkCharInfor;
    [SerializeField]private Text expCharInfor;
    [SerializeField]private Button useBut;
    [SerializeField]private Button dropBut;
    [SerializeField]private Button removeBut;
    [SerializeField]private Button equipDropBut;
    // Start is called before the first frame update
    void Start()
    {
        playerControl=GetComponent<PlayerController>();
    }

    public void UpdateLevel(int _level)
    {
        levelText.text=_level.ToString();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            if(!bagOpen)
            {
                inventoryUI.gameObject.SetActive(true);
                bagOpen=true;
                ShowInventory();
            }
            else
            {
                inventoryUI.gameObject.SetActive(false);
                bagOpen=false;
                IsShowItemInfor(false);
            }
            
        }
    }
    public void ShowInventory()
    {
        invenPanel.SetActive(true);
        equipPanel.SetActive(false);
        playerControl.playerInventory.RefreshSlot();
        IsShowItemInfor(false);
    }
    public void ShowEquipment()
    {
        invenPanel.SetActive(false);
        equipPanel.SetActive(true);
        playerControl.playerEquip.RefreshEquip();
        lvCharInfor.text="Level : " + playerControl.levelSystem.cur_Level.ToString();
        hpCharInfor.text="HP : " + playerControl.playerInfor.cur_Health.ToString() + 
        "/" + playerControl.playerInfor.healthTotal.ToString();
        atkCharInfor.text="ATK : " + playerControl.playerInfor.atkTotal.ToString();
        expCharInfor.text="EXP : " + playerControl.levelSystem.cur_Exp.ToString() + 
        "/" + playerControl.levelSystem.expLevelUp.ToString();
        IsShowItemInfor(false);
    }
    public void ShowItemInfor(Item _item)
    {
        item=_item;
        IsShowItemInfor(true);
        itemImage.GetComponent<Image>().sprite=item.GetSprite();
        ItemInfor itemInforScr=item.GetItemObject().GetComponent<ItemInfor>();
        itemName.text=itemInforScr.nameItem;
        capText.text=itemInforScr.description;
        if(item.IsEquipment())
        {
            IsShowEquipStat(true);
            EquipmentInfor equipInforScr=item.GetItemObject().GetComponent<EquipmentInfor>();
            hpBonus.text="+ " + equipInforScr.hp;
            atkBonus.text="+ " + equipInforScr.atk;
            if(item.wasEquiped)
            {
                removeBut.gameObject.SetActive(true);
                equipDropBut.gameObject.SetActive(true);
                useBut.gameObject.SetActive(false);
                dropBut.gameObject.SetActive(false);
            }
            else
            {
                useBut.gameObject.SetActive(true);
                dropBut.gameObject.SetActive(true);
                removeBut.gameObject.SetActive(false);
                equipDropBut.gameObject.SetActive(false);
            }
        }
        else
        {
            IsShowEquipStat(false);
        }
    }
    
    public void IsShowEquipStat(bool _isShow)
    {
        equipStatPanel.SetActive(_isShow);
    }

    public void IsShowItemInfor(bool _isShow)
    {
        itemInforPanel.SetActive(_isShow);
    }

    public void UseButton()
    {
        switch(item.itemType)
        {
            default:
            case Item.ItemType.HealthPotion: 

            playerControl.playerInfor.AddHP(20);   
            playerControl.playerInventory.RemoveOneItem(item);
            break;
            case Item.ItemType.Gold:
            Debug.Log("This is Golds");
            break;
            case Item.ItemType.ExpBook:
            playerControl.levelSystem.AddExp(200);
            playerControl.playerInventory.RemoveOneItem(item);
            break;
            case Item.ItemType.LeatherArmor:
            case Item.ItemType.IronArmor:
            playerControl.playerInventory.EquipItem(item,2);
            playerControl.playerEquip.UpdateEquipInfor();
            playerControl.playerInfor.UpdateInfor();
            break;
            case Item.ItemType.LeatherHelmet:
            case Item.ItemType.IronHelmet:
            playerControl.playerInventory.EquipItem(item,1);
            playerControl.playerEquip.UpdateEquipInfor();
            playerControl.playerInfor.UpdateInfor();
            break;
            case Item.ItemType.LeatherBoot:
            case Item.ItemType.IronBoot:
            playerControl.playerInventory.EquipItem(item,3);
            playerControl.playerEquip.UpdateEquipInfor();
            playerControl.playerInfor.UpdateInfor();
            break;
            case Item.ItemType.WoodenSword:
            case Item.ItemType.IronSword:
            case Item.ItemType.SilverSword:
            case Item.ItemType.GoldenSword:
            playerControl.playerInventory.EquipItem(item,0);
            playerControl.playerEquip.UpdateEquipInfor();
            playerControl.playerInfor.UpdateInfor();
            break;
        }
    }

    public void DropButton()
    {
        playerControl.playerInventory.DropItem(item);
        playerControl.playerInventory.RemoveOneItem(item);
    }

    public void RemoveButton()
    {
        playerControl.playerEquip.Remove(item);
        playerControl.playerEquip.RefreshEquip();
        IsShowItemInfor(false);
    }
    public void EquipDropButton()
    {
        playerControl.playerEquip.Drop(item);
        playerControl.playerEquip.RefreshEquip();
        IsShowItemInfor(false);
    }
}
