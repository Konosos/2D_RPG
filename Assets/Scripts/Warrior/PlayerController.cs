using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMov playerMovement;
    public PlayerAnimation playerAnimation;
    public PlayerAttack playerAttack;
    public PlayerInformation playerInfor;
    public PlayerInventorySystem playerInventory;
    public LevelSystem levelSystem;
    public PlayerUI playerUI;
    public PlayerEquipSystem playerEquip;
    public NPC_Dialogue npc_Dialogue;
    // Start is called before the first frame update
    /*void Awake()
    {
        playerMovement=GetComponent<PlayerMov>();
        playerAnimation=GetComponent<PlayerAnimation>();
        playerAttack=GetComponent<PlayerAttack>();
        playerInfor=GetComponent<PlayerInformation>();
        playerInventory=GetComponent<PlayerInventorySystem>();
        levelSystem=GetComponent<LevelSystem>();
        playerUI=GetComponent<PlayerUI>();
        playerEquip=GetComponent<PlayerEquipSystem>();
        npc_Dialogue=GetComponent<NPC_Dialogue>();
    }*/
}
