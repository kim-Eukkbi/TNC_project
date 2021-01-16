using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChSelect : MonoBehaviour
{
  
    int ClickCount = 0;
    void Update()
    {
     

        if(ClickCount == 1)
        {
          
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            SceneManager.LoadScene("MAIN");
        }

    }

   public void DoubleClick()
    {
        ++ClickCount;
    }
}
