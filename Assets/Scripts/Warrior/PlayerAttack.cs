using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private PlayerController playerControl;
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange=0.5f;
    [SerializeField]private LayerMask enemy;

    public void Attack()
    {
        Collider2D[] enemies=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemy);
        foreach(Collider2D enemy in enemies)
        {
            EnemyInformation enemyScr=enemy.GetComponent<EnemyInformation>();
            if(enemyScr.cur_Health<=playerControl.playerInfor.atkTotal)
            {
                playerControl.npc_Dialogue.UpdateKillAmount(enemyScr.enemyID);
            }
            enemyScr.TakeDamege(playerControl.playerInfor.atkTotal);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
