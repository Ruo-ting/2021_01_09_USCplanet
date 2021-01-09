//聊天系統//

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Photon.Chat;
using Photon.Realtime;

using Photon.Pun;


public class Chat : MonoBehaviour, IChatClientListener
{
    public ChatClient chatClient;
    public Text playName;
    public Text connectionState;
    public InputField MsgInput;
    public Text MsgArea;
	public ScrollRect scrollRect;
    protected internal AppSettings chatAppSettings;

	public Text worldchat;
	public Text regionchat;
	public Text secretchat;
	public GameObject worldchatUI;
	public GameObject regionchatUI;
	public GameObject secretchatUI;
	public Dropdown ChangeChatchannel;
	bool focuschat;

	
	public void Start()
	{
		
        
        playName.text=PhotonNetwork.NickName;
        
        Application.runInBackground = true;
        this.chatAppSettings = PhotonNetwork.PhotonServerSettings.AppSettings;
        bool appIdPresent = !string.IsNullOrEmpty(this.chatAppSettings.AppIdChat);
        if(!appIdPresent){
            Debug.Log("Chat ID 未提供");
            return;
        }
        connectionState.text="連線中...";
        // worldChat = "world";
        getConnected();
	}
    void getConnected(){
        Debug.Log("嘗試連接中..");
        this.chatClient = new ChatClient(this);
        this.chatClient.Connect(this.chatAppSettings.AppIdChat,"1.0",new Photon.Chat.AuthenticationValues(playName.text));
        
    }
	public void Update()
	{
		if (this.chatClient != null)
		{
			this.chatClient.Service(); 
		}
		if(Input.GetKeyDown(KeyCode.Return)){
			MsgInput.ActivateInputField();
			focuschat=true;
			if(focuschat==true){
				if(Input.GetKeyDown(KeyCode.Return)){
				MsgInput.DeactivateInputField();
				sendMsg();
				}
			}
		}
		
		

	}
	public void worldchatbtnclick()
	{
		worldchatUI.SetActive(true);
		regionchatUI.SetActive(false);
		secretchatUI.SetActive(false);
		

	}
	public void regionchatbtnclick()
	{
		worldchatUI.SetActive(false);
		regionchatUI.SetActive(true);
		secretchatUI.SetActive(false);
		

	}
	public void secretchatbtnclick()
	{
		worldchatUI.SetActive(false);
		regionchatUI.SetActive(false);
		secretchatUI.SetActive(true);
		

	}
	public void Changechannel()
	{
		if(ChangeChatchannel.options[ChangeChatchannel.value].text=="世界頻道"){
			Staticcode.Chatchannel="world";
			MsgInput.text="";
		}
		if(ChangeChatchannel.options[ChangeChatchannel.value].text=="區域頻道"){
			Staticcode.Chatchannel="region";
			MsgInput.text="";
		}
		if(ChangeChatchannel.options[ChangeChatchannel.value].text=="私聊頻道"){
			Staticcode.Chatchannel="secret";
			MsgInput.text="/s ";
		}
	}


	public void Connect()
	{
		
	}

    
    public void OnDestroy()
    {
        
    }

    
    public void OnApplicationQuit()
	{
		
	}



	public void OnEnterSend()
	{
		
	}

	public void OnClickSend()
	{
		
	}


	

	private void SendChatMessage(string inputLine)
	{
		
	}

	public void PostHelpToCurrentChannel()
	{
		
	}

	public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
	{
		
	}
    public void sendMsg()
	{
		string Msgtext=(MsgInput.text.ToString());
		string[] MsgSplit=Msgtext.Split(' ');  
        if(MsgSplit[0]=="/s"){
			if(MsgSplit[1]==playName.text){
				MsgArea.text+="<color=#FF0000>"+"不能密語自己!"+"</color>"+"\n";
				MsgInput.text="";
			}else{
				this.chatClient.SendPrivateMessage(MsgSplit[1],MsgSplit[2]);
				MsgInput.text="";
			}
		}
		else if(MsgInput.text.ToString()=="/help"){
			MsgArea.text+="<color=#76EE00>"+"輸入 /s 要發給的人 要發的內容(中間要用空白隔開哦!)"+"</color>"+"\n";
			MsgInput.text="";
		}
		else if(Staticcode.Chatchannel=="world")
		{
			this.chatClient.PublishMessage("世界","chat:"+MsgInput.text);
        	MsgInput.text="";
		}
		else if(Staticcode.Chatchannel=="region")
		{
			this.chatClient.PublishMessage(Staticcode.Chatregionchannel,"chat:"+MsgInput.text);
        	MsgInput.text="";
		}
		
		
	}
	public void OnConnected()
	{
		Debug.Log("連接成功");
        this.chatClient.Subscribe(new string[] { "世界",Staticcode.Chatregionchannel,"私聊" });
        // this.chatClient.PublishMessage("世界","join:"+playName.text);
        
	}

