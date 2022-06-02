using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    protected Transform trans;
    protected Vector3 spawnPosition=Vector3.zero;

    [SerializeField]protected float monsterSpeed=2f;
    [SerializeField]protected float radianMove=3f;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        trans=GetComponent<Transform>();
        spawnPosition=trans.position;
    }
}
