using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance {get; private set;}
    private void Awake()
    {
        Instance=this;
    }

    public Sprite[] sprItems;

    public GameObject[] objItems;


    public void SpawnItem(Vector3 _pos, Item _item)
    {
        GameObject obj=_item.GetItemObject();
        GameObject itemObj=Instantiate(obj,_pos,Quaternion.identity);
        ItemWorld itemScr=itemObj.GetComponent<ItemWorld>();
        itemScr.SetItem(_item);
    }
}
