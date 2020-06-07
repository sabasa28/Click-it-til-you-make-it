using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Break();
        Debug.Log("Game Closed");
    }
    public void ReturnToGameplayScene()
    {

    }
}
