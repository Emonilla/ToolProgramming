using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;



public class QuestingTool : EditorWindow
{

    [MenuItem("Tools/QuestTool")]
    public static void CreateWindow()
    {
        QuestManager wnd = GetWindow<QuestManager>();
        wnd.titleContent = new GUIContent("Quest Manager");

        // Initialize QuestingTool with a reference to QuestManager
        QuestingTool questingTool = GetWindow<QuestingTool>();
        questingTool.Initialize(wnd);
    }

    public TextField questMarkerX;
    public TextField questMarkerY;
    public TextField subQuest;
    List<string> staticRewardList;
    List<string> rewardList;
    DropdownField questRequirements;
    TextField questID;
    DropdownField questType;
    Button createQuest;
    Toggle subQuestToggle;
    TextField npcID;
    TextField questDescription;
    Quest q;
    QuestManager qManager;
    private QuestManager questManager;
    public void Initialize(QuestManager manager)
    {
        questManager = manager;
    }
    private void QuestMarkerChanged(ChangeEvent<bool> b)
    {
       questMarkerX.visible = b.newValue;
       questMarkerY.visible = b.newValue;
    }

    private void CreateQuestButton(ChangeEvent<string> b)
    {
        Console.WriteLine("Adding Quest");
        int Markerx = int.Parse(questMarkerX.value);
        int Markery = int.Parse(questMarkerY.value);
        int qID = int.Parse(questID.value);
        string type = questType.value;
        int npcid = int.Parse(npcID.value);
        string description = questDescription.value;
        string requirements = questRequirements.value;
        Quest newQuest = new Quest(type, qID, npcid, description, requirements, staticRewardList, rewardList);
        questManager.AddQuest(newQuest);
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
          
          
          
          
          
 
          questRequirements = new DropdownField();
          questRequirements.name = "Quest Requirements";
          questRequirements.label = "Quest Requirements";
          questRequirements.choices.Add("Kill Quest");
          questRequirements.choices.Add("Travel Quest");
          questRequirements.choices.Add("Interaction Quest");
          questRequirements.choices.Add("Collection Quest");
          questRequirements.index = 0;
          root.Add(questRequirements);
          
          
          staticRewardList = new List<string>();
          DropdownField chooseRewardItems = new DropdownField();
          chooseRewardItems.name = "Reward Items";
          chooseRewardItems.label = "Reward Items";
          for (int i = 0; i < staticRewardList.Count; i++)
          {
              chooseRewardItems.choices.Add(staticRewardList[i]);
          }
          chooseRewardItems.index = 0;
          root.Add(chooseRewardItems);
          
          
          rewardList = new List<string>();
          
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