	public void OnDisconnected()
	{
	    Debug.Log("連線丟失");
	}

	public void OnChatStateChange(ChatState state)
	{
		
        Debug.Log("我現在的狀態：" + state);

	}

	public void OnSubscribed(string[] channels, bool[] results)
	{
		Debug.Log("訂閱成功");
        chatClient.SetOnlineStatus(ChatUserStatus.Online);
	}

	private void InstantiateChannelButton(string channelName)
	{
		
	}

	private void InstantiateFriendButton(string friendId)
	{
		
	}


	public void OnUnsubscribed(string[] channels)
	{
		Debug.Log("訂閱失敗");
	}

	public void OnGetMessages(string channelName, string[] senders, object[] messages)
	{
        
        string Msgtext=(messages[0].ToString());
        string[] MsgSplit=Msgtext.Split(':'); 
		if(channelName=="世界"){
			if(MsgSplit[0]=="join"){
            MsgArea.text+=(senders[0]+"加入聊天室"+"\n");
			Canvas.ForceUpdateCanvases();       //关键代码
			scrollRect.verticalNormalizedPosition = 0f;  //关键代码
			Canvas.ForceUpdateCanvases(); 
        	}
        	if(MsgSplit[0]=="chat"){
				if(MsgSplit[1]=="" | MsgSplit[1]==null){

				}else{
					MsgArea.text+=(senders[0]+" 說:"+MsgSplit[1]+"\n");
					Canvas.ForceUpdateCanvases();       //关键代码
					scrollRect.verticalNormalizedPosition = 0f;  //关键代码
					Canvas.ForceUpdateCanvases(); 
				}
            
        	}
		}
		if(channelName=="room1"){
			if(MsgSplit[0]=="chat"){
				if(MsgSplit[1]=="" | MsgSplit[1]==null){

				}else{
					regionchat.text+=(senders[0]+" 說:"+MsgSplit[1]+"\n");
					Canvas.ForceUpdateCanvases();       //关键代码
					scrollRect.verticalNormalizedPosition = 0f;  //关键代码
					Canvas.ForceUpdateCanvases(); 
				}
			}
		}
		if(channelName=="room2"){
			if(MsgSplit[0]=="chat"){
				if(MsgSplit[1]=="" | MsgSplit[1]==null){

				}else{
					regionchat.text+=(senders[0]+" 說:"+MsgSplit[1]+"\n");
					Canvas.ForceUpdateCanvases();       //关键代码
					scrollRect.verticalNormalizedPosition = 0f;  //关键代码
					Canvas.ForceUpdateCanvases(); 
				}
			}
		}  
        
         
        
	}

	public void OnPrivateMessage(string sender, object message, string channelName)
	{
		string[] split=channelName.Split(':');
		if(sender==playName.text){
			MsgArea.text+="<color=#FF00FF>"+"你對"+split[1]+"說:"+message+"</color>"+"\n";
			secretchat.text+="<color=#FF00FF>"+"你對"+split[1]+"說:"+message+"</color>"+"\n";
		}
		else{
			MsgArea.text+="<color=#FF00FF>"+sender+"在你旁邊說:"+message+"</color>"+"\n";
			secretchat.text+="<color=#FF00FF>"+sender+"在你旁邊說:"+message+"</color>"+"\n";
		}
		
	}

	public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
	{
        
		
	}

    public void OnUserSubscribed(string channel, string user)
    {
        
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        
    }

    public void AddMessageToSelectedChannel(string msg)
	{
		
	}



	public void ShowChannel(string channelName)
	{
		
	}

	public void OpenDashboard()
	{
		
	}




}