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
    GameObject myEventSystem;

    public void UpdatePetsText(int currentPats)
    {
        myEventSystem = GameObject.Find("EventSystem");
        patsText.text = "Pats = " + currentPats;
    }

    public void OnClickCat()
    {
        AddToCurrentPats();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }



}
