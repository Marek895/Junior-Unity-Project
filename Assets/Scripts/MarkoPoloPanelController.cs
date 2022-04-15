using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkoPoloPanelController : MonoBehaviour
{
    [SerializeField] GameObject markoPoloPanel;

    public void ActivatePanel()
    {
        markoPoloPanel.SetActive(true);
    }

    public void DeactivatePanel()
    {
        markoPoloPanel.SetActive(false);
    }

}
