using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerChangeScene : MonoBehaviour
{
    private PlayerController playerControl;

    private void Awake()
    {
        playerControl=GetComponent<PlayerController>();
        LoadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LoadData()
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
    }

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
     public void SaveData()
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
     }
}
