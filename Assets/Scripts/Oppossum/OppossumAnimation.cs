using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppossumAnimation : EnemyAnimation
{
    private OppossumCtrl oppCtrl;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        oppCtrl=GetComponent<OppossumCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(oppCtrl.enemyInfor.detectPlayer)
        {
            Def();
        }
        else
        {
            Run();
        }
        if(oppCtrl.enemyInfor.isHurt)
        {
            Hurt();
        }
    }

    protected override void Hurt()
    {
        base.Hurt();
        oppCtrl.enemyInfor.isHurt=false;
    }
}
