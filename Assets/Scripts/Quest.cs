using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public bool isActive;
    public Dialogue[] startDialogues;
    public Dialogue[] finishDialogues;

    public string title;
    [TextArea(2, 5)]
    public string description;
    public int expBookReward;
    public int coinsReward;
    public enum GoalType{Kill,Gathering}
    public GoalType goalType;
    public int goalID;
    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount>=requiredAmount);
    }
    public bool IsGatheringQuest()
    {
        if(goalType==GoalType.Gathering)
            return true;
        return false;
    }
    public bool IsKillQuest()
    {
        if(goalType==GoalType.Kill)
            return true;
        return false;
    }
    
}
