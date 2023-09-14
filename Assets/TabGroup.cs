using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;

    [SerializeField] private Color tabIdleColor, tabHoverColor;

    public TabButton selectedButton;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null) { tabButtons = new List<TabButton>(); }

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedButton == null || button != selectedButton)
        {
            button.bgColor.color = tabHoverColor;
            button.GetComponentInChildren<TextMeshProUGUI>().color = button.textColore; 
        }
    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedButton = button;

        ResetTabs();

        button.bgColor.color = button.textColore;
        button.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedButton != null && button == selectedButton) { continue; }
            button.bgColor.color = tabIdleColor;
            button.GetComponentInChildren<TextMeshProUGUI>().color = button.textColore;
        }
    }
}
