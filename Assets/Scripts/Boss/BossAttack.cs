using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    [SerializeField]private BossCtrl bossCtrl;
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange=0.5f;
    [SerializeField]private LayerMask player;

    [SerializeField]protected float fitterRate=2f;
    [SerializeField]protected float fitterCoolDown=0f;
    [SerializeField]protected GameObject fitter;
    [SerializeField]private Transform fitterPoint;
    [SerializeField]protected GameObject skill;


    // Update is called once per frame
    void Update()
    {
        if(bossCtrl.bossInfor.isDeath)
            return;
        if(!bossCtrl.bossInfor.detectPlayer)
            return;
        CheckRange();
        if(bossCtrl.bossDetect.isNear)
        {
            if(bossCtrl.bossInfor.canAttack)
            {
                DelayAttack();
            }
        }
        else
        {
            DelayFitter();
        }
    }
    private void DelayFitter()
    {
        fitterCoolDown+=Time.deltaTime;
        if(fitterCoolDown>=fitterRate)
        {
            Fitter();
            fitterCoolDown=0f;
        }
    }
    private void Fitter()
    {
        GameObject fitterClone=Instantiate(fitter,fitterPoint.position,Quaternion.identity);
        Fitter fitterScr=fitterClone.GetComponent<Fitter>();
        fitterScr.bossAttack=this;
        if(transform.localScale.x==1)
        {
            fitterScr.direct=Vector3.left;
        }
        if(transform.localScale.x==-1)
        {
            fitterScr.direct=Vector3.right;
        }
    }
    public void Skill(Vector3 _pos)
    {
        bossCtrl.bossInfor.isSkill=true;
        StartCoroutine(SpawnSkill(_pos));
    }
    private IEnumerator SpawnSkill(Vector3 _pos)
    {
        Vector3 spawnPos=_pos+ new Vector3(0,2.4f,0);
        yield return new WaitForSeconds(0.5f);
        Instantiate(skill,spawnPos,Quaternion.identity);
    }
    private void CheckRange()
    {
        Collider2D[] players=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,player);
        if(players.Length>0)
        {
            bossCtrl.bossInfor.canAttack=true;
        }
        else
        {
            bossCtrl.bossInfor.canAttack=false;
        }
    }
    protected override void Attack()
    {
        bossCtrl.bossInfor.isAttack=true;
        Invoke("AttackPlayer",0.5f);
    }
    private void AttackPlayer()
    {
        Collider2D[] players=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,player);
        foreach(Collider2D player in players)
        {
            
            PlayerInformation playerScr= player.GetComponent<PlayerInformation>();
            playerScr.TakeDamege(bossCtrl.bossInfor.atk);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
