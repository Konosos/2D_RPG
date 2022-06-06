using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="ListQuest", menuName="Quest/QuestBoard")]
public class QuestBoard : ScriptableObject
{
    public List<Quest> quests;
}
