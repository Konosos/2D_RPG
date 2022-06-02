using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppossumAttack : EnemyAttack
{
    private OppossumCtrl oppCtrl;

    [SerializeField]private GameObject bullet;
    [SerializeField]private Transform bulletSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        oppCtrl=GetComponent<OppossumCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(oppCtrl.enemyInfor.isDeath)
            return;
        if(oppCtrl.enemyInfor.isHurting)
            return;
        
        if(oppCtrl.enemyInfor.detectPlayer)
        {
            DelayAttack();
        }
    }
    protected override void Attack()
    {
        GameObject bulletClone=Instantiate(bullet,bulletSpawnPos.position,Quaternion.identity);
        Bullet bulletScr=bulletClone.GetComponent<Bullet>();
        bulletScr.dame=oppCtrl.enemyInfor.atk;
        if(transform.localScale.x==2)
        {
            bulletScr.direct=Vector3.left;
        }
        if(transform.localScale.x==-2)
        {
            bulletScr.direct=Vector3.right;
        }
    }
}
