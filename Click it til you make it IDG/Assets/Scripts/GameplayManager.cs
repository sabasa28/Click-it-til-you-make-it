using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public float patsPerClick = 1;
    public ButtonForUpgrade buttonPref;
    public Transform buttonsPanel;
    public Button frenzyButtonPref;
    Button frenzyButtonInstance = null;
    float maxPatsReached = 0;
    float currentPats = 0;
    bool frenzy = false;
    float buff = 1;
    Action<int> UpdatePatsText;
    UIGameplay UIManager;
    List<ButtonForUpgrade> upgrades = new List<ButtonForUpgrade>();
    Coroutine PasivePats = null;

    void Start()
    {
        UIManager = FindObjectOfType<UIGameplay>();
        UIManager.AddToCurrentPats = OnClickAddPats;
        UpdatePatsText = UIManager.UpdatePetsText;
        SpawnUpgrade(ButtonForUpgrade.UpgradeEffect.autoClick);
        //SpawnUpgrade(ButtonForUpgrade.UpgradeEffect.spawnStash);
    }
    private void Update()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            upgrades[i].CheckInteractable((int)currentPats);
        }
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
    void SubtractFromPats(int ammountToSubtract)
    {
        currentPats -= ammountToSubtract;
        UpdatePatsText((int)currentPats);
    }
    void SpawnUpgrade(ButtonForUpgrade.UpgradeEffect kind)
    {
        ButtonForUpgrade upgradeInstance = Instantiate(buttonPref, buttonsPanel);
        upgradeInstance.OnClickAction = SetUpgradeAction(upgradeInstance.kind);
        upgradeInstance.InitializeUpgrade(kind);
        upgradeInstance.SubtractPriceFromPats = SubtractFromPats;
        upgrades.Add(upgradeInstance);
    }
    Action<float> SetUpgradeAction(ButtonForUpgrade.UpgradeEffect kind)
    {
        switch (kind)
        {
            case ButtonForUpgrade.UpgradeEffect.powerClick:
                break;
            case ButtonForUpgrade.UpgradeEffect.autoClick:
                return ChangePasivePatsRate;
            case ButtonForUpgrade.UpgradeEffect.spawnStash:
                break;
            case ButtonForUpgrade.UpgradeEffect.spawnFrenzy:
                break;;
        }
        return ChangePasivePatsRate;
    }
    void ChangePasivePatsRate(float patsPerSec)
    {
        if (PasivePats != null) StopCoroutine(PasivePats);
        PasivePats = StartCoroutine(AddPatsPasively(patsPerSec));
    }
    IEnumerator AddPatsPasively(float patsPerSec)
    {
        while (true)
        {
            currentPats += 1 * buff;
            UpdatePatsText((int)currentPats);
            yield return new WaitForSeconds(1.0f/ patsPerSec);
        }
    }

    void spawnFrenzy(float buffPerPat)
    {
        Instantiate(frenzyButtonPref);

        //spawnea un coso y lo guarda en una variable. Inicia una corutina que si no lo clickean en cierto tiempo se destruye y hay 
        //un waitforseconds para spawnear otro frenzy.
    }
    //el coso 
    IEnumerator SpawnFrenzy(float buffPerPat)
    {
        int spawnTime;
        while (true)
        {
            spawnTime = UnityEngine.Random.Range(60, 120);
            //Instantiate (frenzyButtonPref, )
            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator Frenzy(float buffPerPat)
    {
        buff = buffPerPat;
        yield return new WaitForSeconds(20);
        buff = 1;
    }
}
