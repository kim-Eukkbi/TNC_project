using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatCtrl : MonoBehaviour
{
    [SerializeField]
    private Text ChatText;
    [SerializeField]
    private Text CharacterName;
    [SerializeField]
    private float TextDelay;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    private void Update()
    {
        
    }

    private IEnumerator NormalChat(string narrator , string narration)
    {
        int i = 0;
        CharacterName.text = narrator;
        string letter = "";

        for(i =0; i<narration.Length;i++)
        {
            letter += narration[i];
            ChatText.text = letter;
            yield return new WaitForSeconds(TextDelay);
        }
    }

    private IEnumerator ShowText()
    {
        yield return StartCoroutine(NormalChat("대이", "파괴파괴파괴파괴파괴파괴파괴파괴파괴파괴파괴파괴파괴파괴파괴파괴"));
    }
}
