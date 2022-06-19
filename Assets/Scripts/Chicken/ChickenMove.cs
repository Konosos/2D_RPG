using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove : EnemyMove
{
    [SerializeField]private ChickenCtrl chickenCtrl;
    private void Update()
    {
        if(!chickenCtrl.enemyInfor.isHurting)
            return;
        Translate();
        FlipX();
    }
}
