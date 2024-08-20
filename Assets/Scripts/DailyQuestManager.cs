using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyQuestManager : MonoBehaviour
{
    public QuestDatabase QuestDatabase;
    public DailyQuestItemHandler dailyQuestItemHandler;
    public Transform rootUicontent;
    public QuestProgressDatabase QuestProgressDatabase;

    private void Start()
    {
        LoadQuestProgress();

        foreach (var questData in QuestDatabase.questDatas)
        {
            QuestProgress questProgress = QuestProgressDatabase.questProgresses.Find(questProgress => questProgress.id == questData.id);
            CreatQuest(questData, questProgress);
        }
    }

    private void LoadQuestProgress()
    {
        var defaultQuestProgressDatabaseString = JsonUtility.ToJson(QuestProgressDatabase);
        var questProgressDatabaseValue = PlayerPrefs.GetString(nameof(QuestProgressDatabase), defaultQuestProgressDatabaseString);

        QuestProgressDatabase = JsonUtility.FromJson<QuestProgressDatabase>(questProgressDatabaseValue);
    }

    private void CreatQuest(DailyQuestData questData, QuestProgress questProgress)
    {
        var quest = Instantiate(dailyQuestItemHandler, rootUicontent);
        quest.SetData(questData, questProgress);
    }

    [ContextMenu("Save Data")]
    private void SaveProgress()
    {
        var questProgressDataBaseString = JsonUtility.ToJson(QuestProgressDatabase);
        PlayerPrefs.SetString(nameof(QuestProgressDatabase), questProgressDataBaseString);
        PlayerPrefs.Save();
    }
    private void OnApplicationQuit()
    {
        SaveProgress();
    }
}

