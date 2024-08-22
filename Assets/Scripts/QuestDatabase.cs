using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Quests",order = 1)]

public class QuestDatabase : ScriptableObject
{
    public List<DailyQuestData> questDatas;
}

[Serializable]
public class QuestProgress
{
    public int id;
    public int progress;
    public bool hasClaimed;
    private bool v;

}

[Serializable]
public class QuestProgressDatabase
{
    public List<QuestProgress> questProgresses;
}

