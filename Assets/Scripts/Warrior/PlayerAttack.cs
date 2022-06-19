using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private PlayerController playerControl;
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange=0.5f;
    [SerializeField]private LayerMask enemy;

    public bool continueAttack;
    public bool inContinueAttackTime;

    public float attackRate=3f;
    private float nextAttackTime=0f;

    public static PlayerAttack instance;

    void Awake()
    {
        instance=this;
    }
    private void Update()
    {
        AttackCombo();
    }
    private void AttackCombo()
    {
        if(Time.time>=nextAttackTime)
        {
            if(Input.GetMouseButtonDown(0) && inContinueAttackTime)
            {
                if(playerControl.playerInfor.isHurting)
                    return;
                continueAttack=true;
                inContinueAttackTime=false;
                Attack();
                nextAttackTime=Time.time+1/attackRate;
            }
        }
    }

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
            SoundManager.instance.PlaySwordSound();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
