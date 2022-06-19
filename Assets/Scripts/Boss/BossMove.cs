using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : EnemyMove
{
    [SerializeField]private BossCtrl bossCtrl;

    // Update is called once per frame
    void Update()
    {
        if(bossCtrl.bossInfor.isDeath)
            return;
        if(!bossCtrl.bossDetect.isNear)
            return;
        if(bossCtrl.bossInfor.canAttack)
            return;
        Translate();
    }
}
