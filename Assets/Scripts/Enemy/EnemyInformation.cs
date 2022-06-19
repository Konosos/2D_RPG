using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : Information
{
    [Header("Enemy Information")]
    public bool detectPlayer=false;
    public bool canAttack=false;
    public bool isAttack=false;
    public int enemyID;
    [SerializeField]private Item[] items;
    [SerializeField]private int spawnInt=1;

    protected override void Die()
    {
        base.Die();
        SpawnItem();
    }
    protected virtual void SpawnItem()
    {
        foreach(Item _item in items)
        {
            Vector3 randomDir=Random.insideUnitCircle;
            ItemAsset.Instance.SpawnItem(transform.position +Vector3.up + randomDir,new Item{itemType=_item.itemType,amount=Random.Range(1,2)*spawnInt, typeInt=_item.typeInt});
        }
    }
}
