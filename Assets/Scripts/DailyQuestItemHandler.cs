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
        if (dailyQuestData == null || QuestProgress == null)
        {
            Debug.LogError("dailyQuestData or QuestProgress is null in Start!");
            return; // Ngừng lại nếu dữ liệu chưa được gán
        }
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
        if (dailyQuestData == null || QuestProgress == null)
        {
            Debug.LogError("dailyQuestData or QuestProgress is null in UpdatedUi!");
            return; // Ngừng lại nếu dữ liệu chưa được gán
        }

        Debug.Log("UpdateUI");
        descriotionText.text = dailyQuestData.description;
        rewardIcon.sprite = dailyQuestData.reward;
        rewardQuantityText.text = dailyQuestData.rewardQuality.ToString();
        UpdateProgress();
    }

    [ContextMenu("Update Progress")]
    public void UpdateProgress()
    {
        if (QuestProgress == null)
        {
            Debug.LogError("QuestProgress is null in UpdateProgress!");
            return; // Ngừng lại nếu dữ liệu chưa được gán
        }

        currentProgressText.text = $"{QuestProgress.progress}";
        totalProgressText.text = $"/{dailyQuestData.taskCount}";
    }
}
