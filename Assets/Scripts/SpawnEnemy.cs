using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab;
    [SerializeField]private GameObject enemyClone;
    [SerializeField]private float timeSpawn=10f;

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
            Invoke("Spawn",timeSpawn);
            isTimeDown=true;
        }
    }
    
    private void Spawn()
    {
        enemyClone=Instantiate(enemyPrefab,trans.position,Quaternion.identity);
        isTimeDown=false;
    }
}
