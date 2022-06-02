using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : Information
{
    [Header("Enemy Information")]
    public bool detectPlayer=false;
    public bool canAttack=false;
    public bool isAttack=false;
    

    protected override void Die()
    {
        base.Die();
        ItemAsset.Instance.SpawnItem(transform.position,new Item{itemType=Item.ItemType.HealthPotion,amount=1, typeInt=1});
        ItemAsset.Instance.SpawnItem(transform.position+Vector3.up,new Item{itemType=Item.ItemType.Gold,amount=5, typeInt=0});
        ItemAsset.Instance.SpawnItem(transform.position+Vector3.up*2,new Item{itemType=Item.ItemType.ExpBook,amount=1, typeInt=3});
    }
}
