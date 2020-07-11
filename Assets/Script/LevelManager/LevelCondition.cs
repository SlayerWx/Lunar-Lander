using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCondition : MonoBehaviour
{
    [SerializeField]
    PlayerStatus plyerttu;
    [SerializeField]
    LossAnimation plyerNimtion;
    [SerializeField]
    Move plyerMove;
    [SerializeField]
    MapGenerator mp;
    [SerializeField]
    WinAnimation wPlyerMove;
    bool next;
    bool requestHudToNext;
    bool finNext;
    [SerializeField]
    TimeOnLevel tolvl;
    void Start()
    {
        next = false;
        finNext = false;
        requestHudToNext = false;
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
            plyerMove.SetInAnimation(true);
            if (wPlyerMove.Animation())
            {
                requestHudToNext = true;
            }
            if (next)
            {
                plyerMove.RestartPosition();
                plyerttu.SetAlive(true);
                plyerttu.SetSafeLanding(false);
                mp.RestartMap();
                plyerMove.SetInAnimation(false);
                requestHudToNext = false;
                next = false;
            }
        }
    }
    void LostCondition()
    {
        if(!plyerttu.GetAlive() && plyerttu.GetHasGasoline())
        {
            plyerMove.SetInAnimation(true);
            tolvl.SetTimerStop(true);
            if (plyerNimtion.Animation())
            {
                plyerMove.RestartPosition();
                plyerttu.SetAlive(true);
                mp.RestartMap();
                plyerMove.SetInAnimation(false);
                tolvl.SetTimerStop(false);
 
            }
        }
        if(!plyerttu.GetHasGasoline() && !plyerttu.GetAlive())
        {
            plyerMove.SetInAnimation(true);
            if(plyerNimtion.Animation())
            {
                finNext = true;
            }
        }
    }
    public bool getNext()
    {
        return next;
    }
    public void SetNextTrue()
    {
        next = true;
    }
    public bool RequestToNextHud()
    {
        return requestHudToNext;
    }
    public bool getFinNext()
    {
        return finNext;
    }
}
