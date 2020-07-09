using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    bool alive;
    bool wantPause;
    bool hasGasoline;
    bool safeLanding;

    // Start is called before the first frame updat asAS
    void Start()
    {
        alive = true;
        wantPause = false;
        hasGasoline = true;
        safeLanding = false;
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
    public void SetHasGasoline(bool value)
    {
        hasGasoline = value;
    }
    public bool GetHasGasoline()
    {
        return hasGasoline;
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
