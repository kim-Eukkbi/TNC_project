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

    public List<ChatUnit> listChatLoadText;
    public List<string> chatString;
    public List<string> characterNameString;

    private int chatCount = 0;
    private int countChack = 154;

    private void Start()
    {
        ChatLoad();
        characterName.text = null;
        chatText.text = null;
    }

    private void Update()
    {
        if(!this.gameObject.activeInHierarchy)
        {
            return;
        }
    }

    public void ShowChat()
    {
        if (countChack == chatCount)
        {
            chatText.DOKill(this);
            chatText.text = null;
            chatText.text = chatString[chatCount-1];
            return;
        }
        countChack = chatCount;
        characterName.text = characterNameString[chatCount];
        chatText.text = null;
        chatText.DOText(chatString[chatCount], textDelay)/*.SetEase(Ease.Linear)*/.OnComplete(() => { chatCount++; });
    }
    public void ChatLoad()
    {
        byte[] chatJsonLoad = File.ReadAllBytes(Application.streamingAssetsPath + "/Chat/ChatJson.json");

        string chat = Encoding.UTF8.GetString(chatJsonLoad);

        listChatLoadText = new List<ChatUnit>(JsonUtility.FromJson<ChatList>(chat).chats);

        for (int i = 0; i < listChatLoadText.Count; i++)
        {
            characterNameString.Add(listChatLoadText[i].name);
            chatString.Add(listChatLoadText[i].text);
        }
    }
}
