using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripe : MonoBehaviour
{
    [SerializeField]private ItemWorld itemWorld;
    [SerializeField]private SpriteRenderer spRen;
    [SerializeField]private float timeRipe=3;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("AppleRipe",timeRipe);
    }

    private void AppleRipe()
    {
        itemWorld.item=new Item{itemType=Item.ItemType.Apple, amount=1, typeInt=17};
        spRen.sprite=itemWorld.item.GetSprite();
    }
}
