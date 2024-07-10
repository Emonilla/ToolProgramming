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
    Button createQuest;
    Quest q;
    private void QuestMarkerChanged(ChangeEvent<bool> b)
    {
       questMarkerX.visible = b.newValue;
       questMarkerY.visible = b.newValue;
    }

    private void CreateQuestButton(ChangeEvent<string> b)
    {
       
        q.xMarker = int.Parse(questMarkerX.value);
    }

    private void SubQuestToggleChanged(ChangeEvent<bool> b)
    {
       subQuest.visible = b.newValue;
    }

    public void CreateGUI()
    {
             // Each editor window contains a root VisualElement object
             VisualElement root = rootVisualElement;

          DropdownField dropdownField = new DropdownField();
          dropdownField.name = "QuestType";
          dropdownField.label = "QuestType";
          dropdownField.choices.Add("Main Quest");
          dropdownField.choices.Add("Side Quest");
          dropdownField.index = 0;
          root.Add(dropdownField);

          TextField questID = new TextField();
          questID.name = "Quest ID";
          questID.label = "Insert Quest ID";
          root.Add(questID);


          Toggle subQuestToggle = new Toggle();
          subQuestToggle.name = "Sub Quest Toggle";
          subQuestToggle.label = "Activate Sub Quest";
          subQuestToggle.RegisterValueChangedCallback(SubQuestToggleChanged);
          root.Add(subQuestToggle);

          subQuest = new TextField();
          subQuest.name = "Sub Quest";
          subQuest.label = "Insert Sub Quest ID";
          root.Add(subQuest);
          
          TextField npcID = new TextField();
          npcID.name = "NPC ID";
          npcID.label = "Insert NPC ID";
          root.Add(npcID);
          
          TextField questDescription = new TextField();
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
          
          
          
          List<string> itemList = new List<string>();
          
          /* Change List type to GameObject
          * 
          * 
          * 
          */
          
          itemList.Add("Marcos Mutter");
          itemList.Add("Marcos Mutter2");
          
          DropdownField questRequirements = new DropdownField();
          questRequirements.name = "Quest Requirements";
          questRequirements.label = "Quest Requirements";
          questRequirements.choices.Add("Kill Quest");
          questRequirements.choices.Add("Travel Quest");
          questRequirements.choices.Add("Interaction Quest");
          questRequirements.choices.Add("Collection Quest");
          questRequirements.index = 0;
          root.Add(questRequirements);
          
          
          
          
          
          DropdownField rewardItems = new DropdownField();
          rewardItems.name = "Reward Items";
          rewardItems.label = "Reward Items";
          for (int i = 0; i < itemList.Count; i++)
          {
              rewardItems.choices.Add(itemList[i]);
          }
          rewardItems.index = 0;
          root.Add(rewardItems);
          
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
