using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCondition : MonoBehaviour
{
    [SerializeField]
    PlayerStatus plyerttu;
    [SerializeField]
    LostAnimation plyerNimtion;
    [SerializeField]
    Move plyerMove;
    [SerializeField]
    MapGenerator mp;
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
        if (plyerttu.GetWantPause() && plyerttu.GetAlive())
        {
            Time.timeScale = 0.0f;
        }
        else if (!plyerttu.GetWantPause() && plyerttu.GetAlive())
        {
            Time.timeScale = 1.0f;
        }
    }
    void WinCondition()
    {
        if(plyerttu.GetAlive() && plyerttu.GetSafeLanding())
        {

        }
    }
    void LostCondition()
    {
        if(!plyerttu.GetAlive() && plyerttu.GetHasGasoline())
        {
            plyerMove.SetInAnimation(true);
            if (plyerNimtion.Animation())
            {
                plyerMove.RestartPosition();
                plyerttu.SetAlive(true);
                mp.RestartMap();
                plyerMove.SetInAnimation(false);

            }
        }
        if(!plyerttu.GetHasGasoline() && !plyerttu.GetAlive())
        {

        }
    }
}
