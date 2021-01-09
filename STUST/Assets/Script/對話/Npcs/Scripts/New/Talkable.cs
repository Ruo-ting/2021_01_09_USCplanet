using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    //對話內容
    [SerializeField] private bool isEntered;
    
    public Character character;
    [TextArea(2, 5)]
    public string[] lines;
    public bool hasName;

    public GameObject talkIcon;//提示玩家可對話的UI交互

    public Questable questable;//可說話的對象,有可能含有任務

    public QuestTarget questTarget;

    //觸發事件另外的對話
    [TextArea(1, 4)]
    public string[] congratslines;//當任務完成以後,祝福的一些文字內容

    [TextArea(1, 4)]
    public string[] completedLines;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = true;
            talkIcon.SetActive(true);

            DialogManger.instance.currentQuestable = questable;
            DialogManger.instance.questTarget = questTarget;//當玩家進入到可說話範圍內時後 這個可說話的遊戲對象身上的QuestTarget組件將會被賦值到DM腳本中的questTarget變亮中
            DialogManger.instance.talkable = this; //當人物進入的時候 將這個腳本賦值到我們剛才聲明的DM腳本當中的talkable變量當中

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
            DialogManger.instance.currentQuestable = null;
            talkIcon.SetActive(false);
        }
    }
    private void Update()
    {
        if (isEntered && Input.GetKey(KeyCode.R) && DialogManger.instance.dialogueBox.activeInHierarchy == false)
        {

            if (questable == null)
            {
                DialogManger.instance.ShowDialogue(lines, hasName);
            }
            else
            {
                if (questable.quest.questStatus == Quest.QuestStatus.Completed)
                {
                    DialogManger.instance.ShowDialogue(completedLines, hasName);
                }
                else
                {
                    DialogManger.instance.ShowDialogue(lines, hasName);
                }
            }
            
        }
    }
    

}
