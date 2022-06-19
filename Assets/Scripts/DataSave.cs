using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataSave 
{
    public int save_MaxHealth=200;
    public int save_CurHealth=200;
    public int save_Atk=40;
    public int save_Level=1;
    public int save_ExpLevelUp=1000;
    public int save_CurExp=0;
    public int save_Coins=1000;
    public int[] saveEquipType=new int[4];
    public List<int> saveAmount=new List<int>();
    public List<int> saveTypeItem=new List<int>();

}
