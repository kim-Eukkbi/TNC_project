using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterMain;
    [SerializeField]
    private GameObject ChatMain;
    [SerializeField]
    private GameObject menuPanel;

    private void Update()
    {
        if(CharacterMain.activeInHierarchy)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(true);
        }
    }
    public void CharacterSelect(int num)
    {
        //TODO 나중에 애들 3명 나눠지면 그때 버튼마다 해당 캐릭으로 스토리 전환 하는거 만들어야함
        switch(num)
        {
            case 1:
                CharacterMain.SetActive(false);
                ChatMain.SetActive(true);
                menuPanel.SetActive(false);
                break;
            default:
                Debug.Log("준비중입니다");
                break;
        }
    }

}


