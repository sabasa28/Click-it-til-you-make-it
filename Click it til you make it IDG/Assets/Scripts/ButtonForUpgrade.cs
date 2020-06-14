using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForUpgrade : MonoBehaviour
{
    public enum UpgradeEffect
    {
        powerClick,
        autoClick,
        spawnStash,
        spawnFrenzy,
    }
    public TextMeshProUGUI buttonText;
    Button button;
    public UpgradeEffect kind;
    int lvl = 1;
    int price = 0;
    float autoPats = 0;
    public Action<int> SubtractPriceFromPats;
    public Action <UpgradeEffect> SetOnClickAction;
    public Action<float> OnClickAction;
    public void CheckInteractable(int pats)
    {
        if (pats >= price)
        {
            if (button.interactable) return;
            button.interactable = true;
        }
        else
        {
            if (!button.interactable) return;
            button.interactable = false;
        }
    }
    public void InitializeUpgrade(UpgradeEffect upgradeKind)
    {
        kind = upgradeKind;
        buttonText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        UpdateButton();
        button.onClick.AddListener(OnClick);
    }
    void UpdateButton()
    {
        switch (kind)
        {
            case UpgradeEffect.autoClick:
                buttonText.text = "Auto Pet " + lvl;
                price = 20 * lvl;
                break;
            case UpgradeEffect.spawnStash:
                buttonText.text = "Random Pats " + lvl;
                price = 30 * lvl;
                break;
            case UpgradeEffect.spawnFrenzy:
                buttonText.text = "Pat Rush " + lvl;
                price = 40 * lvl;
                break;
            case UpgradeEffect.powerClick:
                buttonText.text = "Power Petting " + lvl;
                price = 50 * lvl;
                break;
        }
    }
    public void OnClick()
    {
        SubtractPriceFromPats(price);
        autoPats ++;
        OnClickAction(autoPats);
        lvl++;
        UpdateButton();
    }
}
