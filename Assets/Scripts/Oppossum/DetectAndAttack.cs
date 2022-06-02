using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndAttack : DetectPlayer
{
    private OppossumCtrl oppCtrl;

    // Start is called before the first frame update
    void Start()
    {
        oppCtrl=GetComponent<OppossumCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        Detect();
    }
    protected override void Detect()
    {
        base.Detect();
        if(player.Length >0)
        {
            oppCtrl.enemyInfor.detectPlayer=true;
        }
        else
        {
            oppCtrl.enemyInfor.detectPlayer=false;
        }
    }
}
