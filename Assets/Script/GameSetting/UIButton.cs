using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public GameObject DownPanel;
    public GameObject PanelCloseButton;
    public GameObject PanelOpenButton;


    public void PanelClose()
    {
        DownPanel.SetActive(false);
        PanelCloseButton.SetActive(false);
        PanelOpenButton.SetActive(true);
    }

    public void PanelOpen()
    {
        DownPanel.SetActive(true);
        PanelOpenButton.SetActive(false);
        PanelCloseButton.SetActive(true);
    }
}
