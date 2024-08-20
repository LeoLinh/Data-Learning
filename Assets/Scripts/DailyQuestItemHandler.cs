using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuestItemHandler : MonoBehaviour
{
    public DailyQuestData dailyQuestData;
    public QuestProgress QuestProgress;
    
    public Text descriotionText;
    public Image rewardIcon;
    public Text rewardQuantityText;
    public Text currentProgressText;
    public Text totalProgressText;

    private void Start()
    {
        UpdatedUi();

    }
    public void SetData(DailyQuestData dailyQuestData, QuestProgress questProgress)
    {
        Debug.Log("SetData");
        this.dailyQuestData = dailyQuestData;
        this.QuestProgress = questProgress;
    }


    [ContextMenu("Update UI")]
    public void UpdatedUi()
    {
        Debug.Log("UpdateUI");
        descriotionText.text = dailyQuestData.description;
        rewardIcon.sprite = dailyQuestData.reward;
        rewardQuantityText.text = dailyQuestData.rewardQuality.ToString();
        UpdateProgress();
    }

    [ContextMenu("Update Progress")]
    public void UpdateProgress()
    {
        currentProgressText.text = $"{QuestProgress.progress}";
        totalProgressText.text = $"/{dailyQuestData.taskCount}";
    }
    // alo alo 1234
}
