using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCondition : MonoBehaviour
{
    [SerializeField]
    PlayerStatus playerStatus;
    void Start()
    {

    }

    void Update()
    {
        PlayerRequestPause();
        WinCondition();
        LostCondition();
    }
    void PlayerRequestPause()
    {
        if (playerStatus.GetWantPause() && playerStatus.GetAlive())
        {
            Time.timeScale = 0.0f;
        }
        else if (!playerStatus.GetWantPause() && playerStatus.GetAlive())
        {
            Time.timeScale = 1.0f;
        }
    }
    void WinCondition()
    {
        if(playerStatus.GetAlive() && playerStatus.GetSafeLanding())
        {

        }
    }
    void LostCondition()
    {
        if(!playerStatus.GetAlive())
        {

        }
    }
}
