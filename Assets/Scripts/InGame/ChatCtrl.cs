using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Text;

[Serializable]
public struct ChatUnit
{
    public int id;
    public string name;
    public string text;
}

[Serializable]
public struct ChatList
{
   public ChatUnit[] chats;
}

public class ChatCtrl : MonoBehaviour
{
    [SerializeField]
    private Text chatText;
    [SerializeField]
    private Text characterName;
    [SerializeField]
    private float textDelay;
    [SerializeField]
    private float autoDelay;

    public List<ChatUnit> listChatLoadText;
    public List<string> chatString;
    public List<string> characterNameString;

    private int chatCount = 0;
    private int countChack = 154;
    private bool AutoChack = false;

   
    private void Start()
    {
        ChatLoad();
        chatText.text = null;
        characterName.text = null;
    }

    private void Update()
    {
        if(!this.gameObject.activeInHierarchy)
        {
            return;
        }
    }

    private void ChatAlgorithm()
    {
        countChack = chatCount;
        characterName.text = characterNameString[chatCount];
        chatText.text = null;
    }

    private void AutoChatAlgorithm()
    {
        ChatAlgorithm();
        chatText.DOText(chatString[chatCount], textDelay).SetEase(Ease.Linear).OnComplete(() =>
        {
            chatCount++;
            //Debug.Log("반복" + (chatCount) + "회");
        });
    }

    public void Auto()
    {
        if (AutoChack == true)
        {
            AutoChack = false;
            Debug.Log("오토 꺼짐");
            CancelInvoke("AutoChatAlgorithm");
        }
        else
        {
            AutoChack = true;
            Debug.Log("오토 켜짐");
            InvokeRepeating("AutoChatAlgorithm",0, autoDelay);
        }
    }
           
 
    public void ShowChat()
    {
        if(AutoChack == true) { return; }
        if (countChack == chatCount)
        {
            chatText.DOKill(this);
            chatText.text = null;
            chatText.text = chatString[chatCount-1];
            return;
        }
        ChatAlgorithm();
        chatText.DOText(chatString[chatCount], textDelay).SetEase(Ease.Linear).OnComplete(() => { chatCount++; });
    }

    public void ChatLoad()
    {
        TextAsset textData = Resources.Load("Json/ChatJson") as TextAsset;

        listChatLoadText = new List<ChatUnit>(JsonUtility.FromJson<ChatList>(textData.ToString()).chats);

        for (int i = 0; i < listChatLoadText.Count; i++)
        {
            characterNameString.Add(listChatLoadText[i].name);
            chatString.Add(listChatLoadText[i].text);
        }
    }
}
