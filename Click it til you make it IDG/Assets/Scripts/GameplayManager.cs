using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public float patsPerClick = 1;
    public Button buttonPref;
    public Transform buttonsPanel;
    float maxPatsReached = 0;
    float currentPats = 0;
    Action<int> UpdatePatsText;
    UIGameplay UIManager;

    void Start()
    {
        UIManager = FindObjectOfType<UIGameplay>();
        UIManager.AddToCurrentPats = OnClickAddPats;
        UpdatePatsText = UIManager.UpdatePetsText;
        Instantiate(buttonPref, buttonsPanel);
        Instantiate(buttonPref, buttonsPanel);
    }

    void UpdateMaxPats(int currentPatAmmount)
    {
        if (currentPatAmmount>maxPatsReached) maxPatsReached = currentPatAmmount;
    }

    public void OnClickAddPats()
    {
        currentPats += patsPerClick;
        UpdatePatsText((int)currentPats);
    }


}
