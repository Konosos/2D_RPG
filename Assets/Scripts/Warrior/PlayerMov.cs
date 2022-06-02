using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Transform trans;
    private PlayerController playerControl;

    [SerializeField]private float m_Speed=2;
    [SerializeField]private float m_JumpForce=5;
    [SerializeField]private LayerMask m_Ground;
    [SerializeField]private Transform m_GroundCheck;
    [SerializeField]private float m_GroundCheckRadius=0.2f;

    public float horizonInput;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        trans=GetComponent<Transform>();
        playerControl=GetComponent<PlayerController>();
        trans.localScale=new Vector3(2,2,2);
    }
    private void Update()
    {
        horizonInput=Input.GetAxis("Horizontal");
        GroundCheck();
    }
    
    void FixedUpdate()
    {
        if(playerControl.playerInfor.isHurting)
            return;
        Vector3 moveDerect=new Vector3(horizonInput,0,0);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if(horizonInput!=0)
        {
            if(horizonInput<0)
            {
                MoveLeft(moveDerect);
            }
            else
            if(horizonInput>0)
            {
                MoveRight(moveDerect);
            }
            
        }       
    }
    public void GroundCheck()
    {
        
        Collider2D[] colliders=Physics2D.OverlapCircleAll(m_GroundCheck.position,m_GroundCheckRadius,m_Ground);
        if(colliders.Length>0)
        {
            isGrounded=true;
        }
        else
        {
            isGrounded=false;
        }
    }
    private void Jump()
    {
        rb2d.AddForce(transform.up*m_JumpForce,ForceMode2D.Impulse);
    }
    private void MoveLeft(Vector3 horizon)
    {
        trans.Translate(horizon*Time.deltaTime*m_Speed);
        trans.localScale=new Vector3(-2,2,2);
    }
    private void MoveRight(Vector3 horizon)
    {
        trans.Translate(horizon*Time.deltaTime*m_Speed);
        trans.localScale=new Vector3(2,2,2);
    }
}
