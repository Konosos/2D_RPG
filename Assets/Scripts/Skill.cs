using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange=0.5f;
    [SerializeField]private LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AttackPlayer",0.5f);
    }

    private void AttackPlayer()
    {
        Collider2D[] players=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,player);
        foreach(Collider2D player in players)
        {
            
            PlayerInformation playerScr= player.GetComponent<PlayerInformation>();
            playerScr.TakeDamege(150);
        }
        Destroy(this.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
