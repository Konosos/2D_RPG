using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAttack : EnemyAttack
{
    private BanditCtrl banditCtrl;
    private PlayerInformation p_Infor;

    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange=0.5f;
    [SerializeField]private LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        banditCtrl=GetComponent<BanditCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(banditCtrl.enemyInfor.isDeath)
            return;
        if(banditCtrl.enemyInfor.isHurting)
            return;
        CheckRange();
        if(banditCtrl.enemyInfor.canAttack)
        {
            DelayAttack();
        }
    }
    private void CheckRange()
    {
        Collider2D[] players=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,player);
        if(players.Length>0)
        {
            banditCtrl.enemyInfor.canAttack=true;
            foreach(Collider2D play in players)
            {
                p_Infor=play.GetComponent<PlayerInformation>();
            }
        }
        else
        {
            banditCtrl.enemyInfor.canAttack=false;
            p_Infor=null;
        }
    }
    protected override void Attack()
    {
        if(banditCtrl.enemyInfor.canAttack=true && p_Infor!=null)
        {
            banditCtrl.enemyInfor.isAttack=true;
            p_Infor.TakeDamege(banditCtrl.enemyInfor.atk);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
