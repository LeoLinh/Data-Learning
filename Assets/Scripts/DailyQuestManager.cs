using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DailyQuestManager : MonoBehaviour
{
    public QuestDatabase QuestDatabase;
    public DailyQuestItemHandler dailyQuestItemHandler;
    public Transform rootUicontent;
    public QuestProgressDatabase QuestProgressDatabase;

    private void Awake()
    {
        LoadQuestProgress();

        foreach (var questData in QuestDatabase.questDatas)
        {
            QuestProgress questProgress = QuestProgressDatabase.questProgresses.Find(questProgress => questProgress.id == questData.id);
            CreatQuest(questData, questProgress);
        }
    }

    [ContextMenu("LoadQuestProgress")]
    private void LoadQuestProgress()
    {
        var defaultQuestProgressDatabaseString = JsonUtility.ToJson(QuestProgressDatabase);
        var questProgressDatabaseValue = PlayerPrefs.GetString(nameof(QuestProgressDatabase), defaultQuestProgressDatabaseString);

        QuestProgressDatabase = JsonUtility.FromJson<QuestProgressDatabase>(questProgressDatabaseValue);

        Debug.Log("Loaded progress: " + JsonUtility.ToJson(QuestProgressDatabase));
    }

    private void CreatQuest(DailyQuestData questData, QuestProgress questProgress)
    {
        var quest = Instantiate(dailyQuestItemHandler, rootUicontent);
        quest.SetData(questData, questProgress);
    }

    [ContextMenu("Save Data")]
    public void SaveProgress()
    {
        var questProgressDataBaseString = JsonUtility.ToJson(QuestProgressDatabase);
        Debug.Log("Saving progress: " + questProgressDataBaseString);
        PlayerPrefs.SetString(nameof(QuestProgressDatabase), questProgressDataBaseString);
        PlayerPrefs.Save();
    }
    private void OnApplicationQuit()
    {
        SaveProgress();
    }

    public void UpdateQuestprogress(QuestProgress questProgress)
    {
        QuestProgress quest = QuestProgressDatabase.questProgresses.Find(progress => questProgress.id == progress.id);
        quest.progress = questProgress.progress;
        quest.hasClaimed = questProgress.hasClaimed;
    }
}

