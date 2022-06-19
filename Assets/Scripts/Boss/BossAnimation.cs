using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : EnemyAnimation
{
    [SerializeField]private BossCtrl bossCtrl;
    private bool isDie=false;

    // Update is called once per frame
    void Update()
    {
        if(bossCtrl.bossDetect.isNear && !bossCtrl.bossInfor.canAttack)
        {
            Run();
        }
        else
        {
            Def();
        }
        if(bossCtrl.bossInfor.isAttack)
        {
            Attack();
        }
        if(bossCtrl.bossInfor.isSkill)
        {
            Skill();
        }
        if(bossCtrl.bossInfor.isDeath && !isDie)
        {
            Death();
        }
    }
    protected void Attack()
    {
        anim.SetTrigger("isAttack");
        bossCtrl.bossInfor.isAttack=false;
    }
    protected void Skill()
    {
        anim.SetTrigger("isSkill");
        bossCtrl.bossInfor.isSkill=false;
    }
    protected void Death()
    {
        anim.SetTrigger("isDeath");
        isDie=true;
    }
}
