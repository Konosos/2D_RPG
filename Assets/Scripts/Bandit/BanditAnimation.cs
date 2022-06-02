using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimation : EnemyAnimation
{
    private BanditCtrl banditCtrl;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        banditCtrl=GetComponent<BanditCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(banditCtrl.enemyInfor.canAttack)
        {
            Def();
        }
        else
        {
            Run();
        }
        if(banditCtrl.enemyInfor.isHurt)
        {
            Hurt();
        }
        if(banditCtrl.enemyInfor.isAttack)
        {
            Attack();
        }
    }

    protected override void Hurt()
    {
        base.Hurt();
        banditCtrl.enemyInfor.isHurt=false;
    }
    protected void Attack()
    {
        anim.SetTrigger("isAttack");
        banditCtrl.enemyInfor.isAttack=false;
    }
}
