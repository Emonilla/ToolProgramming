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

        TextField npcID = new TextField();
        questID.name = "NPC ID";
        questID.label = "Insert NPC ID";
        root.Add(npcID);





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
        rewardItems.index = 0;
        for (int i = 0; i < itemList.Count; i++)
        {
            rewardItems.choices.Add(itemList[i]);
        }
        root.Add(rewardItems);

        /* A script that shows the UI in an editor window
         * 
         * 
         * 
         */ 
    }    
}
