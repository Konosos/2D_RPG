using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditDetectPlayer : DetectPlayer
{
    private BanditCtrl banditCtrl;

    // Start is called before the first frame update
    void Start()
    {
        banditCtrl=GetComponent<BanditCtrl>();
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
            banditCtrl.enemyInfor.detectPlayer=true;
        }
        else
        {
            banditCtrl.enemyInfor.detectPlayer=false;
        }
    }
}
