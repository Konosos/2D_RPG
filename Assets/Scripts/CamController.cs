using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField]private Transform playerTrans;
    [SerializeField]private float xMax;
    [SerializeField]private float xMin;
    
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans=GetComponent<Transform>();
        trans.position=new Vector3(playerTrans.position.x,playerTrans.position.y+2,trans.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        float posX= playerTrans.position.x;
        posX=Mathf.Clamp(posX,xMin,xMax);
        trans.position=new Vector3(posX,playerTrans.position.y+2,trans.position.z);
    }
}
