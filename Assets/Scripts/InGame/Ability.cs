using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : MonoBehaviour
{
    private static Ability instance = null;

    public static Ability Instance
    {
        get
        {
            instance = FindObjectOfType<Ability>();
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new GameObject("Ability").AddComponent<Ability>();
                }
            }
            return instance;
        }


    }

    [SerializeField]
    public GameObject Life;
    [SerializeField]
    public GameObject Toughness;




    void Start()
    {

    }
    /*
    public void Downlife() //1.76이 10번 100번은 0.176
    {
        Life.transform.localScale += new Vector3(0, subtractlife, 0);
    }
    
    public void DownToughness() //2.8이 10번 100번은 0.28
    { 
        Toughness.transform.localScale += new Vector3(0, subtractToughness, 0); 
    }
    //GameObject.Find("Controller").GetComponent<Ability>().Downlife or DownToughness(); 함수 불러오면 됌 
    */



    public void heartattack(float Heartattack) //심장마비 100 d17.6
    {
        Life.transform.localScale += new Vector3(0, Heartattack, 0);
    }
    public void steel(float Steel) //철상 50 d8.8
    {
        Life.transform.localScale += new Vector3(0, Steel, 0);
    }
    public void laceration(float Laceration) //열상 33 d5.3
    {
        Life.transform.localScale += new Vector3(0, Laceration, 0);
    }
    public void abrasions(float Abrasions) //찰과상 20 d3.52
    {
        Life.transform.localScale += new Vector3(0, Abrasions, 0);
    }
    public void hunger(float Hunger) //허기 12 d.2.112
    {
        Life.transform.localScale += new Vector3(0, Hunger, 0);
    }



    public void persecution(float Persecution) //핍박 27 d7.56
    {
        Toughness.transform.localScale += new Vector3(0, Persecution, 0);
    }
    public void hatred(float Hatred) //증오 22 d6.16
    {
        Toughness.transform.localScale += new Vector3(0, Hatred, 0);
    }
    public void disgust(float Disgust) //혐오 17 d4.76
    {
        Toughness.transform.localScale += new Vector3(0, Disgust, 0);
    }
    public void malice(float Malice) //악의 15 d4.2
    {
        Toughness.transform.localScale += new Vector3(0, Malice, 0);
    }
    public void irritation(float irritation) //짜증 13 d3.64
    {
        Toughness.transform.localScale += new Vector3(0, irritation, 0);
    }
}


