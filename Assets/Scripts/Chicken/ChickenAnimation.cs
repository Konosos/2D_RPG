using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAnimation : EnemyAnimation
{
    [SerializeField]private ChickenCtrl chickenCtrl;

    // Update is called once per frame
    void Update()
    {
        if(chickenCtrl.enemyInfor.isHurting)
        {
            Run();
        }
        else
        {
            Def();
        }
    }
}
