using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public TextMeshProUGUI patsText;
    public Action AddToCurrentPats;
    GameObject eventSystem;

    public void UpdatePetsText(int currentPats)
    {
        eventSystem = GameObject.Find("EventSystem");
        patsText.text = "Pats = " + currentPats;
    }

    public void OnClickCat()
    {
        AddToCurrentPats();
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
}
