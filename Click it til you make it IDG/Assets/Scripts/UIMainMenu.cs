using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Break();
        Debug.Log("Game Closed");
    }
}
