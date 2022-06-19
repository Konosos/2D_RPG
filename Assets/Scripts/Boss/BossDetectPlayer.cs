using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectPlayer : DetectPlayer
{
    [SerializeField]private BossCtrl bossCtrl;
    [SerializeField]private float nearRange=3f;

    public bool isNear=false;


    // Update is called once per frame
    void Update()
    {
        if(bossCtrl.bossInfor.isDeath)
            return;
        Detect();
        PlayerIsNear();
    }
    protected override void Detect()
    {
        base.Detect();
        if(player.Length >0)
        {
            bossCtrl.bossInfor.detectPlayer=true;
        }
        else
        {
            bossCtrl.bossInfor.detectPlayer=false;
        }
    }
    private void PlayerIsNear()
    {
        Collider2D[] players=Physics2D.OverlapCircleAll(transform.position,nearRange,playerMask);
        if(players.Length>0)
        {
            isNear=true;
        }
        else
        {
            isNear=false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere(transform.position,nearRange);
    }
}
