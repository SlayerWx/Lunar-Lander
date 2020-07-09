using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    bool alive;
    bool wantPause;
    bool safeLanding;
    Move myMove;
    void Start()
    {
        alive = true;
        wantPause = false;
        safeLanding = false;
        myMove = GetComponent<Move>();
    }
    void Update()
    {
        PlayerPauseRequest();
    }
    public void SetAlive(bool value)
    {
        alive = value;
    }
    public bool GetAlive()
    {
        return alive;
    }
    public void SetWantPause(bool value)
    {
        wantPause = value;
    }
    public bool GetWantPause()
    {
        return wantPause;
    }
    public bool GetHasGasoline()
    {
        return myMove.GetGasoline()>0;
    }
    public void SetSafeLanding(bool value)
    {
        safeLanding = value;
    }
    public bool GetSafeLanding()
    {
        return safeLanding;
    }
    void PlayerPauseRequest()
    {
        if(Input.GetKeyDown(KeyCode.P) && !wantPause)
        {
            wantPause = true;
        }
        else if(Input.GetKeyDown(KeyCode.P) && wantPause)
        {
            wantPause = false;
        }
    }
}
