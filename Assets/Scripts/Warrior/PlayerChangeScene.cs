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
    /*private void LoadData()
    {
        if(PlayerPrefs.GetString("Json")!="")
        {
            string json=PlayerPrefs.GetString("Json");
            DataSave data=JsonUtility.FromJson<DataSave>(json);
            playerControl.playerInfor.maxHealth=data.save_MaxHealth;
            playerControl.playerInfor.cur_Health=data.save_CurHealth;
            playerControl.playerInfor.atk=data.save_Atk;
            playerControl.levelSystem.cur_Level=data.save_Level;
            playerControl.levelSystem.expLevelUp=data.save_ExpLevelUp;
            playerControl.levelSystem.cur_Exp=data.save_CurExp;
            playerControl.playerInventory.typeItemList=data.saveTypeItem;
            playerControl.playerInventory.amountList=data.saveAmount;
            playerControl.playerInventory.coins=data.save_Coins;
            playerControl.playerEquip.equipItemTypes=data.saveEquipType;
        }
        else
        {
            playerControl.playerInfor.maxHealth=200;
            playerControl.playerInfor.cur_Health=200;
            playerControl.playerInfor.atk=40;
            playerControl.levelSystem.cur_Level=1;
            playerControl.levelSystem.expLevelUp=1000;
            playerControl.levelSystem.cur_Exp=0;
            playerControl.playerInventory.typeItemList=new List<int>();
            playerControl.playerInventory.amountList=new List<int>();
            playerControl.playerInventory.coins=1010;
            playerControl.playerEquip.equipItemTypes=new int[4];
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            LoadData();
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            SaveData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    /*public void SaveData()
     {
         DataSave data=new DataSave();

        data.save_MaxHealth=playerControl.playerInfor.maxHealth;
        data.save_CurHealth=playerControl.playerInfor.cur_Health;
        data.save_Atk=playerControl.playerInfor.atk;
        data.save_Level=playerControl.levelSystem.cur_Level;
        data.save_ExpLevelUp=playerControl.levelSystem.expLevelUp;
        data.save_CurExp=playerControl.levelSystem.cur_Exp;
        playerControl.playerInventory.SaveList();
        data.saveTypeItem=playerControl.playerInventory.typeItemList;
        data.saveAmount=playerControl.playerInventory.amountList;
        data.save_Coins=playerControl.playerInventory.coins;
        playerControl.playerEquip.SaveEquipList();
        data.saveEquipType=playerControl.playerEquip.equipItemTypes;
        string json=JsonUtility.ToJson(data,true);
        Debug.Log(json);
        PlayerPrefs.SetString("Json",json);
    }*/
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
