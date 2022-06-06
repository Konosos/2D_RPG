using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int cur_Level=1;
    public int expLevelUp=1000;
    public int cur_Exp=0;

    private PlayerController playerControl;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl=GetComponent<PlayerController>();
        playerControl.playerUI.UpdateLevel(cur_Level);
    }

    public void AddExp(int _exp)
    {
        cur_Exp+=_exp;
        if(cur_Exp>=expLevelUp)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        cur_Level++;
        cur_Exp-=expLevelUp;
        expLevelUp+=expLevelUp/10;
        playerControl.playerInfor.atk+=playerControl.playerInfor.atk/10;
        playerControl.playerInfor.maxHealth+=playerControl.playerInfor.maxHealth/10;
        playerControl.playerUI.UpdateLevel(cur_Level);
    }
}
