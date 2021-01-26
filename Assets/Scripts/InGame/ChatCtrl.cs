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
    public int event_id;
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
    [SerializeField]
    private GameObject opponent;
    [SerializeField]
    private GameObject chois;
    [SerializeField]
    private Text[] choiS_text;


    public List<ChatUnit> listChatLoadText_All = new List<ChatUnit>();
    private List<ChatUnit> listChatLoadText_InGame = new List<ChatUnit>();

    private int chatCount = 0;
    private int countChack = 154;
    private bool AutoChack = false;
    private bool isCHOISing = false;

   
    private void Start()
    {
        ChatLoad();
        opponent.SetActive(false);
        chois.SetActive(false);
        chatText.text = string.Empty;
        characterName.text = string.Empty;
        for(int i = 0; i<3; i++)
        {
            choiS_text[i].text = string.Empty;
        }
    }

    private void Update()
    {
        if(!this.gameObject.activeInHierarchy)
        {
            return;
        }
    }

    #region 대사 출력
    public void ShowChat()
    {
        opponent.SetActive(true);
        if (isCHOISing == true) { return; }
        if (AutoChack == true) { return; }
        if (countChack == chatCount)
        {
            chatText.DOKill(this);
            chatText.text = string.Empty;
            chatText.text = listChatLoadText_InGame[chatCount - 1].text;
            return;
        }
        ChatAlgorithm();
    }

    private void ChatAlgorithm()
    {
        countChack = chatCount;
        if (listChatLoadText_InGame[chatCount].name.Contains("독백"))
        {
            characterName.text = string.Empty;
        }
        else if (listChatLoadText_InGame[chatCount].name.Contains("선택"))
        {
            CHOISAlgorithm();
            return;
        }
        else
        {
            characterName.text = listChatLoadText_InGame[chatCount].name;
        }

        chatText.text = string.Empty;
        chatText.DOText(listChatLoadText_InGame[chatCount].text, textDelay).SetEase(Ease.Linear).OnComplete(() => { chatCount++; });
    }
    #endregion
    #region 선택지
    private void CHOISAlgorithm()
    {
        isCHOISing = true;
        chois.SetActive(true);
        chatText.text = string.Empty;
        characterName.text = string.Empty;
        for(int i = 0; i<3;i++)
        {
            choiS_text[i].text = listChatLoadText_InGame[chatCount + i].text;
        }
    }

    public void CHOIS(int num)
    {
        Debug.Log(num + "번 선택지");
        chois.SetActive(false);
        isCHOISing = false;
        chatCount = 0;
        listChatLoadText_InGame.Clear();
        AddInGameText(num);
        return;
    }

    #endregion
    #region 오토
    public void Auto()
    {
        if (AutoChack == true)
        {
            AutoChack = false;
            Debug.Log("오토 꺼짐");
            CancelInvoke("ChatAlgorithm");
        }
        else
        {
            AutoChack = true;
            Debug.Log("오토 켜짐");
            InvokeRepeating("ChatAlgorithm", 0, autoDelay);
        }
    }
    #endregion

    public void ChatLoad() //JSON 파싱
    {
        TextAsset textData = Resources.Load("Json/ChatJson") as TextAsset;

        listChatLoadText_All = new List<ChatUnit>(JsonUtility.FromJson<ChatList>(textData.ToString()).chats);

        AddInGameText(0);

    }

    private void AddInGameText(int num)
    {
        for (int i = 0; i < listChatLoadText_All.Count; i++)
        {
            if (listChatLoadText_All[i].event_id.Equals(num))
            {
                listChatLoadText_InGame.Add(listChatLoadText_All[i]);
            }
        }
    }
}
