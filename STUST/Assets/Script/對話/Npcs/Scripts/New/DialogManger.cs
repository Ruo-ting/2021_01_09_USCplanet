using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManger : MonoBehaviour
{
    public static DialogManger instance;

    public GameObject dialogueBox;//顯示或隱藏
    public Text dialogueText, nameText;
    public Image faceImage;

    [TextArea(1, 3)]                    
    public string[] dialogueLines;      
    [SerializeField] private int currentLine;

    [Header("頭像")]
    public Sprite face01;

    private bool isScrolling;
    [SerializeField] private float textSpeed;

    public Questable currentQuestable; //當前正在說話的對象

    public QuestTarget questTarget;

    public Talkable talkable;

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

    
    public void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
    }

    private void Update()
    {
        if (dialogueBox != null)
        {
            if (dialogueBox.activeInHierarchy)
            {

                if (Input.GetMouseButtonUp(0) && dialogueText.text == dialogueLines[currentLine])
                {
                    if (isScrolling == false)
                    {
                        currentLine++;

                        if (currentLine < dialogueLines.Length)
                        {
                            CheckName();
                            //dialogueText.text = dialogueLines[currentLine];
                            StartCoroutine(ScrollingText());
                        }
                        else
                        {
                            //CheckQuestIsComplete();
                            print(CheckQuestIsComplete());

                            if (CheckQuestIsComplete() && currentQuestable.isFinished == false)//如果NPC說完話以後,我們的任務完成了,開啟祝賀的對話
                            {
                                ShowDialogue(talkable.congratslines, talkable.hasName);
                                currentQuestable.isFinished = true;
                            }
                            else //說完對話,沒有任務沒有完成,返回值為false情況下,關閉對話窗口
                            {
                                dialogueBox.SetActive(false);
                                FindObjectOfType<basemove>().isTalking = true;


                                if (currentQuestable == null)//並不是所有npc都有委派的能力
                                {
                                    Debug.Log("There is no Quest in this person");
                                }
                                else
                                {
                                    currentQuestable.DelegateQuest();
                                    //更新任務ui列表
                                    QuestManager.instance.UpdateQuestList();
                                    //
                                    //
                                    //
                                    if (CheckQuestIsComplete() && currentQuestable.isFinished == false)
                                    {
                                        ShowDialogue(talkable.congratslines, talkable.hasName);
                                        currentQuestable.isFinished = true;
                                    }
                                }

                                if (questTarget != null)
                                {

                                    for (int i = 0; i < Player.instance.questList.Count; i++)
                                      if (Player.instance.questList[i].questName == questTarget.questName)
                                      {
                                            //玩家和隱藏人物說話完了,任務完成
                                            questTarget.hasTalked = true;
                                            questTarget.QuestComplete();
                                      }

                                }
                                else
                                {
                                    return;
                                }
                            }
                            #region BACKUP
                            /*dialogueBox.SetActive(false);
                            FindObjectOfType<basemove>().isTalking = true;


                            if (currentQuestable == null)//並不是所有npc都有委派的能力
                            {
                                Debug.Log("There is no Quest in this person");
                            }
                            else
                            {
                                currentQuestable.DelegateQuest();
                                //更新任務ui列表
                                QuestManager.instance.UpdateQuestList();
                            }

                            if (questTarget != null)
                            {
                                //玩家和隱藏人物說話完了,任務完成
                                questTarget.hasTalked = true;
                                questTarget.QuestComplete();
                            }
                            else
                            {
                                return;
                            }
                            }*/
                            #endregion

                        }
                    }
                }





            }
        }

            
        
    }
    public void ShowDialogue(string[] _newLines,bool _hasName)            
    {
        dialogueLines = _newLines;
        currentLine = 0;

        CheckName();

        //dialogueText.text = dialogueLines[currentLine];
        StartCoroutine(ScrollingText());
        dialogueBox.SetActive(true);

        basemove.instance.isTalking = false;
        //nameText.gameObject.SetActive(true);
        //nameText.gameObject.SetActive(false);
        nameText.gameObject.SetActive(_hasName);
        faceImage.sprite = face01;
    }
    private void CheckName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogueText.text = "";

        foreach (char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isScrolling = false;
    }
    //和委派任務的NPC對話完成之後,調用這個方法,判斷委派的任務是否[已經完成]如果完成了,返回值True,否則是False
    public bool CheckQuestIsComplete()
    {
        if (currentQuestable == null)//如果像是路標一些不存在任務的對話 就即為空
        {
            return false;
        }
        for (int i = 0; i < Player.instance.questList.Count; i++)
        {
            if (currentQuestable.quest.questName == Player.instance.questList[i].questName
                && Player.instance.questList[i].questStatus == Quest.QuestStatus.Completed)
            {
                currentQuestable.quest.questStatus = Quest.QuestStatus.Completed;
                return true;
            }
        }
        return false;
    }
}
