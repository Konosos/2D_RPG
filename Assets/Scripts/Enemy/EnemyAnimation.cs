using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    protected Animator anim;
    protected enum States{Run,Def};
    protected States state=States.Run;

    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim=GetComponent<Animator>();
    }

    protected virtual void Def()
    {
        state=States.Def;
        anim.SetInteger("States",(int)state);
    }
    protected virtual void Run()
    {
        state=States.Run;
        anim.SetInteger("States",(int)state);
    }
    protected virtual void Hurt()
    {
        anim.SetTrigger("isHurt");
        
    }
}
