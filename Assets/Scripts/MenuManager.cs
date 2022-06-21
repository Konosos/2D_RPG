using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]private QuestBoard questBoard;
    [SerializeField]private PlayerData cur_PlayerData;
    [SerializeField]private PlayerData startPlayerData;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.SetSlider();
    }
    
    public void ContinueButton()
    {
        StartCoroutine(LoadSceneManager.instance.LoadAsync(cur_PlayerData.save_CurSceneIndex));
    }
    public void NewGameButton(int _map1)
    {
        ResetPlayerData();
        ResetQuestList();
        StartCoroutine(LoadSceneManager.instance.LoadAsync(_map1));
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    private void ResetPlayerData()
    {
        cur_PlayerData.save_MaxHealth=startPlayerData.save_MaxHealth;
        cur_PlayerData.save_CurHealth=startPlayerData.save_CurHealth;
        cur_PlayerData.save_Atk=startPlayerData.save_Atk;
        cur_PlayerData.save_Level=startPlayerData.save_Level;
        cur_PlayerData.save_ExpLevelUp=startPlayerData.save_ExpLevelUp;
        cur_PlayerData.save_CurExp=startPlayerData.save_CurExp;
        cur_PlayerData.save_Coins=startPlayerData.save_Coins;
        cur_PlayerData.save_CurSceneIndex=startPlayerData.save_CurSceneIndex;
        cur_PlayerData.save_isNextScene=startPlayerData.save_isNextScene;
        cur_PlayerData.saveInven=new List<Item>();
        //cur_PlayerData.saveEquip=new Item[4];
        ResetEquip();
    }
    private void ResetEquip()
    {
        foreach(Item equip in cur_PlayerData.saveEquip)
        {
            equip.itemType=0;
            equip.typeInt=0;
        }
    }
    private void ResetQuestList()
    {
        questBoard.hasQuest=true;
        questBoard.cur_Quest=0;
        foreach(Quest quest in questBoard.quests)
        {
            quest.isActive=false;
            quest.currentAmount=0;
        }
    }
}
