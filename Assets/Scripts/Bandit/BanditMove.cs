using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMove : EnemyMove
{
    private BanditCtrl banditCtrl;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        banditCtrl=GetComponent<BanditCtrl>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(banditCtrl.enemyInfor.canAttack)
            return;
        if(banditCtrl.enemyInfor.isHurting)
            return;
        Translate();
        FlipX();
    }
}
