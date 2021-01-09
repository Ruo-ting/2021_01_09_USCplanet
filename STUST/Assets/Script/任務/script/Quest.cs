using UnityEngine;

[System.Serializable]
public class Quest 
{
    
    public enum QuestType { Gathering, Talk,Reach};//收集對話探索
    public enum QuestStatus { Waitting,Accepted,Completed};//等待接受完成

    
    public string questName;
    public QuestType questType;//任務類型
    public QuestStatus questStatus;//下拉菜單當前狀態

    public int expRewards; //經驗值
    public int goldRewards; //金幣

    [Header("Gathering Type Quest")]
    public int requireAmount; //表示收集類任務需要達到的數量

}
