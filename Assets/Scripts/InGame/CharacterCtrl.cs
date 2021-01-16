using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterMain;
    [SerializeField]
    private GameObject ChatMain;

    private bool[] CharacterBool = new bool[3];

    public void CharacterOne()
    {
        CharacterBool[0] = true;
        CharacterSelect();
    }
    public void CharacterTwo()
    {
        CharacterBool[1] = true;
        CharacterSelect();
    }
    public void CharacterThree()
    {
        CharacterBool[2] = true;
        CharacterSelect();
    }

    public void CharacterSelect()
    {
        //TODO 나중에 애들 3명 나눠지면 그때 버튼마다 해당 캐릭으로 스토리 전환 하는거 만들어야함
        if(CharacterBool[0] == true)
        {
            CharacterMain.SetActive(false);
            ChatMain.SetActive(true);
        }
        else if(CharacterBool[1] == true)
        {
            return;
        }
        else if (CharacterBool[2] == true)
        {
            return;
        }
    }

}
