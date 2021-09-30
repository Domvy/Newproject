using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public GameObject DownPanel;
    public GameObject PanelCloseButton;
    public GameObject PanelOpenButton;

    public GameObject RightPanel;
    public GameObject RightPanelCloseButton;
    public GameObject RightPanelOpenButton;

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

    public void RightPanelClose()
    {
        RightPanel.SetActive(false);
        RightPanelCloseButton.SetActive(false);
        RightPanelOpenButton.SetActive(true);
    }

    public void RightPanelOpen()
    {
        RightPanel.SetActive(true);
        RightPanelOpenButton.SetActive(false);
        RightPanelCloseButton.SetActive(true);
    }
}
