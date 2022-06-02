using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]protected float attackRate=2f;
    [SerializeField]protected float attackCoolDown=0f;

    protected virtual void DelayAttack()
    {
        attackCoolDown+=Time.deltaTime;
        if(attackCoolDown>=attackRate)
        {
            Attack();
            attackCoolDown=0f;
        }
    }
    protected virtual void Attack()
    {
        
    }
}
