using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMove : EnemyMove
{
    private BanditCtrl banditCtrl;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        banditCtrl=GetComponent<BanditCtrl>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(banditCtrl.enemyInfor.canAttack)
            return;
        if(banditCtrl.enemyInfor.isHurting)
            return;
        if(trans.localScale.x==1.5f)
        {
            trans.Translate(Vector3.left*Time.deltaTime*monsterSpeed);
        }
        else if(trans.localScale.x==-1.5f)
        {
            trans.Translate(Vector3.right*Time.deltaTime*monsterSpeed);
        }
        if(trans.position.x>=spawnPosition.x+radianMove)
        {
            trans.localScale=new Vector3(1.5f,1.5f,1);
        }
        else if(trans.position.x<=spawnPosition.x-radianMove)
        {
            trans.localScale=new Vector3(-1.5f,1.5f,1);
        }
    }
}
