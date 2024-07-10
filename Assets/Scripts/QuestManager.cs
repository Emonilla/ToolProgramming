using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;
using System.Linq;

public class QuestManager : EditorWindow
{
   List<Quest> questList;
   Quest q;
   [MenuItem("Tools/QuestManager")]
    public static void CreateWindow()
    {
       QuestManager wnd = GetWindow<QuestManager>();
       wnd.titleContent = new GUIContent("Quest Manager");
    }


    private void ValueChanged(ChangeEvent<string> b)
    {
        q = questList.First(q => q.questID.ToString() == b.newValue);
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        questList = new List<Quest>();

        DropdownField questDropDown = new DropdownField();
        questDropDown.name = "Quest List";
        questDropDown.label = "Quest List";
        for (int i = 0; i < questList.Count; i++)
        {
            questDropDown.choices.Add(Convert.ToString(questList[i].questID));
        }
        questDropDown.RegisterValueChangedCallback(ValueChanged);
        root.Add(questDropDown);

        Label L_questType = new Label();
        L_questType.name = "Quest Type";
        L_questType.text = q.Type.ToString();
        root.Add(L_questType);

        Label L_questID = new Label();
        L_questID.name = "Label Quest ID";
        L_questID.text = q.questID.ToString();
        root.Add(L_questID);

        Label L_npcID = new Label();
        L_npcID.name = "Label NPC ID";
        L_npcID.text = q.npcID.ToString();
        root.Add(L_npcID);

        Label L_description = new Label();
        L_description.name = "Label Quest Description";
        L_description.text = q.description;
        root.Add(L_description);

        Label L_requirements = new Label();
        L_requirements.name = "Label Requirements";
        L_requirements.text = q.requirements.ToString();
        root.Add(L_requirements);

        Label L_staticRewardItems = new Label();
        L_staticRewardItems.name = "Label Static Reward Items";
        L_staticRewardItems.text = q.staticRewardItems.ToString();
        root.Add(L_staticRewardItems);

        Label L_chooseRewardItems = new Label();
        L_chooseRewardItems.name = "Label Choose Reward Items";
        L_chooseRewardItems.text = q.chooseRewardItems.ToString();
        root.Add(L_chooseRewardItems);

        Label L_xMarker = new Label();
        L_xMarker.name = "Label Marker X Coordinate";
        L_xMarker.text = q.xMarker.ToString();
        root.Add(L_xMarker);

        Label L_yMarker = new Label();
        L_yMarker.name = "Label Marker Y Coordinate";
        L_yMarker.text = q.yMarker.ToString();
        root.Add(L_yMarker);




    }
}
