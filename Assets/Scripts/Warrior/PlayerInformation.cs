using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInformation : Information
{
    [Header("Player")]
    public int healthTotal;
    public int atkTotal;

    [SerializeField]private PlayerController playerControl;

    protected override void Start()
    {
        
    }
    protected override void Die()
    {
        OfDeath();
        cur_Health=100;
        isDeath=false;
        playerControl.playerChangeScene.SaveData();
        StartCoroutine(LoadSceneManager.instance.LoadAsync(1));
    }
    private void OfDeath()
    {
        int _exp=playerControl.levelSystem.cur_Exp;
        if(_exp>_exp/5)
        {
            playerControl.levelSystem.cur_Exp-=playerControl.levelSystem.cur_Exp/5;
        }
        else
        {
            playerControl.levelSystem.cur_Exp=0;
        }
    }
    public void UpdateInfor()
    {
        healthTotal=maxHealth+playerControl.playerEquip.hpBonus;
        atkTotal=atk+playerControl.playerEquip.atkBonus;
        healthBar.SetMaxHealth(healthTotal);
        healthBar.SetHealth(cur_Health);
    }
    public void AddHP(int _hp)
    {
        if(cur_Health+_hp<healthTotal)
        {
            cur_Health+=_hp;
        }
        else
        {
            cur_Health=healthTotal;
        }
        healthBar.SetHealth(cur_Health);
    }
}
