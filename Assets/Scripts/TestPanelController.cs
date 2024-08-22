using UnityEngine.UI;
using UnityEngine;

public class TestPanelController : MonoBehaviour
{
    public InputField idText;
    public InputField progressText;
    public DailyQuestManager questManager;

    public QuestProgressDatabase questProgressDatabase;
    public DailyQuestItemHandler dailyQuestItemHandler;

    public void Start()
    {
        questProgressDatabase = questManager.QuestProgressDatabase;
    }

    public void UpdateQuest()
    {
        int id = int.Parse(idText.text);
        int progress = int.Parse(progressText.text);
        QuestProgress questProgress = questProgressDatabase.questProgresses.Find(questProgress => questProgress.id == id);

        questProgress.progress = progress;

        DailyQuestItemHandler[] questItemHandles = questManager.rootUicontent.GetComponentsInChildren<DailyQuestItemHandler>();
        foreach (var item in questItemHandles)
        {
            if (item.QuestProgress.id == id)
            {
                item.SetData(item.dailyQuestData, questProgress);
                break;
            }
        }


        //var questProgress = new QuestProgress
        //{
        //    id = id,
        //    progress = progress,
        //    hasClaimed = false
        //};

        // Cập nhật quest progress trong manager
        //questManager.UpdateQuestprogress(questProgress);

        // Lưu lại sau khi cập nhật
        questManager.SaveProgress();
        PlayerPrefs.SetInt("QuestProgress_" + id, progress);
        PlayerPrefs.Save();

    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
