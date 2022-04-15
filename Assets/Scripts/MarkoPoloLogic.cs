using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarkoPoloLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI markoPoloText;

    private void Start() 
    {
        for (int i = 1; i<101; i++)
        {
            if (i % 3 == 0 && i % 5 ==0)
            markoPoloText.text +=   "<br> MarkoPolo";

            else if (i % 3 == 0)
            {
                markoPoloText.text +=  "<br> Marko";
            }

            else if (i % 5 == 0)
            {
                markoPoloText.text +=  "<br> Polo";
            }

            else 
            {
                markoPoloText.text +=  "<br>" +  i.ToString();
            }

        }
    }
}
