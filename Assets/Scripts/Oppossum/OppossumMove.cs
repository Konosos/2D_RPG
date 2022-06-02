using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppossumMove : EnemyMove
{
    private OppossumCtrl oppCtrl;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        oppCtrl=GetComponent<OppossumCtrl>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(oppCtrl.enemyInfor.detectPlayer)
            return;
        if(oppCtrl.enemyInfor.isHurting)
            return;
        if(trans.localScale.x==2)
        {
            trans.Translate(Vector3.left*Time.deltaTime*monsterSpeed);
        }
        else if(trans.localScale.x==-2)
        {
            trans.Translate(Vector3.right*Time.deltaTime*monsterSpeed);
        }
        if(trans.position.x>=spawnPosition.x+radianMove)
        {
            trans.localScale=new Vector3(2,2,1);
        }
        else if(trans.position.x<=spawnPosition.x-radianMove)
        {
            trans.localScale=new Vector3(-2,2,1);
        }
    }
}
