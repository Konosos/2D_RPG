using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    [SerializeField]private float lookRange=3f;
    [SerializeField]private LayerMask npcLayer;
    [SerializeField]private PlayerController playerControl;
    
    public NpcCtrl npcCtrl=null;
    public Quest quest=null;
    
    // Update is called once per frame
    void Update()
    {
        LookNPC();
        if(Input.GetKeyUp(KeyCode.F) && npcCtrl!=null)
        {
            switch(npcCtrl.typeNPC)
            {
                case 1:
                case 2:DialogueManager.Instance.StartSomeDialogue(npcCtrl.dialogues,npcCtrl.typeNPC);break;
                case 3:
                if(npcCtrl.questBoard.quests.Count>0)
                {
                    QuestIsActive();
                }
                else 
                {
                    DialogueManager.Instance.StartSomeDialogue(npcCtrl.dialogues,npcCtrl.typeNPC);
                }
                break;
            }
            
        }
    }
    private void QuestIsReached()
    {
        if(quest.IsReached())
        {
            DialogueManager.Instance.StartSomeDialogue(npcCtrl.dialogues,npcCtrl.typeNPC);
        }
        else
        {
            DialogueManager.Instance.StartSomeDialogue(npcCtrl.dialogues,npcCtrl.typeNPC);
        }
    }
    private void QuestIsActive()
    {
        if(!quest.isActive)
        {
            DialogueManager.Instance.StartSomeDialogue(npcCtrl.dialogues,npcCtrl.typeNPC);
        }
        else
        {
            QuestIsReached();
        }
    }
    
    public void QuestNPCDia()
    {
        if(npcCtrl.questBoard.quests.Count<=0)
            return;
        if(!quest.isActive)
        {
            quest=npcCtrl.questBoard.quests[0];
            quest.isActive=true;
            UpdateGatheringAmount();
        }
        else
        {
            IfQuestIsActive();
        }
    }
    private void IfQuestIsActive()
    {
        if(!quest.IsReached())
            return;
        GetReward();

        npcCtrl.questBoard.quests.Remove(quest);
        quest.isActive=false;
        if(quest.IsGatheringQuest())
        {
            GiveItemToNPC();
        }
    }
    private void GiveItemToNPC()
    {
        foreach(Item _item in playerControl.playerInventory.GetItemList())
        {
            if(_item.typeInt==quest.goalID)
            {
                _item.amount-=quest.requiredAmount;
            }
        }
    }
    private void GetReward()
    {
        playerControl.playerInventory.coins+=quest.coinsReward;
        playerControl.playerInventory.AddItemToList(new Item{itemType=Item.ItemType.ExpBook,amount=quest.expBookReward, typeInt=3});
    }
    public void UpdateGatheringAmount()
    {
        if(quest.IsGatheringQuest() && quest.isActive)
        {
            foreach(Item _item in playerControl.playerInventory.GetItemList())
            {
                if(_item.typeInt==quest.goalID)
                {
                    quest.currentAmount=_item.amount;
                }
            }
        }
    }
    public void UpdateKillAmount(int _enemyID)
    {
        if(quest.IsKillQuest() && quest.isActive && quest.goalID==_enemyID)
        {
            quest.currentAmount++;
        }
    }
    private void LookNPC()
    {
        Collider2D[] npcs=Physics2D.OverlapCircleAll(transform.position,lookRange,npcLayer);
        if(npcs.Length<=0 && npcCtrl!=null)
        {
            npcCtrl.IsShowTrigPanel(false);
            npcCtrl=null;
        }

        if(npcCtrl!=null)
            return;
        foreach(Collider2D npc in npcs)
        {
            npcCtrl=npc.GetComponent<NpcCtrl>();
            npcCtrl.IsShowTrigPanel(true);
            
        }

    }
}
