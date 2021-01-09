using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//談話一下
//找到失去的物品
//探索區域
//這個腳本是放在那些需要任務完成的對象上,比如說特殊的對話人物,可收集的物品,隱藏的區域
public class QuestTarget : MonoBehaviour
{
    public QuestTarget instance;
    public string questName;
    public enum QuestType { Gathering, Talk, Reach };//判斷任務類型 收集 對話 探索
    public QuestType questType;

    [Header("Gathering Type Quest")]//收集類任務
    public int amount = 1;

    [Header("Talk Type Quest")]//對話類任務
    public bool hasTalked;//判斷是否和隱藏npc對話過

    [Header("Reach Type Quest")]//探索型任務
    public bool hasReached;

    //這個方法將會在完成任務之後被調用,比如說我們收集整齊所有物品,或者和特殊人員對話後,到達隱藏地點
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

    }

    public void QuestComplete()
    {
        for (int i = 0; i < Player.instance.questList.Count; i++)
        {
            if (questName == Player.instance.questList[i].questName
                && Player.instance.questList[i].questStatus == Quest.QuestStatus.Accepted)
            {
                switch (questType)
                {
                    case QuestType.Gathering:
                        if (Player.instance.itemAmount >= Player.instance.questList[i].requireAmount)//如果當玩家的[itemAmount]大於等於玩家持有這個任務的[要求數量]
                        {
                            Player.instance.questList[i].questStatus = Quest.QuestStatus.Completed;//玩家持有當前任務的狀態就會變已經完成
                            QuestManager.instance.UpdateQuestList(); //更新最新的UI用欄
                        }
                            break;
                    
                    case QuestType.Talk:
                        if (hasTalked)
                        {
                            Player.instance.questList[i].questStatus = Quest.QuestStatus.Completed;
                            QuestManager.instance.UpdateQuestList();
                        }
                            break;
                    case QuestType.Reach:
                        if (hasReached)
                        {
                            Player.instance.questList[i].questStatus = Quest.QuestStatus.Completed;
                            QuestManager.instance.UpdateQuestList();
                        }
                        break;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other) //在任務目標完成才能判斷有無完成任務
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < Player.instance.questList.Count; i++)
            {
                if (Player.instance.questList[i].questName == questName)
                {
                    if (questType == QuestType.Gathering)
                    {
                        Player.instance.itemAmount += amount;
                        QuestComplete();
                    }


                    if (questType == QuestType.Reach)
                    {
                        hasReached = true;
                        QuestComplete();
                    }

                    else if (questType == QuestType.Talk)
                    {
                        hasTalked = true;
                        QuestComplete();
                    }


                }
            }
                

            #region
            //if (questType == QuestType.Gathering)
            //{
            //    //Player.instance.itemAmount += amount;
            //    QuestComplete();
            //}
            //else if (questType == QuestType.Reach)
            //{
            //    hasReached = true;
            //    QuestComplete();
            //}
            #endregion


        }
    }
}
