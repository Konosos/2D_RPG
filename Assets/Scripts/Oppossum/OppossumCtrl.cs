using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppossumCtrl : MonoBehaviour
{
    public OppossumAnimation oppAnim;
    public OppossumMove oppMove;
    public EnemyInformation inform;
    public DetectAndAttack detectAndAttack;
    public EnemyInformation enemyInfor;
    // Start is called before the first frame update
    void Start()
    {
        oppAnim=GetComponent<OppossumAnimation>();
        oppMove=GetComponent<OppossumMove>();
        inform=GetComponent<EnemyInformation>();
        detectAndAttack=GetComponent<DetectAndAttack>();
        enemyInfor=GetComponent<EnemyInformation>();
    }
}
