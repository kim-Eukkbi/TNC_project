using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;


    void Start()
    {
        
    }

    public void OnMenu()
    {
        menuPanel.SetActive(true);
    } 

    public void OffMenu()
    {
        menuPanel.SetActive(false);
    }

   
}
