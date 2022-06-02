using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController playerControl;
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange=0.5f;
    [SerializeField]private LayerMask enemy;
    // Start is called before the first frame update
    void Start()
    {
        playerControl=GetComponent<PlayerController>();
    }
    public void Attack()
    {
        Collider2D[] enemies=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemy);
        foreach(Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyInformation>().TakeDamege(playerControl.playerInfor.atkTotal);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
