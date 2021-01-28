using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : MonoBehaviour
{
    [SerializeField]
    private GameObject Life;
    [SerializeField]
    private GameObject Toughness;

    void Start()
    {
       
    }

    public void Downlife(int subtractlife) //5.7
    {
        Life.transform.localScale += new Vector3(0, subtractlife, 0);
    }
    
    public void DownToughness(float subtractToughness) //2.8
    { 
        Toughness.transform.localScale += new Vector3(0, subtractToughness, 0); 
    }
    //GameObject.Find("Controller").GetComponent<Ability>().Downlife or DownToughness(); 함수 불러오면 됌 

}
