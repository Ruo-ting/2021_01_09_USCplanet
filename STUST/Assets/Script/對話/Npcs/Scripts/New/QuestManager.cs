using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject[] questUIArraw;

    public GameObject questPanel;

    private void Start()
    {
        
            questPanel.SetActive(false);
        
        
    }

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

    //當我們接到新的任務,或者任務完成後,需要更新我們UI面板上的任務列表
    public void UpdateQuestList()
    {
        for (int i = 0; i < Player.instance.questList.Count; i++)
        {
            questUIArraw[i].transform.GetChild(0).GetComponent<Text>().text = Player.instance.questList[i].questName;

            if (Player.instance.questList[i].questStatus == Quest.QuestStatus.Accepted)
            {
                questUIArraw[i].transform.GetChild(1).GetComponent<Text>().text = "<color=red>" + Player.instance.questList[i].questStatus + "</color>";
            }
            else if (Player.instance.questList[i].questStatus == Quest.QuestStatus.Completed)
            {
                questUIArraw[i].transform.GetChild(1).GetComponent<Text>().text = "<color=green>" + Player.instance.questList[i].questStatus + "</color>";
            }

        }
    }
    //按下esc關閉開啟任務列表
    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape) && basemove.instance.isTalking == true)
            {
                    questPanel.SetActive(!questPanel.activeInHierarchy);
            }
            
    }
}
