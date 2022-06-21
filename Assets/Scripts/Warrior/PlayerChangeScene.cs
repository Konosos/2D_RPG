using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerChangeScene : MonoBehaviour
{
    [SerializeField]private PlayerController playerControl;
    public PlayerData cur_PlayerData;

    private void Awake()
    {
        LoadData();
        
    }
    private void Start()
    {
        if(cur_PlayerData.save_isNextScene)
        {
            transform.position=LoadSceneManager.instance.startPos.position;
        }
        else
        {
            transform.position=LoadSceneManager.instance.endPos.position;
        }
    }

    private void LoadData()
    {
        playerControl.playerInfor.maxHealth=cur_PlayerData.save_MaxHealth;
        playerControl.playerInfor.cur_Health=cur_PlayerData.save_CurHealth;
        playerControl.playerInfor.atk=cur_PlayerData.save_Atk;
        playerControl.levelSystem.cur_Level=cur_PlayerData.save_Level;
        playerControl.levelSystem.expLevelUp=cur_PlayerData.save_ExpLevelUp;
        playerControl.levelSystem.cur_Exp=cur_PlayerData.save_CurExp;
        playerControl.playerInventory.itemList=cur_PlayerData.saveInven;
        playerControl.playerInventory.coins=cur_PlayerData.save_Coins;
        playerControl.playerEquip.equipItem=cur_PlayerData.saveEquip;
    }

    public void SaveData()
    {
        cur_PlayerData.save_MaxHealth=playerControl.playerInfor.maxHealth;
        cur_PlayerData.save_CurHealth=playerControl.playerInfor.cur_Health;
        cur_PlayerData.save_Atk=playerControl.playerInfor.atk;
        cur_PlayerData.save_Level=playerControl.levelSystem.cur_Level;
        cur_PlayerData.save_ExpLevelUp=playerControl.levelSystem.expLevelUp;
        cur_PlayerData.save_CurExp=playerControl.levelSystem.cur_Exp;
        cur_PlayerData.saveInven=playerControl.playerInventory.itemList;
        cur_PlayerData.save_Coins=playerControl.playerInventory.coins;
        cur_PlayerData.saveEquip=playerControl.playerEquip.equipItem;
    }
}
