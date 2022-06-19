using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    protected Transform trans;
    protected Vector3 spawnPosition=Vector3.zero;

    [SerializeField]protected float monsterSpeed=2f;
    [SerializeField]protected float radianMove=3f;
    [SerializeField]protected float scaleX=1f;
    [SerializeField]protected float dirX=1f;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        trans=GetComponent<Transform>();
        spawnPosition=trans.position;
        scaleX=Mathf.Abs(trans.localScale.x);
    }
    protected virtual void Translate()
    {
        if(trans.localScale.x==scaleX*dirX)
        {
            trans.Translate(Vector3.left*Time.deltaTime*monsterSpeed);
        }
        else if(trans.localScale.x==-scaleX*dirX)
        {
            trans.Translate(Vector3.right*Time.deltaTime*monsterSpeed);
        }
    }
    protected virtual void FlipX()
    {
        if(trans.position.x>=spawnPosition.x+radianMove)
        {
            trans.localScale=new Vector3(scaleX*dirX,scaleX,1);
        }
        else if(trans.position.x<=spawnPosition.x-radianMove)
        {
            trans.localScale=new Vector3(-scaleX*dirX,scaleX,1);
        }
    }
}
