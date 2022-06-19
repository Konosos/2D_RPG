using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PlayerData", menuName="PlayerData")]
public class PlayerData : ScriptableObject
{
    public int save_MaxHealth;
    public int save_CurHealth;
    public int save_Atk;
    public int save_Level;
    public int save_ExpLevelUp;
    public int save_CurExp;
    public int save_Coins;
    public int save_CurSceneIndex;
    public bool save_isNextScene;
    public Item[] saveEquip=new Item[4];
    public List<Item> saveInven=new List<Item>();

}
