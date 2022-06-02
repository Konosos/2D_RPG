using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlotCell : MonoBehaviour
{
    private Item item;
    private PlayerController playerControl;
    public GameObject playerObj;


    private void Start()
    {
        playerControl=playerObj.GetComponent<PlayerController>();
    }

    public void SetItem(Item item)
    {
        this.item=item;
    }

    public void ClickButton()
    {
        playerControl.playerUI.ShowItemInfor(item);
    }
}
