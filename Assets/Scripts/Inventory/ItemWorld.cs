using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public Item item;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider=GetComponent<BoxCollider2D>();
        rb=GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer==6)
        {
            rb.isKinematic=true;
            boxCollider.isTrigger=true;
        }
        
    }
    public void SetItem(Item _item)
    {
        item=_item;
    }
    public Item GetItem()
    {
        return item;
    }
}
