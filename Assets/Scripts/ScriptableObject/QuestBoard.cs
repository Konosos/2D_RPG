using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="ListQuest", menuName="Quest/QuestBoard")]
public class QuestBoard : ScriptableObject
{
    public Dialogue[] dialogues;
    public bool hasQuest=true;
    public int cur_Quest=0;
    public List<Quest> quests;

}
