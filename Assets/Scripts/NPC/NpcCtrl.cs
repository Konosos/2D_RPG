using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCtrl : MonoBehaviour
{
    [SerializeField]private GameObject trigPanel;

    public List<Item> listBuyShop;
    public QuestBoard questBoard;
    public Dialogue[] dialogues;
    public int typeNPC=1;
    public void IsShowTrigPanel(bool _isShow)
    {
        trigPanel.SetActive(_isShow);
    }
}
