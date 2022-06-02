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
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement=GetComponent<PlayerMov>();
        playerAnimation=GetComponent<PlayerAnimation>();
        playerAttack=GetComponent<PlayerAttack>();
        playerInfor=GetComponent<PlayerInformation>();
        playerInventory=GetComponent<PlayerInventorySystem>();
        levelSystem=GetComponent<LevelSystem>();
        playerUI=GetComponent<PlayerUI>();
        playerEquip=GetComponent<PlayerEquipSystem>();
    }
}
