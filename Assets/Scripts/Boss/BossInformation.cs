using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInformation : EnemyInformation
{
    [SerializeField]private BoxCollider2D coll;
    [SerializeField]private Rigidbody2D rb2d;
    public bool isSkill=false;
    
    protected override void Die()
    {
        coll.isTrigger=true;
        rb2d.isKinematic=true;
        SpawnItem();
        //Invoke("DestroyThis",0.5f);
        Destroy(this.gameObject,1f);
    }
    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
