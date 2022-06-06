using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataSave 
{
    public int save_MaxHealth;
    public int save_CurHealth;
    public int save_Atk;
    public int save_Level;
    public int save_ExpLevelUp;
    public int save_CurExp;
    public int save_Coins;
    public int[] saveEquipType={-1,-1,-1,-1};
    public List<int> saveAmount=new List<int>();
    public List<int> saveTypeItem=new List<int>();

}
