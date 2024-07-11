using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Quest : QuestingTool
{
    public string Type { get; set; }
    public int questID { get; set; }
    public int npcID { get; set; }
    public int subQuestID { get; set; }
    public string description { get; set; }
    public string requirements { get; set; }
    public List<string> staticRewardItems { get; set; }
    public List<string> chooseRewardItems { get; set; }
    public int xMarker { get; set; }
    public int yMarker { get; set; } 
    public Quest(string ?type, int questID, int npcID, string description, string requirements,
        List<string> staticRewardItems, List<string> chooseRewardItems, int xMarker = -1, int yMarker = -1, int subQuestID = -1)
    {
        this.Type = type;
        this.questID = questID;
        this.npcID = npcID;
        this.description = description;
        this.requirements = requirements;
        this.staticRewardItems = staticRewardItems;
        this.chooseRewardItems = chooseRewardItems;
        this.xMarker = xMarker;
        this.yMarker = yMarker;
        this.subQuestID = subQuestID;
    }

    Quest GetQuest()
    {



        return this;
    }


}
