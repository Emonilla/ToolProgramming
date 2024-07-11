using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;



public class QuestingTool : EditorWindow
{

    [MenuItem("Tools/QuestTool")]
    public static void CreateWindow()
    {
        QuestingTool wnd = GetWindow<QuestingTool>();
        wnd.titleContent = new GUIContent("QuestTool");
    }

    public TextField questMarkerX;
    public TextField questMarkerY;
    public TextField subQuest;
    TextField questID;
    DropdownField questType;
    Button createQuest;
    Toggle subQuestToggle;
    TextField npcID;
    TextField questDescription;
    Quest q;
    QuestManager qManager;
    private void QuestMarkerChanged(ChangeEvent<bool> b)
    {
       questMarkerX.visible = b.newValue;
       questMarkerY.visible = b.newValue;
    }

    private void CreateQuestButton(ChangeEvent<string> b)
    {
        q.xMarker = int.Parse(questMarkerX.value);
        q.yMarker = int.Parse(questMarkerY.value);
        q.questID = int.Parse(questID.value);
        q.Type = questType.value;
        q.npcID = int.Parse(npcID.value);
        q.description = questDescription.value;
        qManager.questList.Add(q);
    }
    private Quest getQuest() { return q; }

    private void SubQuestToggleChanged(ChangeEvent<bool> b)
    {
       subQuest.visible = b.newValue;
    }

    public void CreateGUI()
    {
             // Each editor window contains a root VisualElement object
             VisualElement root = rootVisualElement;

          questType = new DropdownField();
          questType.name = "QuestType";
          questType.label = "QuestType";
          questType.choices.Add("Main Quest");
          questType.choices.Add("Side Quest");
          questType.index = 0;
          root.Add(questType);

          questID = new TextField();
          questID.name = "Quest ID";
          questID.label = "Insert Quest ID";
          root.Add(questID);


          subQuestToggle = new Toggle();
          subQuestToggle.name = "Sub Quest Toggle";
          subQuestToggle.label = "Activate Sub Quest";
          subQuestToggle.RegisterValueChangedCallback(SubQuestToggleChanged);
          root.Add(subQuestToggle);

          subQuest = new TextField();
          subQuest.name = "Sub Quest";
          subQuest.label = "Insert Sub Quest ID";
          root.Add(subQuest);
          
          npcID = new TextField();
          npcID.name = "NPC ID";
          npcID.label = "Insert NPC ID";
          root.Add(npcID);
          
          questDescription = new TextField();
          questDescription.name = "Quest Description";
          questDescription.label = "Quest Description";
          root.Add(questDescription);     
          
          Toggle questMarker = new Toggle();
          questMarker.name = "Quest Marker";
          questMarker.label = "Activate Quest Marker";
          questMarker.RegisterValueChangedCallback(QuestMarkerChanged);
          root.Add(questMarker);
          
          questMarkerX = new TextField();
          questMarkerX.name = "Quest Marker X";
          questMarkerX.label = "Quest Marker X Coordinates";
          questMarkerX.visible = false;
          root.Add(questMarkerX);
          
          questMarkerY = new TextField();
          questMarkerY.name = "Quest Marker Y";
          questMarkerY.label = "Quest Marker Y Coordinates";
          questMarkerY.visible = false;
          root.Add(questMarkerY);
          
          
          
          
          
 
          DropdownField questRequirements = new DropdownField();
          questRequirements.name = "Quest Requirements";
          questRequirements.label = "Quest Requirements";
          questRequirements.choices.Add("Kill Quest");
          questRequirements.choices.Add("Travel Quest");
          questRequirements.choices.Add("Interaction Quest");
          questRequirements.choices.Add("Collection Quest");
          questRequirements.index = 0;
          root.Add(questRequirements);
          
          
          List<GameObject> staticRewardList = new List<GameObject>();
          
          
          
          
          DropdownField chooseRewardItems = new DropdownField();
          chooseRewardItems.name = "Reward Items";
          chooseRewardItems.label = "Reward Items";
          for (int i = 0; i < staticRewardList.Count; i++)
          {
              chooseRewardItems.choices.Add(staticRewardList[i].name);
          }
          chooseRewardItems.index = 0;
          root.Add(chooseRewardItems);
          
          /* A script that shows the UI in an editor window
           * 
           * 
           * 
           */
          
          List<string> rewardList = new List<string>();
          
          rewardList.Add("TreeGenerator");
          rewardList.Add("Coins");
          
          DropdownField dynamicRewadsItems = new DropdownField();
          dynamicRewadsItems.name = "Dynamic Reward Items";
          dynamicRewadsItems.label = "Dynamic Reward Items";
          
          for (int i = 0; i < rewardList.Count; i++)
          {
              dynamicRewadsItems.choices.Add(rewardList[i]);
          }
          dynamicRewadsItems.index = 0;
          root.Add(dynamicRewadsItems);

        createQuest = new Button();
        createQuest.name = "Create Quest";
        createQuest.text = "Create Quest";
        root.Add(createQuest);

        createQuest.RegisterValueChangedCallback(CreateQuestButton);



    }    
}
