using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab;
    [SerializeField]private GameObject enemyClone;

    private bool isTimeDown=false;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyClone==null && !isTimeDown)
        {
            Invoke("Spawn",10f);
            isTimeDown=true;
        }
    }
    
    private void Spawn()
    {
        enemyClone=Instantiate(enemyPrefab,trans.position,Quaternion.identity);
        isTimeDown=false;
    }
}
