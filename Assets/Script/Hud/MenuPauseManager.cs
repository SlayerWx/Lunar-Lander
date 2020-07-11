using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPauseManager : MonoBehaviour
{
    [SerializeField]
    playerStatus playerStatus;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject warningMenu;
    [SerializeField]
    LevelCondition lvlCon;
    [SerializeField]
    GameObject nextRequest;
    [SerializeField]
    GameObject NotGasolineMenu;
    [SerializeField]
    TimeOnLevel tmolvl;
    // Update is called once per frame asAS
    void Update()
    {
        Paused();
    }
    void Paused()
    {
        if(playerStatus.GetWantPause() && playerStatus.GetAlive())
        {
            pauseMenu.SetActive(true);
            tmolvl.SetTimerStop(true);
        }
        else if(!playerStatus.GetWantPause() && playerStatus.GetAlive())
        {
            pauseMenu.SetActive(false);
            warningMenu.SetActive(false);
            tmolvl.SetTimerStop(false);
        }
        if(lvlCon.RequestToNextHud())
        {
            nextRequest.SetActive(true);
            tmolvl.SetTimerStop(true);

        }
        else if(nextRequest.activeSelf)
        {
            nextRequest.SetActive(false);
        }
        if(!playerStatus.GetHasGasoline() &&! playerStatus.GetAlive())
        {
            if(lvlCon.getFinNext())
            NotGasolineMenu.SetActive(true);
            tmolvl.SetTimerStop(true);
        }
    }
    public void ExitRequest()
    {
        warningMenu.SetActive(true);
        tmolvl.SetTimerStop(true);
    }
    public void YesButtonPressed()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void NoButtonPressed()
    {
        warningMenu.SetActive(false);
    }
    public void StagePauseNextFalse()
    {
        nextRequest.SetActive(false);
    }
    public void SaveAndExit()
    {
        Save.SaveScore(playerStatus.GetPoints());
        YesButtonPressed();
    }
}
