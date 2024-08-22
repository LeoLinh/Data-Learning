using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDailyQuest : MonoBehaviour
{
    public GameObject root;
    public GameObject showTestButton;

    private void Start()
    {
        CloseUi();
    }
    public void ShowUi()
    {
        root.SetActive(true);
        showTestButton.SetActive(false);
    }
    public void CloseUi()
    {
        root?.SetActive(false);
        showTestButton?.SetActive(true);
    }
}
