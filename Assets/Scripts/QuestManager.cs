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
    private Quest q;
    private VisualElement root;
    private DropdownField questDropDown;
    private Label questType;
    private Label questID;
    private Label npcID;
    private Label description;
    private Label requirements;
    private Label staticRewardItems;
    private Label chooseRewardItems;
    private Label xMarker;
    private Label yMarker;

    [MenuItem("Tools/QuestManager")]
    public static void CreateWindow()
    {
        QuestManager wnd = GetWindow<QuestManager>();
        wnd.titleContent = new GUIContent("Quest Manager");
    }

    private void ValueChanged(ChangeEvent<string> evt)
    {
        q = questList.FirstOrDefault(q => q.questID.ToString() == evt.newValue);
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        if (q == null) return;

        questType.text = q.Type.ToString();
        questID.text = q.questID.ToString();
        npcID.text = q.npcID.ToString();
        description.text = q.description;
        requirements.text = q.requirements.ToString();
        staticRewardItems.text = q.staticRewardItems.ToString();
        chooseRewardItems.text = q.chooseRewardItems.ToString();
        xMarker.text = q.xMarker.ToString();
        yMarker.text = q.yMarker.ToString();
    }

    public void CreateGUI()
    {
        root = rootVisualElement;

        questList = new List<Quest>();

        questDropDown = new DropdownField
        {
            name = "Quest List",
            label = "Quest List"
        };
        questDropDown.RegisterValueChangedCallback(ValueChanged);
        root.Add(questDropDown);

        questType = new Label { name = "Quest Type" };
        root.Add(questType);

        questID = new Label { name = "Quest ID" };
        root.Add(questID);

        npcID = new Label { name = "NPC ID" };
        root.Add(npcID);

        description = new Label { name = "Quest Description" };
        root.Add(description);

        requirements = new Label { name = "Requirements" };
        root.Add(requirements);

        staticRewardItems = new Label { name = "Static Reward Items" };
        root.Add(staticRewardItems);

        chooseRewardItems = new Label { name = "Choose Reward Items" };
        root.Add(chooseRewardItems);

        xMarker = new Label { name = "X Marker" };
        root.Add(xMarker);

        yMarker = new Label { name = "Y Marker" };
        root.Add(yMarker);

        // Initially update labels to default text
        UpdateLabels();

        // Add Save and Load buttons
        Button saveButton = new Button(SaveQuests) { text = "Save Quests" };
        root.Add(saveButton);

        Button loadButton = new Button(LoadQuests) { text = "Load Quests" };
        root.Add(loadButton);
    }

    public void AddQuest(Quest newQuest)
    {
        if (newQuest == null)
        {
            Console.WriteLine("Failed to add Quest");
        return; 
        }
        Console.WriteLine("Quest added");
        questList.Add(newQuest);
        questDropDown.choices.Add(newQuest.questID.ToString());
        if (questList.Count == 1)
        {
            q = newQuest;
            UpdateLabels();
        }
    }

    private void SaveQuests()
    {
        string json = JsonUtility.ToJson(new QuestListWrapper { quests = questList }, true); // Pretty print JSON
        Debug.Log("Saved JSON: " + json); // Print the JSON to the console
        string path = Application.dataPath + "/quests.json";
        try
        {
            File.WriteAllText(path, json);
            Debug.Log("Quests saved to: " + path);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save quests: " + e.Message);
        }
    }

    private void LoadQuests()
    {
        string path = Application.dataPath + "/quests.json";
        if (File.Exists(path))
        {
            try
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
                Debug.Log("Quests loaded from: " + path);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load quests: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("No quest file found at: " + path);
        }
    }
}

[Serializable]
public class QuestListWrapper
{
    public List<Quest> quests;
}
