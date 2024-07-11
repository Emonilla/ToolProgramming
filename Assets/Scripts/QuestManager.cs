using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;
using System.Linq;
using System.IO;

public class QuestManager : EditorWindow
{
    public List<Quest> questList;
    Quest q;
    private VisualElement root;
    private DropdownField questDropDown;
    private Label L_questType;
    private Label L_questID;
    private Label L_npcID;
    private Label L_description;
    private Label L_requirements;
    private Label L_staticRewardItems;
    private Label L_chooseRewardItems;
    private Label L_xMarker;
    private Label L_yMarker;
    [MenuItem("Tools/QuestManager")]
    public static void CreateWindow()
    {
        QuestManager wnd = GetWindow<QuestManager>();
        wnd.titleContent = new GUIContent("Quest Manager");
    }

    private void ValueChanged(ChangeEvent<string> b)
    {
        q = questList.First(q => q.questID.ToString() == b.newValue);
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        if (q == null) return;

        L_questType.text = q.Type.ToString();
        L_questID.text = q.questID.ToString();
        L_npcID.text = q.npcID.ToString();
        L_description.text = q.description;
        L_requirements.text = q.requirements.ToString();
        L_staticRewardItems.text = q.staticRewardItems.ToString();
        L_chooseRewardItems.text = q.chooseRewardItems.ToString();
        L_xMarker.text = q.xMarker.ToString();
        L_yMarker.text = q.yMarker.ToString();
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

        L_questType = new Label();
        L_questType.name = "Quest Type";
        L_questType.text = q.Type.ToString();
        root.Add(L_questType);

        L_questID = new Label();
        L_questID.name = "Label Quest ID";
        L_questID.text = q.questID.ToString();
        root.Add(L_questID);

        L_npcID = new Label();
        L_npcID.name = "Label NPC ID";
        L_npcID.text = q.npcID.ToString();
        root.Add(L_npcID);

        L_description = new Label();
        L_description.name = "Label Quest Description";
        L_description.text = q.description;
        root.Add(L_description);

        L_requirements = new Label();
        L_requirements.name = "Label Requirements";
        L_requirements.text = q.requirements.ToString();
        root.Add(L_requirements);

        L_staticRewardItems = new Label();
        L_staticRewardItems.name = "Label Static Reward Items";
        L_staticRewardItems.text = q.staticRewardItems.ToString();
        root.Add(L_staticRewardItems);

        L_chooseRewardItems = new Label();
        L_chooseRewardItems.name = "Label Choose Reward Items";
        L_chooseRewardItems.text = q.chooseRewardItems.ToString();
        root.Add(L_chooseRewardItems);

        L_xMarker = new Label();
        L_xMarker.name = "Label Marker X Coordinate";
        L_xMarker.text = q.xMarker.ToString();
        root.Add(L_xMarker);

        L_yMarker = new Label();
        L_yMarker.name = "Label Marker Y Coordinate";
        L_yMarker.text = q.yMarker.ToString();
        root.Add(L_yMarker);

        UpdateLabels();

        
        Button saveButton = new Button(SaveQuests) { text = "Save Quests" };
        root.Add(saveButton);

        Button loadButton = new Button(LoadQuests) { text = "Load Quests" };
        root.Add(loadButton);
    }
    private void SaveQuests()
    {
        string json = JsonUtility.ToJson(new QuestListWrapper { quests = questList });
        Debug.Log("Saved JSON: " + json); // Print the JSON to the console
        File.WriteAllText(Application.dataPath + "/quests.json", json);
    }

    private void LoadQuests()
    {
        string path = Application.dataPath + "/quests.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            QuestListWrapper wrapper = JsonUtility.FromJson<QuestListWrapper>(json);
            questList = wrapper.quests;

            // Update dropdown
            questDropDown.choices.Clear();
            foreach (var quest in questList)
            {
                questDropDown.choices.Add(quest.questID.ToString());
            }

            // Update the labels with the first quest if available
            if (questList.Count > 0)
            {
                q = questList[0];
                UpdateLabels();
            }
        }
    }
    
}
[Serializable]
public class QuestListWrapper
{
    public List<Quest> quests;
}
