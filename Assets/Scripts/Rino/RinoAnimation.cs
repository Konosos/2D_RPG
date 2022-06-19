using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoAnimation : EnemyAnimation
{
    [SerializeField]private RinoController rinoCtrl;
    
    // Update is called once per frame
    void Update()
    {
        if(rinoCtrl.enemyInfor.isHurt)
        {
            Hurt();
        }
        
        if(rinoCtrl.enemyInfor.detectPlayer)
        {
            IfDetectPlayerTrue();
        }
        else
        {
            IfDetectPlayerFalse();
        }
    }
    private void IfDetectPlayerTrue()
    {
        if(rinoCtrl.enemyInfor.isAttack)
        {
            Run();
        }
        else
        {
            Def();
        }
    }
    private void IfDetectPlayerFalse()
    {
        if(rinoCtrl.rinoMove.goSpawnPos)
        {
            Run();
        }
        else
        {
            Def();
        }
    }
    protected override void Hurt()
    {
        base.Hurt();
        rinoCtrl.enemyInfor.isHurt=false;
        rinoCtrl.enemyInfor.isAttack=false;
    }
}
