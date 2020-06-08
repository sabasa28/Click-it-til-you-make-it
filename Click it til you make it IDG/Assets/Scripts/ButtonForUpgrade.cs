using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonForUpgrade : MonoBehaviour
{
    int upgradeNumber = 0;
    public TextMeshProUGUI ButtonText;

    private void Start()
    {
        ButtonText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    public void SetUpgradeNum(int upgradeNum)
    {
        upgradeNumber = upgradeNum;
        InitializeUpgrade();
    }

    void InitializeUpgrade()
    { 
        
    }
    void OnClick()
    { 
    
    }
}
