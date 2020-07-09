using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainLayer;
    [SerializeField]
    private GameObject creditsLayer;
    [SerializeField]
    private GameObject scoreLayer;

    public void Play()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    public void CreditsEntry()
    {
        creditsLayer.SetActive(true);
        mainLayer.SetActive(false);
    }
    public void CreditsDeparture()
    {
        mainLayer.SetActive(true);
        creditsLayer.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void EntryScore()
    {
        mainLayer.SetActive(false);
        scoreLayer.SetActive(true);
    }
    public void ExitScore()
    {
        mainLayer.SetActive(true);
        scoreLayer.SetActive(false);
    }
}
