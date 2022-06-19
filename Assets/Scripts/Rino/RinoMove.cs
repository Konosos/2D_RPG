using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoMove : EnemyMove
{
    [SerializeField]private RinoController rinoCtrl;
    
    public bool goSpawnPos=false;
    // Update is called once per frame
    void Update()
    {
        if(rinoCtrl.enemyInfor.isHurting)
            return;
        if(rinoCtrl.enemyInfor.isAttack || goSpawnPos)
        {
            Translate();
        }
    }

    public void BackSpawnPos()
    {
        
        if(Mathf.Abs(trans.position.x-spawnPosition.x)<=0.5f)
        {
            goSpawnPos=false;
            return;
        }
        if(trans.position.x>spawnPosition.x)
        {
            trans.localScale=new Vector3(1.5f,1.5f,1);
        }
        else if(trans.position.x<spawnPosition.x)
        {
            trans.localScale=new Vector3(-1.5f,1.5f,1);
        }
        goSpawnPos=true;
    }
}
