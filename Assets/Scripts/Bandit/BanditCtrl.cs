using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCtrl : MonoBehaviour
{
    public EnemyInformation enemyInfor;
    // Start is called before the first frame update
    void Awake()
    {
        enemyInfor=GetComponent<EnemyInformation>();
    }
}
