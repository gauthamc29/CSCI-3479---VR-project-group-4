﻿using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Panel currentPanel = null;

 private List<Panel> panelHistory = new List<Panel>();

    private void Start()
    {
        SetupPanel();
    }

    private void SetupPanel()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach (Panel panel in panels)
            panel.Setup(this);

        currentPanel.Show();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
              GoToPrevious();
    }

    public void GoToPrevious()
    {
        if (panelHistory.Count == 0)
        {
            OVRManager.PlatformUIConfirmQuit();
            return;
        }

        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);

    }

    public void SetCurrentWithHistory(Panel newPanel)
    {
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel);

    }

    private void SetCurrent(Panel newPanel)
    {
        currentPanel.Hide();

        currentPanel = newPanel;
        currentPanel.Show();
    }
}
