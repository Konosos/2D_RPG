using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoAttack : EnemyAttack
{
    [SerializeField]private RinoController rinoCtrl;
    [SerializeField]private float timeStopAttack=1.5f;
    [SerializeField]private float deltaTimeStop=0f;
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange=0.5f;
    [SerializeField]private LayerMask player;
    // Update is called once per frame
    void Update()
    {
        if(rinoCtrl.enemyInfor.isDeath)
            return;
        if(rinoCtrl.enemyInfor.isHurting)
            return;
        if(rinoCtrl.enemyInfor.detectPlayer && !rinoCtrl.enemyInfor.isAttack)
        {
            DelayAttack();
        }
        if(rinoCtrl.enemyInfor.isAttack)
        {
            deltaTimeStop+=Time.deltaTime;
            if(deltaTimeStop>=timeStopAttack)
            {
                rinoCtrl.enemyInfor.isAttack=false;
                deltaTimeStop=0f;
            }
            Attacking();
        }
    }

    protected override void Attack()
    {
        rinoCtrl.enemyInfor.isAttack=true;
        deltaTimeStop=0f;
    }
    private void Attacking()
    {
        Collider2D[] players=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,player);
        foreach(Collider2D play in players)
        {
            PlayerInformation playerScr=play.GetComponent<PlayerInformation>();
            Rigidbody2D rb2d=play.GetComponent<Rigidbody2D>();
            playerScr.TakeDamege(rinoCtrl.enemyInfor.atk);
            if(transform.localScale.x>=0)
            {
                rb2d.AddForce(Vector3.left*3,ForceMode2D.Impulse);
            }
            else
            {
                rb2d.AddForce(Vector3.right*3,ForceMode2D.Impulse);
            }
            rinoCtrl.enemyInfor.isAttack=false;
        }
    }
}
