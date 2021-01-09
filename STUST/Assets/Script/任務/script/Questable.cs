using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//這個腳本將會添加在所有可以[委派任務]的NPC,人物對象上
public class Questable : MonoBehaviour
{
    public Quest quest;

    public bool isFinished;

    public QuestTarget questTarget;

    //這方法將會在可委託任務的NPC對話完成之後[調用]
    
    public void DelegateQuest()
    {
        if (isFinished == false)
        {
            if (quest.questStatus == Quest.QuestStatus.Waitting)
            {
                //人物將會被委派一個任務
                Player.instance.questList.Add(quest);
                quest.questStatus = Quest.QuestStatus.Accepted;

                //我們人物將會被委托,委派一個任務
                //判斷此任務是否完成
                if (quest.questType == Quest.QuestType.Gathering)
                {
                    questTarget.QuestComplete();                    
                }
            }
            else
            {
                //已經有這任務 不能重複領取
                Debug.Log(string.Format("QUEST : {0} has accepted already!", quest.questName));
                //Debug.Log("Quest : " + quest.questName + "has accepted already!");
            }
        }
        
    }
}
