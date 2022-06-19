using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]private Item item;
    [SerializeField]private GameObject itemClone;
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
        if(itemClone==null && !isTimeDown)
        {
            Invoke("Spawn",timeSpawn);
            isTimeDown=true;
        }
    }
    
    private void Spawn()
    {
        GameObject obj=item.GetItemObject();
        itemClone=Instantiate(obj,trans.position,Quaternion.identity);
        ItemWorld itemScr=itemClone.GetComponent<ItemWorld>();
        itemScr.SetItem(new Item{itemType=item.itemType, amount=1, typeInt=item.typeInt});
        isTimeDown=false;
    }
}
