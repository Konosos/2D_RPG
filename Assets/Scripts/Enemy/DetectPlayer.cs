using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]protected float detectRange=3f;
    [SerializeField]protected LayerMask playerMask;
    protected Collider2D[] player;

    protected virtual void Detect()
    {
        player=Physics2D.OverlapCircleAll(transform.position,detectRange,playerMask);
        
        foreach(Collider2D var in player)
        {
            float abs_LocalScaleX=Mathf.Abs(transform.localScale.x);
            if(var.transform.position.x<transform.position.x)
            {
                transform.localScale=new Vector3(abs_LocalScaleX,transform.localScale.y,1);
            }
            else
            {
                transform.localScale=new Vector3(-1*abs_LocalScaleX,transform.localScale.y,1);
            }
        }
    }
}
