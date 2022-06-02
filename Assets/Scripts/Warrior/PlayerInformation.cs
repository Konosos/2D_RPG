using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : Information
{
    [Header("Player")]
    public int healthTotal;
    public int atkTotal;

    private PlayerController playerControl;

    protected override void Start()
    {
        base.Start();
        playerControl=GetComponent<PlayerController>();
        UpdateInfor();
    }
    protected override void Die()
    {
        Debug.Log("Player Die!!!");
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
