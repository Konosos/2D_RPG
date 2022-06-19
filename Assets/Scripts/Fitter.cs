using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fitter : MonoBehaviour
{
    private Transform trans;

    public Vector3 direct=Vector3.zero;
    public BossAttack bossAttack;
    // Start is called before the first frame update
    void Start()
    {
        trans=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.Translate(direct*Time.deltaTime*5);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<PlayerInformation>().TakeFitter();
            bossAttack.Skill(other.gameObject.transform.position);
        }
    }
}
