using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppossumMove : EnemyMove
{
    private OppossumCtrl oppCtrl;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        oppCtrl=GetComponent<OppossumCtrl>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(oppCtrl.enemyInfor.detectPlayer)
            return;
        if(oppCtrl.enemyInfor.isHurting)
            return;
        Translate();
        FlipX();
    }
}
