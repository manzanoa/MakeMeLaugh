using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, credits;
    
    public void ToCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
