using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoDetectPlayer : DetectPlayer
{
    [SerializeField]private RinoController rinoCtrl;
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
            rinoCtrl.enemyInfor.detectPlayer=true;
            rinoCtrl.rinoMove.goSpawnPos=false;
        }
        else
        {
            rinoCtrl.enemyInfor.detectPlayer=false;
            rinoCtrl.rinoMove.BackSpawnPos();
        }
    }
}
