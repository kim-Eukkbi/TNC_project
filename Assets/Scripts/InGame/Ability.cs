using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : MonoBehaviour
{
    [SerializeField]
    private GameObject Life;
    [SerializeField]
    private GameObject Toughness;

    public void Downlife() { Life.transform.localScale += new Vector3(0, 5.9f, 0); }
    public void DownToughness(){   Toughness.transform.localScale += new Vector3(0, 2.8f, 0);  }
    //GameObject.Find("Controller").GetComponent<Ability>().Downlife or DownToughness(); 함수 불러오면 됌 

}
