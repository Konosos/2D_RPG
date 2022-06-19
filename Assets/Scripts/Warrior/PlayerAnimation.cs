using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController playerControl;
    private Animator anim;

    public enum States{Idle,Run,Jump};
    public States state;

    
    // Start is called before the first frame update
    void Start()
    {
        playerControl=GetComponent<PlayerController>();
        anim=GetComponent<Animator>();
        state=States.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStates();
    }
    private void UpdateStates()
    {
        if(playerControl.playerInfor.isHurt)
        {
            HurtState();
        }
        else if(playerControl.playerMovement.isGrounded!=true)
        {
            JumpState();
        }
        else if(playerControl.playerMovement.horizonInput==0)
        {
            IdleState();
        }
        else if(playerControl.playerMovement.horizonInput!=0)
        {
            RunState();
        }
    }
    public void RunState()
    {
        state=States.Run;
        SetState();
    }
    public void IdleState()
    {
        state=States.Idle;
        SetState();
    }
    public void JumpState()
    {
        state=States.Jump;
        SetState();
    }
    private void HurtState()
    {
        anim.SetTrigger("isHurt");
        playerControl.playerInfor.isHurt=false;
    }
    private void SetState()
    {
        anim.SetInteger("States",(int)state);
    }
}
