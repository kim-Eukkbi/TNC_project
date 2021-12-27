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
    public int scene_id;
    public int event_id;
    public int id;
    public int sound;
    public int system_pm;
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
    private GameObject fadeObj;
    [SerializeField]
    private float textDelay;
    [SerializeField]
    private float autoDelay;
    [SerializeField]
    private GameObject opponent;
    [SerializeField]
    private GameObject chat_main;
    [SerializeField]
    private GameObject[] choiSObj;

    public List<ChatUnit> listChatLoadText_All = new List<ChatUnit>();
    private List<ChatUnit> listChatLoadText_InGame = new List<ChatUnit>();

    private int chatCount = 0;
    private int countChack = 154;
    private int indexScene_Id = 0;
    private int indexEvent_id = 0;
    private bool AutoChack = false;
    private bool isCHOISing = false;
    private Image fade_image = null;
    private Text[] choiS_text = new Text[3];


    private void Start()
    {
        ChatLoad();
        opponent.SetActive(false);
        chatText.text = string.Empty;
        characterName.text = string.Empty;
        fade_image = fadeObj.GetComponent<Image>();
        for (int i = 0; i < 3; i++)
        {
            choiS_text[i] = choiSObj[i].GetComponentInChildren<Text>();
            choiSObj[i].SetActive(false);
        }
    }
    #region 대사 출력
    public void ShowChat()
    {
        fadeObj.SetActive(false);
        opponent.SetActive(true);
        if (isCHOISing) { return; }
        if (AutoChack) { return; }
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
        if (listChatLoadText_InGame.Count <= chatCount)
        {
            NextSceneLoad();
        }
        countChack = chatCount;
        switch (listChatLoadText_InGame[chatCount].name)
        {
            case "독백":
                seSound();
                characterName.text = string.Empty;
                break;
            case "[SYSTEM]":
                System();
                return;
            case "선택":
                CHOISAlgorithm();
                return;
            case "편지":
                Latter();
                return;
            default:
                characterName.text = listChatLoadText_InGame[chatCount].name;
                break;
        }
        chatText.text = string.Empty;
        chatText.DOColor(Color.white, 0);
        chatText.DOText(listChatLoadText_InGame[chatCount].text, textDelay).SetEase(Ease.Linear).OnComplete(() => { chatCount++; });
    }
    #endregion
    #region 선택지
    private void CHOISAlgorithm()
    {
        isCHOISing = true;
        chatText.text = string.Empty;
        characterName.text = string.Empty;
        listChatLoadText_InGame.Add(listChatLoadText_All[259]);
        for (int i = 0; i < 3; i++)
        {
            if (!(listChatLoadText_InGame[chatCount + i].text.Contains("준비중입니다. (21-01-28 team.EVA)"))) //선택지 2개일때 오류남 근데 정상 작동함
            {
                choiSObj[i].SetActive(true);
                choiS_text[i].text = listChatLoadText_InGame[chatCount + i].text;
            }
            else
            {
                choiSObj[i].SetActive(false);
            }
        }
    }

    public void CHOIS(int num)
    {
        Debug.Log(num + "번 선택지");
        for (int i = 0; i < 3; i++)
        {
            choiSObj[i].SetActive(false);
        }
        isCHOISing = false;
        indexEvent_id++;
        chatCount = 0;
        listChatLoadText_InGame.Clear();
        if (indexScene_Id.Equals(1) && indexEvent_id.Equals(3))
        {
            AddInGameText(num + 2, indexScene_Id);
        }
        else
        {
            AddInGameText(num, indexScene_Id);
        }
        return;
    }

    #endregion
    #region 오토
    public void Auto()
    {
        if (AutoChack)
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
    #region 사운드&정신+체력 + ect
    public void seSound()
    {
        switch (listChatLoadText_InGame[chatCount].sound)
        {
            case 7:
                SoundManager.Instance.sfxAudio[7].Play(); //틀린 거 아님 
                break;
            case 1:
                SoundManager.Instance.sfxAudio[1].Play();
                break;
            case 2:
                SoundManager.Instance.sfxAudio[2].Play();
                break;
            case 3:
                SoundManager.Instance.sfxAudio[3].Play();
                break;
            case 4:
                SoundManager.Instance.sfxAudio[4].Play();
                break;
            case 5:
                SoundManager.Instance.sfxAudio[5].Play();
                break;
            case 6:
                SoundManager.Instance.sfxAudio[6].Play();
                break;
        }
    }

    public void System()
    {
        characterName.text = string.Empty;
        chatText.text = string.Empty;
        chatText.DOColor(Color.red, 0);
        chatText.DOText(listChatLoadText_InGame[chatCount].text, textDelay).SetEase(Ease.Linear).OnComplete(() => { chatCount++; });

        switch (listChatLoadText_InGame[chatCount].system_pm)
        {
            case 0://심장마비
                Ability.Instance.heartattack(17.6f);
                break;
            case 1://철상
                Ability.Instance.steel(8.8f);
                break;
            case 2://열상
                Ability.Instance.laceration(5.3f);
                break;
            case 3://찰과상
                Ability.Instance.abrasions(3.51f);
                break;
            case 4://허기
                Ability.Instance.hunger(2.1f);
                break;
            case 5://핍박
                Ability.Instance.persecution(7.54f);
                break;
            case 6://증오
                Ability.Instance.hatred(6.14f);
                break;
            case 7://혐오
                Ability.Instance.disgust(4.74f);
                break;
            case 8://악의
                Ability.Instance.malice(4.1f);
                break;
            case 9://짜증
                Ability.Instance.irritation(3.62f);
                break;
        }
    }

    private void Latter()// 바뀔 수 있는 부분입니다 일단 보류
    {
        chatText.text = string.Empty;
        chatText.DOColor(Color.black, 0);
        chatText.DOText(listChatLoadText_InGame[chatCount].text, textDelay).SetEase(Ease.Linear).OnComplete(() => { chatCount++; });
    }

    private void NextSceneLoad()
    {
        chat_main.SetActive(false);
        listChatLoadText_InGame.Clear();
        chatCount = 0;
        indexScene_Id++;
        isCHOISing = true;
        fadeObj.SetActive(true);
        fade_image.DOFade(1, 1).OnComplete(() => { fade_image.DOFade(0, 1).OnComplete(() => { fadeObj.SetActive(false); isCHOISing = false; chat_main.SetActive(true); }); });
        AddInGameText(0, indexScene_Id);
    }
    #endregion
    #region JSON파싱
    public void ChatLoad() //JSON 파싱
    {
        TextAsset textData = Resources.Load("Json/ChatJson") as TextAsset;

        listChatLoadText_All = new List<ChatUnit>(JsonUtility.FromJson<ChatList>(textData.ToString()).chats);

        AddInGameText(0, 0);
    }

    private void AddInGameText(int event_id, int scene_id)
    {
        for (int i = 0; i < listChatLoadText_All.Count; i++)
        {
            if (listChatLoadText_All[i].event_id.Equals(event_id) && listChatLoadText_All[i].scene_id.Equals(scene_id))
            {
                listChatLoadText_InGame.Add(listChatLoadText_All[i]);
            }
        }
    }
    #endregion
}
