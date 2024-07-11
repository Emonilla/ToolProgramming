using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : QuestingTool
{
    
    public string Type { get; set; }
    public int questID { get; set; }
    public int npcID { get; set; }
    public int subQuestID { get; set; }
    public string description { get; set; }
    public Dictionary <GameObject, int> requirements { get; set; }
    public Dictionary<GameObject, int> staticRewardItems { get; set; }
    public Dictionary<GameObject, int> chooseRewardItems { get; set; }
    public int xMarker { get; set; }
    public int yMarker { get; set; } 
    public Quest(string ?type, int questID, int npcID, string description, Dictionary<GameObject, int> requirements, 
        Dictionary<GameObject, int> staticRewardItems, Dictionary<GameObject, int> chooseRewardItems, int xMarker = -1, int yMarker = -1, int subQuestID = -1)
    {
        Type = type;
        this.questID = questID;
        this.npcID = npcID;
        this.subQuestID = subQuestID;
        this.description = description;
        this.requirements = requirements;
        this.staticRewardItems = staticRewardItems;
        this.chooseRewardItems = chooseRewardItems;
        this.xMarker = xMarker;
        this.yMarker = yMarker;
    }

    Quest GetQuest()
    {





        return this;
    }


}
